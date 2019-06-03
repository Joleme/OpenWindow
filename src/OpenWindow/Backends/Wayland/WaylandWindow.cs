﻿using System;
using System.Runtime.InteropServices;
using OpenWindow.Backends.Wayland.Managed;

namespace OpenWindow.Backends.Wayland
{
    internal unsafe class WaylandWindow : Window
    {
        #region Private Fields

        private readonly WlDisplay _display;
        private readonly WlCompositor _compositor;
        public readonly WlSurface Surface;
        private readonly XdgSurface _xdgSurface;
        private readonly XdgToplevel _xdgTopLevel;
        private readonly ZxdgToplevelDecorationV1 _xdgDecoration;
        private readonly WpViewporter _viewporter;
        private readonly WpViewport _viewport;

        private EGLDisplay* _eglDisplay;
        private wl_egl_window* _eglWindow;
        private EGLSurface* _eglSurface;
        private EGLConfig* _eglConfig;

        private bool _surfaceConfigured;

        #endregion

        #region Constructor

        public WaylandWindow(WlDisplay display, WlCompositor wlCompositor, WlSurface wlSurface, XdgSurface xdgSurface, ZxdgDecorationManagerV1 xdgDecorationManager, WpViewporter wpViewporter, OpenGlSurfaceSettings glSettings)
            : base(false)
        {
            _display = display;
            _compositor = wlCompositor;
            Surface = wlSurface;
            Surface.SetListener(SurfaceEnterCallback, SurfaceLeaveCallback);
            _xdgSurface = xdgSurface;
            _xdgSurface.SetListener(XdgSurfaceConfigureCallback);
            _xdgTopLevel = _xdgSurface.GetToplevel();
            _xdgTopLevel.SetListener(TopLevelConfigureCallback, TopLevelCloseCallback);
            if (!xdgDecorationManager.IsNull)
                _xdgDecoration = xdgDecorationManager.GetToplevelDecoration(_xdgTopLevel);

            // TODO pass these in WindowingService.CreateWindow
            const int width = 100;
            const int height = 100;

            if (glSettings.EnableOpenGl)
            {
                InitOpenGl(glSettings, width, height);
            }
            else
            {
                GlSettings = OpenGlSurfaceSettings.Disabled;
            }

            // Use the viewporter protocol to set the surface size so it does not depend on a buffer
            // We want to control the surface size, but users provide the buffer.
            if (!wpViewporter.IsNull)
            {
                _viewporter = wpViewporter;
                _viewport = wpViewporter.GetViewport(Surface);
                _viewport.SetDestination(width, height);
            }
            else
            {
                WindowingService.LogWarning("Wayland viewporter protocol not supported. Window size is determined by the bound buffer.");
            }

            Surface.Commit();

            // from the xdg-shell protocol file:
            // "Creating an xdg_surface from a wl_surface which has a buffer attached or
            //  committed is a client error, and any attempts by a client to attach or
            //  manipulate a buffer prior to the first xdg_surface.configure call must
            //  also be treated as errors."
            // We do a blocking wait to make sure users can't attach a buffer before the first configure call
            while (!_surfaceConfigured)
            {
                display.Flush();
                display.Dispatch();
            }
        }

        private void InitOpenGl(OpenGlSurfaceSettings s, int width, int height)
        {
            _eglDisplay = ((WaylandWindowingService) WindowingService.Get()).GetEGLDisplay();

            int[] attribs =
            {
                Egl.RENDERABLE_TYPE, Egl.OPENGL_BIT,
                Egl.RED_SIZE, s.RedSize,
                Egl.GREEN_SIZE, s.GreenSize,
                Egl.BLUE_SIZE, s.BlueSize,
                Egl.ALPHA_SIZE, s.AlphaSize,
                Egl.DEPTH_SIZE, s.DepthSize,
                Egl.STENCIL_SIZE, s.StencilSize,
                Egl.SAMPLES, s.MultiSampleCount,
                Egl.SAMPLE_BUFFERS, s.MultiSampleCount > 1 ? 1 : 0,
                Egl.NONE
            };

            var configs = new IntPtr[8];
            if (!Egl.ChooseConfig(_eglDisplay, attribs, configs, configs.Length, out var configCount))
            {
                WindowingService.LogWarning("eglChooseConfig failed. Window was not initialized with OpenGL support.");
                return;
            }
            if (configCount == 0)
            {
                WindowingService.LogWarning("No valid EGL configs. Window was not initialized with OpenGL support.");
                return;
            }

            _eglConfig = (EGLConfig*) configs[0];

            _eglWindow = WaylandClient.wl_egl_window_create(Surface.Pointer, width, height);

            if (_eglWindow == null)
            {
                _eglConfig = null;
                WindowingService.LogWarning("EGL window creation failed. Window was not initialized with OpenGL support.");
                return;
            }

            var surfaceAttribs = new int[]
            {
                Egl.RENDER_BUFFER, s.DoubleBuffer ? Egl.BACK_BUFFER : Egl.SINGLE_BUFFER,
                Egl.NONE
            };

            _eglSurface = Egl.CreateWindowSurface(_eglDisplay, _eglConfig, _eglWindow, surfaceAttribs);
            if (_eglSurface == null)
            {
                _eglConfig = null;
                WaylandClient.wl_egl_window_destroy(_eglWindow);
                _eglWindow = null;
                WindowingService.LogWarning("EGL surface creation failed. Window was not initialized with OpenGL support.");
                return;
            }
        }

        private void SurfaceEnterCallback(void* data, wl_surface* surface, wl_output* output)
        {
        }

        private void SurfaceLeaveCallback(void* data, wl_surface* surface, wl_output* output)
        {
        }

        private void XdgSurfaceConfigureCallback(void* data, xdg_surface* proxy, uint serial)
        {
            _xdgSurface.AckConfigure(serial);
            _surfaceConfigured = true;
        }

        private void TopLevelConfigureCallback(void* data,  xdg_toplevel* toplevel, int width, int height, wl_array* states)
        {
            if (_eglWindow != null)
                WaylandClient.wl_egl_window_resize(_eglWindow, width, height, 0, 0);

            WindowingService.LogDebug($"Top level configure event ({width}, {height})");
            RaiseResize();
        }

        private void TopLevelCloseCallback(void* data, xdg_toplevel* proxy)
        {
            Close();
        }

        #endregion

        #region Window Properties

        // setting global position is not supported in Wayland
        public override Point Position { get => Point.Zero; set { } }

        public override Size Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <inheritdoc />
        public override Size ClientSize
        {
            get => throw new NotImplementedException();
            set
            {
                _xdgSurface.SetWindowGeometry(0, 0, value.Width, value.Height);
                if (_eglWindow != null)
                    WaylandClient.wl_egl_window_resize(_eglWindow, value.Width, value.Height, 0, 0);
                RaiseResize();
            }
        }

        public override Rectangle Bounds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Rectangle ClientBounds
        {
            get 
            {
                WindowingService.LogWarning("Wayland does not support getting window position.");
                return new Rectangle(Point.Zero, ClientSize);
            }
            set
            {
                WindowingService.LogWarning("Wayland does not support setting window position.");
                ClientSize = value.Size;
            }
        }

        #endregion

        #region Window Functions

        /// <inheritdoc />
        public override Display GetContainingDisplay()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override WindowData GetPlatformData()
        {
            var ws = (WaylandWindowingService) WindowingService.Get();
            return new WaylandWindowData(ws.GetDisplayProxy(), ws.GetRegistryProxy(), (IntPtr) Surface.Pointer, ws.GetGlobals(),
                (IntPtr) _eglDisplay, (IntPtr) _eglWindow, (IntPtr) _eglSurface, (IntPtr) _eglConfig);
        }

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        protected override void InternalMaximize()
        {
            _xdgTopLevel.SetMaximized();
        }

        /// <inheritdoc />
        protected override void InternalMinimize()
        {
            _xdgTopLevel.SetMinimized();
        }

        /// <inheritdoc />
        protected override void InternalRestore()
        {
            _xdgTopLevel.UnsetMaximized();
        }

        /// <inheritdoc />
        protected override void InternalSetTitle(string value)
        {
            _xdgTopLevel.SetTitle(value);
        }

        /// <inheritdoc />
        protected override void InternalSetBorderless(bool value)
        {
            // TODO client side border fallback?
            if (!_xdgDecoration.IsNull)
                _xdgDecoration.SetMode(value ? zxdg_toplevel_decoration_v1_mode.ClientSide : zxdg_toplevel_decoration_v1_mode.ServerSide);
            else if (!value)
                WindowingService.LogWarning("Border enabled but Wayland compositor does not support server side decoration.");
        }

        /// <inheritdoc />
        protected override void InternalSetResizable(bool value)
        {
            // nothing to do, use _resizable to check if resizing is allowed
            // TODO client side border resizing
        }

        /// <inheritdoc />
        protected override void InternalSetMinSize(Size value)
        {
            _xdgTopLevel.SetMinSize(value.Width, value.Height);
        }

        /// <inheritdoc />
        protected override void InternalSetMaxSize(Size value)
        {
            _xdgTopLevel.SetMaxSize(value.Width, value.Height);
        }

        /// <inheritdoc />
        protected override void InternalSetCursorVisible(bool value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private void GlobalAddEvent(object data, IntPtr registry, uint id, string iface, uint version)
        {
            
        }

        private void GlobalRemoveEvent(object data, IntPtr registry, uint id)
        {
            
        }
 
        private Exception CreateException(string message)
        {
            return new OpenWindowException(message);
        }

        #endregion

        #region IDisposable

        protected override void ReleaseUnmanagedResources()
        {
            if (_eglSurface != null)
                Egl.DestroySurface(_eglDisplay, _eglSurface);
            if (_eglWindow != null)
                WaylandClient.wl_egl_window_destroy(_eglWindow);

            _xdgTopLevel.FreeListener();
            _xdgSurface.FreeListener();
            Surface.FreeListener();

            _viewport.Destroy();
            _viewporter.Destroy();
            _xdgDecoration.Destroy();
            _xdgTopLevel.Destroy();
            _xdgSurface.Destroy();
            Surface.Destroy();
        }

        #endregion
    }
}