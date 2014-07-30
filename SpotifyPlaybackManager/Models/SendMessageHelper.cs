using System;
using System.Runtime.InteropServices;
using SpotifyPlaybackManager.Enums;

namespace SpotifyPlaybackManager.Models
{
    class SendMessageHelper
    {
        public static void SendControlKey(IntPtr hwnd, IntPtr key)
        {
            var input = new INPUT();
            input.type = INPUT_KEYBOARD;
            var inputSize = Marshal.SizeOf(input);
            input.mkhi.ki.wVk = VK_CONTROL;

            //Keys DOWN
            var isKeyDown = (GetAsyncKeyState(VK_CONTROL) & 0x10000) != 0;

            if (!isKeyDown)
                SendInput(1, ref input, inputSize);
            SendMessage(hwnd, (uint) WmCodes.WM_KEYDOWN, key, IntPtr.Zero);

            //Keys UP
            input.mkhi.ki.dwFlags = KEYEVENTF_KEYUP;
            SendInput(1, ref input, inputSize);
            SendMessage(hwnd, (uint) WmCodes.WM_KEYUP, key, IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(ushort vKey);

        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        struct INPUT
        {
            public int type;
            public MOUSEKEYBDHARDWAREINPUT mkhi;
        }

        const int INPUT_KEYBOARD = 1;
        const uint KEYEVENTF_KEYUP = 0x0002;

        const ushort VK_SHIFT = 0x10;
        const ushort VK_CONTROL = 0x11;
        const ushort VK_MENU = 0x12;
    }
}
