using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoCS.Client.Window
{
    public class Keyboard
    {
        #region Function Imports
 
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
 
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
 
        #endregion
 
        #region Constants
 
        // Messages
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CHAR = 0x105;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
 
        #endregion
 
        public static void SendKey(string wName, Keys key)
        {
            IntPtr hWnd = FindWindow(null, wName);

            SendKey(hWnd, key);
        }        
        
        public static void SendKey(IntPtr handle, Keys key)
        {
            SendMessage(handle, WM_KEYDOWN, Convert.ToInt32(key), 0);
            SendMessage(handle, WM_KEYUP, Convert.ToInt32(key), 0);
        }

        public static void SendSysKey(string wName, Keys key)
        {
            IntPtr hWnd = FindWindow(null, wName);
 
            SendMessage(hWnd, WM_SYSKEYDOWN, Convert.ToInt32(key), 0);
            SendMessage(hWnd, WM_SYSKEYUP, Convert.ToInt32(key), 0);
        }
 
        public static void SendChar(string wName, char c)
        {
            IntPtr hWnd = FindWindow(null, wName);

            SendChar(hWnd, c);
        }

        public static void SendChar(IntPtr handle, char c)
        {
            SendMessage(handle, WM_CHAR, (int)c, 0);
        }
    }
}