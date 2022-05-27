using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoCS.Client.Window
{
    public class InternalProcess
    {
        private Process _process;
        public Process Process
        {
            get => _process;
        }
        public InternalProcess(Process process)
        {
            _process = process;
        }

        public void KeyPress(Keys key)
        {
            Keyboard.SendKey(Process.Handle, key);
        }

        public void KeyPress(char c)
        {
            Console.WriteLine(Process.MainWindowTitle);
            Keyboard.SendChar(Process.MainWindowTitle, c);
            Keyboard.SendChar(Process.MainWindowHandle, c);
            Keyboard.SendChar(Process.Handle, c);
        }
    }
}