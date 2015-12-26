using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PunchClock.Infra
{
    public class ScrollLockInterceptor
    {
        #region Members

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int KEY_SCROLL_LOCK = 145;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        #endregion

        public static void SetHook()
        {
            _hookID = SetHook(_proc);
        }

        public static void UnhookWindowsHookEx()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            {
                using (var curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == KEY_SCROLL_LOCK && _scrollLockChange != null)
                {
                    var scrollLockOn = Control.IsKeyLocked(Keys.Scroll);
                    _scrollLockChange(null, new ScrollLockChangeEventArgs(scrollLockOn));
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static void InvokeScrollLockChange()
        {
            if (_scrollLockChange != null)
            {
                var scrollLockOn = Control.IsKeyLocked(Keys.Scroll);
                _scrollLockChange(null, new ScrollLockChangeEventArgs(scrollLockOn));
            }
        }

        private static event EventHandler<ScrollLockChangeEventArgs> _scrollLockChange;
        public static event EventHandler<ScrollLockChangeEventArgs> ScrollLockChange
        {
            add { _scrollLockChange += value; }
            remove { _scrollLockChange -= value; }
        }

        #region Dll Imports

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }

    public class ScrollLockChangeEventArgs : EventArgs
    {
        public ScrollLockChangeEventArgs(bool isOn)
        {
            IsOn = isOn;
        }

        public bool IsOn { get; set; }
    }
}