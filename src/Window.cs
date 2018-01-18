﻿// MIT License - Copyright (C) Jesse "Jjagg" Gielen
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace OpenWindow
{
    public abstract class Window : IDisposable
    {
        #region Private Fields

        private bool _shouldClose;
        private bool _visible;
        private string _title = string.Empty;
        private bool _decorated = true;
        private bool _resizable;
        internal bool _focused;

        private bool _disposed;

        #endregion

        #region Window API: Properties

        /// <summary>
        /// Get a pointer to the native window handle.
        /// </summary>
        public IntPtr Handle { get; protected set; }

        /// <summary>
        /// <code>false</code> if the underlying native window was created by OpenWindow with the
        /// <see cref="WindowingService.CreateWindow"/> method, <code>true</code>
        /// if it was created from an existing native window handle with the
        /// <see cref="WindowingService.WindowFromHandle"/> method.
        /// </summary>
        public bool UserManaged { get; }

        /// <summary>
        /// If set to <code>true</code> a request to close this window has been sent either by caling <see cref="Close"/>
        /// or by the window manager. An application usually wants to monitor this flag, but can freely decide what to
        /// do when it is set.
        /// </summary>
        public bool ShouldClose => _shouldClose;

        /// <summary>
        /// The text that is displayed in the title bar of the window (if it has a title bar).
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                CheckDisposed();
                if (_title != value)
                {
                    _title = value;
                    InternalSetTitle(value);
                }
            }
        }

        /// <summary>
        /// Indicates if this window is visible.
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set
            {
                CheckDisposed();
                if (_visible != value)
                {
                    _visible = value;
                    InternalSetVisible(value);
                }
            }
        }

        /// <summary>
        /// Indicates if this window is decorated, i.e. has a border.
        /// Defaults to true (default has a border).
        /// </summary>
        public bool Decorated
        {
            get => _decorated;
            set
            {
                CheckDisposed();
                if (_decorated != value)
                {
                    _decorated = value;
                    InternalSetBorderless(value);
                }
            }
        }

        /// <summary>
        /// Indicates if users can resize the window.
        /// Defaults to false.
        /// </summary>
        public bool Resizable
        {
            get => _resizable;
            set
            {
                CheckDisposed();
                if (_resizable != value)
                {
                    _resizable = value;
                    InternalSetResizable(value);
                }
            }
        }

        /// <summary>
        /// Indicates if this window has keyboard focus.
        /// </summary>
        public bool Focused => _focused;

        /// <summary>
        /// The position of the top left of this window (including border).
        /// </summary>
        public abstract Point Position { get; set; }

        /// <summary>
        /// The size of this window (including border).
        /// </summary>
        public abstract Point Size { get; set; }

        /// <summary>
        /// The bounds of this window (including border).
        /// </summary>
        public abstract Rectangle Bounds { get; set; }

        /// <summary>
        /// The bounds of this window (excluding border).
        /// </summary>
        public abstract Rectangle ClientBounds { get; set; }

        public OpenGLWindowSettings GlSettings { get; protected set; }

        #endregion

        #region Window API: Functions

        /// <summary>
        /// Shows the window. Equivalent to setting <see cref="Visible"/> to <code>true</code>.
        /// </summary>
        public void Show()
        {
            Visible = true;
        }

        /// <summary>
        /// Hides the window. Equivalent to setting <see cref="Visible"/> to <code>false</code>.
        /// </summary>
        public void Hide()
        {
            Visible = false;
        }

        /// <summary>
        /// Make the window fill the entire display it's on.
        /// </summary>
        public void Maximize()
        {
            InternalMaximize();
        }

        /// <summary>
        /// Minimize or iconify the window.
        /// </summary>
        public void Minimize()
        {
            InternalMinimize();
        }

        /// <summary>
        /// Restore the window. If it was minimized or maximized, the original bounds will be restored.
        /// </summary>
        public void Restore()
        {
            InternalRestore();
        }

        /// <summary>
        /// Get the display that the window is on.
        /// </summary>
        /// <returns>The display the window is on.</returns>
        public abstract Display GetContainingDisplay();

        /// <summary>
        /// Makes the window borderless and sets the <see cref="ClientBounds"/> to 
        /// the size of the display it is on.
        /// </summary>
        /// <seealso cref="GetContainingDisplay">Used to get the display the window is on.</seealso>
        public void SetFullscreen()
        {
            Decorated = false;
            ClientBounds = GetContainingDisplay().Bounds;
        }

        /// <summary>
        /// Sets the <see cref="ShouldClose"/> flag to <code>true</code>.
        /// </summary>
        public void Close()
        {
            _shouldClose = true;
            RaiseCloseRequested();
        }

        /// <summary>
        /// Get a byte array with the status data for each virtual key.
        /// </summary>
        /// <returns>
        /// A byte array representing the state of the keyboard.
        /// Use <see cref="VirtualKey"/> members to index into it.
        /// </returns>
        public abstract byte[] GetKeyboardState();

        /// <summary>
        /// Check if the specified key is down.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if the key is down, false if it is up.</returns>
        public abstract bool IsDown(Key key);

        /// <summary>
        /// Get the key modifiers currently enabled.
        /// </summary>
        /// <returns>The enabled key modifiers.</returns>
        public abstract KeyMod GetKeyModifiers();

        /// <summary>
        /// Check if caps lock is turned on.
        /// </summary>
        /// <returns><code>true</code> if caps lock is turned on, <code>false</code> if it is turned off.</returns>
        public abstract bool IsCapsLockOn();

        /// <summary>
        /// Check if num lock is turned on.
        /// </summary>
        /// <returns><code>true</code> if num lock is turned on, <code>false</code> if it is turned off.</returns>
        public abstract bool IsNumLockOn();

        /// <summary>
        /// Check if scroll lock is turned on.
        /// </summary>
        /// <returns><code>true</code> if scroll lock is turned on, <code>false</code> if it is turned off.</returns>
        public abstract bool IsScrollLockOn();

        #endregion

        protected Window(bool userManaged)
        {
            UserManaged = userManaged;
        }

        #region Window API: Events

        /// <summary>
        /// Invoked when the <see cref="ShouldClose"/> flag is set to <code>true</code>.
        /// </summary>
        public event EventHandler<EventArgs> CloseRequested;

        /// <summary>
        /// Invoked right before the window closes.
        /// </summary>
        public event EventHandler<EventArgs> Closing;

        /// <summary>
        /// Invoked after the window focus changed.
        /// </summary>
        public event EventHandler<FocusChangedEventArgs> FocusChanged;

        /// <summary>
        /// Invoked when a key is pressed down or a key is repeated.
        /// </summary>
        public event EventHandler<KeyDownEventArgs> KeyDown;

        /// <summary>
        /// Invoked when a key is pressed down. Not invoked when a key is held down like <see cref="KeyDown"/>.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyPressed;

        /// <summary>
        /// Invoked when a key is released.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyUp;

        /// <summary>
        /// Invoked when a keypress happens.
        /// </summary>
        public event EventHandler<TextInputEventArgs> TextInput;

        #endregion

        #region Internal Functions

        internal virtual void Update()
        {
        }

        internal void RaiseCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseClosing()
        {
            Closing?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseFocusChanged(bool newFocus)
        {
            FocusChanged?.Invoke(this, new FocusChangedEventArgs(newFocus));
        }

        internal void RaiseKeyDown(Key key, int repeatCount, int scanCode, char character)
        {
            KeyDown?.Invoke(this, new KeyDownEventArgs(key, repeatCount, scanCode, character));
        }

        internal void RaiseKeyPressed(Key key, int scanCode, char character)
        {
            KeyPressed?.Invoke(this, new KeyEventArgs(key, scanCode, character));
        }

        internal void RaiseKeyUp(Key key, int scanCode, char character)
        {
            KeyUp?.Invoke(this, new KeyEventArgs(key, scanCode, character));
        }

        internal void RaiseTextInput(char c)
        {
            TextInput?.Invoke(this, new TextInputEventArgs(c));
        }

        #endregion

        #region Protected Methods

        protected abstract void InternalSetVisible(bool value);
        protected abstract void InternalMaximize();
        protected abstract void InternalMinimize();
        protected abstract void InternalRestore();
        protected abstract void InternalSetTitle(string value);
        protected abstract void InternalSetBorderless(bool value);
        protected abstract void InternalSetResizable(bool value);

        #endregion

        #region Disposable pattern

        protected void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("Cannot use a destroyed window.");
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            ReleaseUnmanagedResources();

            _disposed = true;
        }

        protected virtual void ReleaseUnmanagedResources()
        {
        }

        /// <summary>
        /// Destroys the window.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Window()
        {
            Dispose(false);
        }

        #endregion
    }
}