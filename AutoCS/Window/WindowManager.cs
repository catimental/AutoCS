using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace AutoCS.Client.Window
{
    public class WindowManager
    {
        private static readonly Lazy<WindowManager> _instance =
            new Lazy<WindowManager>(() => new WindowManager());
        private Process[] _processes;
        public static WindowManager Instance => _instance.Value;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        
        public WindowManager()
        {
            UpdateProcesses();
        }

        public void UpdateProcesses()
        {
            _processes = Process.GetProcesses();
        }
        
        public Process[] GetProcesses()
        {
            return GetProcesses((process) => true);
        }

        public Process[] GetProcesses(Predicate<Process> composer)
        {
            var query = from process in _processes
                where composer(process)
                select process;
            return query.ToArray();
        }

        public Process GetPoreGroundProcess()
        {
            var handle = GetForegroundWindow();
            uint processId;
            GetWindowThreadProcessId(handle, out processId);
            return Process.GetProcessById((int) processId);
        }
        
        
    }
}