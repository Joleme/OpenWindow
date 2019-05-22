using System;

namespace OpenWindow
{
    /// <summary>
    /// Platform specific data for a Wayland window.
    /// </summary>
    public class WaylandWindowData : WindowData
    {
        /// <summary>
        /// A global object as advertised by the Wayland compositor.
        /// </summary>
        public class GlobalObject
        {
            public string Interface { get; }
            public uint Name { get; }
            public uint Version { get; }

            public GlobalObject(string iface, uint name, uint version)
            {
                Interface = iface;
                Name = name;
                Version = version;
            }
        }

        /// <summary>
        /// The Wayland display proxy.
        /// </summary>
        public IntPtr WlDisplay { get; }

        /// <summary>
        /// The Wayland registry proxy.
        /// </summary>
        public IntPtr WlRegistry { get; }

        /// <summary>
        /// The Wayland surface proxy for the surface created for the window.
        ///  OpenWindow does not map a buffer to this surface.
        /// </summary>
        public IntPtr WlSurface { get; }

        /// <summary>
        /// The globals that were present at the time of calling <see cref="Window.GetPlatformData"/>.
        /// </summary>
        public GlobalObject[] Globals { get; }

        /// <summary>
        /// The EGL display connection.
        /// Note that this will be <see>IntPtr.Zero</see> if the window was not created with OpenGL support.
        /// <summary>
        /// <seealso cref="OpenGlSurfaceSettings.EnableOpenGl">
        public IntPtr EGLDisplay { get; }
        public IntPtr WaylandEglWindow { get; }
        public IntPtr EGLSurface { get; }
        public IntPtr EGLConfig { get; }

        internal WaylandWindowData(IntPtr wlDisplay, IntPtr wlRegistry, IntPtr wlSurface, GlobalObject[] globals,
            IntPtr eglDisplay, IntPtr eglWindow, IntPtr eglSurface, IntPtr eglConfig)
            : base(WindowingBackend.Wayland)
        {
            WlDisplay = wlDisplay;
            WlRegistry = wlRegistry;
            WlSurface = wlSurface;
            Globals = globals;

            EGLDisplay = eglDisplay;
            WaylandEglWindow = eglWindow;
            EGLSurface = eglSurface;
            EGLConfig = eglConfig;
        }
    }
}
