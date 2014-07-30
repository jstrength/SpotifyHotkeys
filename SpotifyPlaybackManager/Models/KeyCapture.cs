using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using SpotifyPlaybackManager.Enums;
using SpotifyPlaybackManager.Interfaces;

namespace SpotifyPlaybackManager.Models
{
    public class KeyCapture
    {
        private readonly IKeyHandler _keyHandler;
        private const int WH_KEYBOARD_LL = 13;
        private static LowLevelKeyboardProc _proc;
        private static IntPtr _hookId = IntPtr.Zero;

        public KeyCapture(IKeyHandler keyHandler)
        {
            _keyHandler = keyHandler;
            _proc = HookCallback;
            HookKeys();
        }

        public void HookKeys()
        {
            _hookId = SetHook();
        }

        public void UnHookKeys()
        {
            UnhookWindowsHookEx(_hookId);
        }

        private static IntPtr SetHook()
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, _proc,
                                        GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr) WmCodes.WM_KEYDOWN)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                _keyHandler.HandleKeyDown(ResolveKey(vkCode));
            }
            else if (nCode >= 0 && wParam == (IntPtr) WmCodes.WM_KEYUP)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                _keyHandler.HandleKeyUp(ResolveKey(vkCode));
            }
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private static Key ResolveKey(int charToResolve)
        {
            return KeyInterop.KeyFromVirtualKey(charToResolve);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
                                                      LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                                                    IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}