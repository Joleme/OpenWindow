﻿namespace OpenWindow
{
    // Jjagg:
    //    These key codes where taken directly from SDL.
    //    Here's the original license header:
    /*
      Simple DirectMedia Layer
      Copyright (C) 1997-2018 Sam Lantinga <slouken@libsdl.org>
      This software is provided 'as-is', without any express or implied
      warranty.  In no event will the authors be held liable for any damages
      arising from the use of this software.
      Permission is granted to anyone to use this software for any purpose,
      including commercial applications, and to alter it and redistribute it
      freely, subject to the following restrictions:
      1. The origin of this software must not be misrepresented; you must not
         claim that you wrote the original software. If you use this software
         in a product, an acknowledgment in the product documentation would be
         appreciated but is not required.
      2. Altered source versions must be plainly marked as such, and must not be
         misrepresented as being the original software.
      3. This notice may not be removed or altered from any source distribution.
    */


    /// <summary>
    /// Virtual key codes.
    ///
    /// These codes are used to represent keys after mapping scancodes
    /// using the current keyboard layout.
    /// Where possible the enum values map to the corresponding
    /// character. For key codes with no matching character,
    /// the value is equal to the scan code.
    /// </summary>
    public enum Key
    {
        /// <summary>
        /// Not an actual key. Used internally.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 
        /// </summary>
        Return = '\r',
        /// <summary>
        /// 
        /// </summary>
        Escape = '\u001B',
        /// <summary>
        /// 
        /// </summary>
        Backspace = '\b',
        /// <summary>
        /// 
        /// </summary>
        Tab = '\t',
        /// <summary>
        /// 
        /// </summary>
        Space = ' ',
        /// <summary>
        /// 
        /// </summary>
        Exclaim = '!',
        /// <summary>
        /// 
        /// </summary>
        Quotedbl = '"',
        /// <summary>
        /// 
        /// </summary>
        Hash = '#',
        /// <summary>
        /// 
        /// </summary>
        Percent = '%',
        /// <summary>
        /// 
        /// </summary>
        Dollar = '$',
        /// <summary>
        /// 
        /// </summary>
        Ampersand = '&',
        /// <summary>
        /// 
        /// </summary>
        Quote = '\'',
        /// <summary>
        /// 
        /// </summary>
        Leftparen = '(',
        /// <summary>
        /// 
        /// </summary>
        Rightparen = ')',
        /// <summary>
        /// 
        /// </summary>
        Asterisk = '*',
        /// <summary>
        /// 
        /// </summary>
        Plus = '+',
        /// <summary>
        /// 
        /// </summary>
        Comma = ',',
        /// <summary>
        /// 
        /// </summary>
        Minus = '-',
        /// <summary>
        /// 
        /// </summary>
        Period = '.',
        /// <summary>
        /// 
        /// </summary>
        Slash = '/',
        /// <summary>
        /// 
        /// </summary>
        D0 = '0',
        /// <summary>
        /// 
        /// </summary>
        D1 = '1',
        /// <summary>
        /// 
        /// </summary>
        D2 = '2',
        /// <summary>
        /// 
        /// </summary>
        D3 = '3',
        /// <summary>
        /// 
        /// </summary>
        D4 = '4',
        /// <summary>
        /// 
        /// </summary>
        D5 = '5',
        /// <summary>
        /// 
        /// </summary>
        D6 = '6',
        /// <summary>
        /// 
        /// </summary>
        D7 = '7',
        /// <summary>
        /// 
        /// </summary>
        D8 = '8',
        /// <summary>
        /// 
        /// </summary>
        D9 = '9',
        /// <summary>
        /// 
        /// </summary>
        Colon = ':',
        /// <summary>
        /// 
        /// </summary>
        Semicolon = ';',
        /// <summary>
        /// 
        /// </summary>
        Less = '<',
        /// <summary>
        /// 
        /// </summary>
        Equals = '=',
        /// <summary>
        /// 
        /// </summary>
        Greater = '>',
        /// <summary>
        /// 
        /// </summary>
        Question = '?',
        /// <summary>
        /// 
        /// </summary>
        At = '@',
        /// <summary>
        /// 
        /// </summary>
        LeftBracket = '[',
        /// <summary>
        /// 
        /// </summary>
        Backslash = '\\',
        /// <summary>
        /// 
        /// </summary>
        RightBracket = ']',
        /// <summary>
        /// 
        /// </summary>
        Caret = '^',
        /// <summary>
        /// 
        /// </summary>
        Underscore = '_',
        /// <summary>
        /// 
        /// </summary>
        Backquote = '`',
        /// <summary>
        /// 
        /// </summary>
        A = 'a',
        /// <summary>
        /// 
        /// </summary>
        B = 'b',
        /// <summary>
        /// 
        /// </summary>
        C = 'c',
        /// <summary>
        /// 
        /// </summary>
        D = 'd',
        /// <summary>
        /// 
        /// </summary>
        E = 'e',
        /// <summary>
        /// 
        /// </summary>
        F = 'f',
        /// <summary>
        /// 
        /// </summary>
        G = 'g',
        /// <summary>
        /// 
        /// </summary>
        H = 'h',
        /// <summary>
        /// 
        /// </summary>
        I = 'i',
        /// <summary>
        /// 
        /// </summary>
        J = 'j',
        /// <summary>
        /// 
        /// </summary>
        K = 'k',
        /// <summary>
        /// 
        /// </summary>
        L = 'l',
        /// <summary>
        /// 
        /// </summary>
        M = 'm',
        /// <summary>
        /// 
        /// </summary>
        N = 'n',
        /// <summary>
        /// 
        /// </summary>
        O = 'o',
        /// <summary>
        /// 
        /// </summary>
        P = 'p',
        /// <summary>
        /// 
        /// </summary>
        Q = 'q',
        /// <summary>
        /// 
        /// </summary>
        R = 'r',
        /// <summary>
        /// 
        /// </summary>
        S = 's',
        /// <summary>
        /// 
        /// </summary>
        T = 't',
        /// <summary>
        /// 
        /// </summary>
        U = 'u',
        /// <summary>
        /// 
        /// </summary>
        V = 'v',
        /// <summary>
        /// 
        /// </summary>
        W = 'w',
        /// <summary>
        /// 
        /// </summary>
        X = 'x',
        /// <summary>
        /// 
        /// </summary>
        Y = 'y',
        /// <summary>
        /// 
        /// </summary>
        Z = 'z',

        /// <summary>
        /// 
        /// </summary>
        Capslock = ScanCode.Capslock,

        /// <summary>
        /// 
        /// </summary>
        F1 = ScanCode.F1,
        /// <summary>
        /// 
        /// </summary>
        F2 = ScanCode.F2,
        /// <summary>
        /// 
        /// </summary>
        F3 = ScanCode.F3,
        /// <summary>
        /// 
        /// </summary>
        F4 = ScanCode.F4,
        /// <summary>
        /// 
        /// </summary>
        F5 = ScanCode.F5,
        /// <summary>
        /// 
        /// </summary>
        F6 = ScanCode.F6,
        /// <summary>
        /// 
        /// </summary>
        F7 = ScanCode.F7,
        /// <summary>
        /// 
        /// </summary>
        F8 = ScanCode.F8,
        /// <summary>
        /// 
        /// </summary>
        F9 = ScanCode.F9,
        /// <summary>
        /// 
        /// </summary>
        F10 = ScanCode.F10,
        /// <summary>
        /// 
        /// </summary>
        F11 = ScanCode.F11,
        /// <summary>
        /// 
        /// </summary>
        F12 = ScanCode.F12,

        /// <summary>
        /// 
        /// </summary>
        Printscreen = ScanCode.Printscreen,
        /// <summary>
        /// 
        /// </summary>
        Scrolllock = ScanCode.Scrolllock,
        /// <summary>
        /// 
        /// </summary>
        Pause = ScanCode.Pause,
        /// <summary>
        /// 
        /// </summary>
        Insert = ScanCode.Insert,
        /// <summary>
        /// 
        /// </summary>
        Home = ScanCode.Home,
        /// <summary>
        /// 
        /// </summary>
        Pageup = ScanCode.Pageup,
        /// <summary>
        /// 
        /// </summary>
        Delete = '\u007F',
        /// <summary>
        /// 
        /// </summary>
        End = ScanCode.End,
        /// <summary>
        /// 
        /// </summary>
        Pagedown = ScanCode.Pagedown,
        /// <summary>
        /// 
        /// </summary>
        Right = ScanCode.Right,
        /// <summary>
        /// 
        /// </summary>
        Left = ScanCode.Left,
        /// <summary>
        /// 
        /// </summary>
        Down = ScanCode.Down,
        /// <summary>
        /// 
        /// </summary>
        Up = ScanCode.Up,

        /// <summary>
        /// 
        /// </summary>
        Numlockclear = ScanCode.Numlockclear,
        /// <summary>
        /// 
        /// </summary>
        KpDivide = ScanCode.KpDivide,
        /// <summary>
        /// 
        /// </summary>
        KpMultiply = ScanCode.KpMultiply,
        /// <summary>
        /// 
        /// </summary>
        KpMinus = ScanCode.KpMinus,
        /// <summary>
        /// 
        /// </summary>
        KpPlus = ScanCode.KpPlus,
        /// <summary>
        /// 
        /// </summary>
        KpEnter = ScanCode.KpEnter,
        /// <summary>
        /// 
        /// </summary>
        Kp_1 = ScanCode.Kp_1,
        /// <summary>
        /// 
        /// </summary>
        Kp_2 = ScanCode.Kp_2,
        /// <summary>
        /// 
        /// </summary>
        Kp_3 = ScanCode.Kp_3,
        /// <summary>
        /// 
        /// </summary>
        Kp_4 = ScanCode.Kp_4,
        /// <summary>
        /// 
        /// </summary>
        Kp_5 = ScanCode.Kp_5,
        /// <summary>
        /// 
        /// </summary>
        Kp_6 = ScanCode.Kp_6,
        /// <summary>
        /// 
        /// </summary>
        Kp_7 = ScanCode.Kp_7,
        /// <summary>
        /// 
        /// </summary>
        Kp_8 = ScanCode.Kp_8,
        /// <summary>
        /// 
        /// </summary>
        Kp_9 = ScanCode.Kp_9,
        /// <summary>
        /// 
        /// </summary>
        Kp_0 = ScanCode.Kp_0,
        /// <summary>
        /// 
        /// </summary>
        KpPeriod = ScanCode.KpPeriod,

        /// <summary>
        /// 
        /// </summary>
        Application = ScanCode.Application,
        /// <summary>
        /// 
        /// </summary>
        Power = ScanCode.Power,
        /// <summary>
        /// 
        /// </summary>
        KpEquals = ScanCode.KpEquals,
        /// <summary>
        /// 
        /// </summary>
        F13 = ScanCode.F13,
        /// <summary>
        /// 
        /// </summary>
        F14 = ScanCode.F14,
        /// <summary>
        /// 
        /// </summary>
        F15 = ScanCode.F15,
        /// <summary>
        /// 
        /// </summary>
        F16 = ScanCode.F16,
        /// <summary>
        /// 
        /// </summary>
        F17 = ScanCode.F17,
        /// <summary>
        /// 
        /// </summary>
        F18 = ScanCode.F18,
        /// <summary>
        /// 
        /// </summary>
        F19 = ScanCode.F19,
        /// <summary>
        /// 
        /// </summary>
        F20 = ScanCode.F20,
        /// <summary>
        /// 
        /// </summary>
        F21 = ScanCode.F21,
        /// <summary>
        /// 
        /// </summary>
        F22 = ScanCode.F22,
        /// <summary>
        /// 
        /// </summary>
        F23 = ScanCode.F23,
        /// <summary>
        /// 
        /// </summary>
        F24 = ScanCode.F24,
        /// <summary>
        /// 
        /// </summary>
        Execute = ScanCode.Execute,
        /// <summary>
        /// 
        /// </summary>
        Help = ScanCode.Help,
        /// <summary>
        /// 
        /// </summary>
        Menu = ScanCode.Menu,
        /// <summary>
        /// 
        /// </summary>
        Select = ScanCode.Select,
        /// <summary>
        /// 
        /// </summary>
        Stop = ScanCode.Stop,
        /// <summary>
        /// 
        /// </summary>
        Again = ScanCode.Again,
        /// <summary>
        /// 
        /// </summary>
        Undo = ScanCode.Undo,
        /// <summary>
        /// 
        /// </summary>
        Cut = ScanCode.Cut,
        /// <summary>
        /// 
        /// </summary>
        Copy = ScanCode.Copy,
        /// <summary>
        /// 
        /// </summary>
        Paste = ScanCode.Paste,
        /// <summary>
        /// 
        /// </summary>
        Find = ScanCode.Find,
        /// <summary>
        /// 
        /// </summary>
        Mute = ScanCode.Mute,
        /// <summary>
        /// 
        /// </summary>
        Volumeup = ScanCode.Volumeup,
        /// <summary>
        /// 
        /// </summary>
        Volumedown = ScanCode.Volumedown,
        /// <summary>
        /// 
        /// </summary>
        KpComma = ScanCode.KpComma,
        /// <summary>
        /// 
        /// </summary>
        KpEqualsas400 = ScanCode.KpEqualsas400,

        /// <summary>
        /// 
        /// </summary>
        Alterase = ScanCode.Alterase,
        /// <summary>
        /// 
        /// </summary>
        Sysreq = ScanCode.Sysreq,
        /// <summary>
        /// 
        /// </summary>
        Cancel = ScanCode.Cancel,
        /// <summary>
        /// 
        /// </summary>
        Clear = ScanCode.Clear,
        /// <summary>
        /// 
        /// </summary>
        Prior = ScanCode.Prior,
        /// <summary>
        /// 
        /// </summary>
        Return2 = ScanCode.Return2,
        /// <summary>
        /// 
        /// </summary>
        Separator = ScanCode.Separator,
        /// <summary>
        /// 
        /// </summary>
        Out = ScanCode.Out,
        /// <summary>
        /// 
        /// </summary>
        Oper = ScanCode.Oper,
        /// <summary>
        /// 
        /// </summary>
        Clearagain = ScanCode.Clearagain,
        /// <summary>
        /// 
        /// </summary>
        Crsel = ScanCode.Crsel,
        /// <summary>
        /// 
        /// </summary>
        Exsel = ScanCode.Exsel,

        /// <summary>
        /// 
        /// </summary>
        Kp_00 = ScanCode.Kp_00,
        /// <summary>
        /// 
        /// </summary>
        Kp_000 = ScanCode.Kp_000,
        /// <summary>
        /// 
        /// </summary>
        Thousandsseparator = ScanCode.Thousandsseparator,
        /// <summary>
        /// 
        /// </summary>
        Decimalseparator = ScanCode.Decimalseparator,
        /// <summary>
        /// 
        /// </summary>
        Currencyunit = ScanCode.Currencyunit,
        /// <summary>
        /// 
        /// </summary>
        Currencysubunit = ScanCode.Currencysubunit,
        /// <summary>
        /// 
        /// </summary>
        KpLeftparen = ScanCode.KpLeftparen,
        /// <summary>
        /// 
        /// </summary>
        KpRightparen = ScanCode.KpRightparen,
        /// <summary>
        /// 
        /// </summary>
        KpLeftbrace = ScanCode.KpLeftbrace,
        /// <summary>
        /// 
        /// </summary>
        KpRightbrace = ScanCode.KpRightbrace,
        /// <summary>
        /// 
        /// </summary>
        KpTab = ScanCode.KpTab,
        /// <summary>
        /// 
        /// </summary>
        KpBackspace = ScanCode.KpBackspace,
        /// <summary>
        /// 
        /// </summary>
        KpA = ScanCode.KpA,
        /// <summary>
        /// 
        /// </summary>
        KpB = ScanCode.KpB,
        /// <summary>
        /// 
        /// </summary>
        KpC = ScanCode.KpC,
        /// <summary>
        /// 
        /// </summary>
        KpD = ScanCode.KpD,
        /// <summary>
        /// 
        /// </summary>
        KpE = ScanCode.KpE,
        /// <summary>
        /// 
        /// </summary>
        KpF = ScanCode.KpF,
        /// <summary>
        /// 
        /// </summary>
        KpXor = ScanCode.KpXor,
        /// <summary>
        /// 
        /// </summary>
        KpPower = ScanCode.KpPower,
        /// <summary>
        /// 
        /// </summary>
        KpPercent = ScanCode.KpPercent,
        /// <summary>
        /// 
        /// </summary>
        KpLess = ScanCode.KpLess,
        /// <summary>
        /// 
        /// </summary>
        KpGreater = ScanCode.KpGreater,
        /// <summary>
        /// 
        /// </summary>
        KpAmpersand = ScanCode.KpAmpersand,
        /// <summary>
        /// 
        /// </summary>
        KpDblampersand = ScanCode.KpDblampersand,
        /// <summary>
        /// 
        /// </summary>
        KpVerticalbar = ScanCode.KpVerticalbar,
        /// <summary>
        /// 
        /// </summary>
        KpDblverticalbar = ScanCode.KpDblverticalbar,
        /// <summary>
        /// 
        /// </summary>
        KpColon = ScanCode.KpColon,
        /// <summary>
        /// 
        /// </summary>
        KpHash = ScanCode.KpHash,
        /// <summary>
        /// 
        /// </summary>
        KpSpace = ScanCode.KpSpace,
        /// <summary>
        /// 
        /// </summary>
        KpAt = ScanCode.KpAt,
        /// <summary>
        /// 
        /// </summary>
        KpExclam = ScanCode.KpExclam,
        /// <summary>
        /// 
        /// </summary>
        KpMemstore = ScanCode.KpMemstore,
        /// <summary>
        /// 
        /// </summary>
        KpMemrecall = ScanCode.KpMemrecall,
        /// <summary>
        /// 
        /// </summary>
        KpMemclear = ScanCode.KpMemclear,
        /// <summary>
        /// 
        /// </summary>
        KpMemadd = ScanCode.KpMemadd,
        /// <summary>
        /// 
        /// </summary>
        KpMemsubtract = ScanCode.KpMemsubtract,
        /// <summary>
        /// 
        /// </summary>
        KpMemmultiply = ScanCode.KpMemmultiply,
        /// <summary>
        /// 
        /// </summary>
        KpMemdivide = ScanCode.KpMemdivide,
        /// <summary>
        /// 
        /// </summary>
        KpPlusminus = ScanCode.KpPlusminus,
        /// <summary>
        /// 
        /// </summary>
        KpClear = ScanCode.KpClear,
        /// <summary>
        /// 
        /// </summary>
        KpClearentry = ScanCode.KpClearentry,
        /// <summary>
        /// 
        /// </summary>
        KpBinary = ScanCode.KpBinary,
        /// <summary>
        /// 
        /// </summary>
        KpOctal = ScanCode.KpOctal,
        /// <summary>
        /// 
        /// </summary>
        KpDecimal = ScanCode.KpDecimal,
        /// <summary>
        /// 
        /// </summary>
        KpHexadecimal = ScanCode.KpHexadecimal,

        /// <summary>
        /// 
        /// </summary>
        Lctrl = ScanCode.Lctrl,
        /// <summary>
        /// 
        /// </summary>
        Lshift = ScanCode.Lshift,
        /// <summary>
        /// 
        /// </summary>
        Lalt = ScanCode.Lalt,
        /// <summary>
        /// 
        /// </summary>
        Lgui = ScanCode.Lgui,
        /// <summary>
        /// 
        /// </summary>
        Rctrl = ScanCode.Rctrl,
        /// <summary>
        /// 
        /// </summary>
        Rshift = ScanCode.Rshift,
        /// <summary>
        /// 
        /// </summary>
        Ralt = ScanCode.Ralt,
        /// <summary>
        /// 
        /// </summary>
        Rgui = ScanCode.Rgui,

        /// <summary>
        /// 
        /// </summary>
        Mode = ScanCode.Mode,

        /// <summary>
        /// 
        /// </summary>
        Audionext = ScanCode.Audionext,
        /// <summary>
        /// 
        /// </summary>
        Audioprev = ScanCode.Audioprev,
        /// <summary>
        /// 
        /// </summary>
        Audiostop = ScanCode.Audiostop,
        /// <summary>
        /// 
        /// </summary>
        Audioplay = ScanCode.Audioplay,
        /// <summary>
        /// 
        /// </summary>
        Audiomute = ScanCode.Audiomute,
        /// <summary>
        /// 
        /// </summary>
        Mediaselect = ScanCode.Mediaselect,
        /// <summary>
        /// 
        /// </summary>
        Www = ScanCode.Www,
        /// <summary>
        /// 
        /// </summary>
        Mail = ScanCode.Mail,
        /// <summary>
        /// 
        /// </summary>
        Calculator = ScanCode.Calculator,
        /// <summary>
        /// 
        /// </summary>
        Computer = ScanCode.Computer,
        /// <summary>
        /// 
        /// </summary>
        AcSearch = ScanCode.AcSearch,
        /// <summary>
        /// 
        /// </summary>
        AcHome = ScanCode.AcHome,
        /// <summary>
        /// 
        /// </summary>
        AcBack = ScanCode.AcBack,
        /// <summary>
        /// 
        /// </summary>
        AcForward = ScanCode.AcForward,
        /// <summary>
        /// 
        /// </summary>
        AcStop = ScanCode.AcStop,
        /// <summary>
        /// 
        /// </summary>
        AcRefresh = ScanCode.AcRefresh,
        /// <summary>
        /// 
        /// </summary>
        AcBookmarks = ScanCode.AcBookmarks,

        /// <summary>
        /// 
        /// </summary>
        Brightnessdown = ScanCode.Brightnessdown,
        /// <summary>
        /// 
        /// </summary>
        Brightnessup = ScanCode.Brightnessup,
        /// <summary>
        /// 
        /// </summary>
        Displayswitch = ScanCode.Displayswitch,
        /// <summary>
        /// 
        /// </summary>
        Kbdillumtoggle = ScanCode.Kbdillumtoggle,
        /// <summary>
        /// 
        /// </summary>
        Kbdillumdown = ScanCode.Kbdillumdown,
        /// <summary>
        /// 
        /// </summary>
        Kbdillumup = ScanCode.Kbdillumup,
        /// <summary>
        /// 
        /// </summary>
        Eject = ScanCode.Eject,
        /// <summary>
        /// 
        /// </summary>
        Sleep = ScanCode.Sleep,
        /// <summary>
        /// 
        /// </summary>
        App1 = ScanCode.App1,
        /// <summary>
        /// 
        /// </summary>
        App2 = ScanCode.App2,

        /// <summary>
        /// 
        /// </summary>
        Audiorewind = ScanCode.Audiorewind,
        /// <summary>
        /// 
        /// </summary>
        Audiofastforward = ScanCode.Audiofastforward
    }
}
