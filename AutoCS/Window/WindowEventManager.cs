using System;
using AutoCS.Client.Library;
using AutoCS.Client.Profile;

namespace AutoCS.Client.Window
{
    public class WindowEventManager
    {
        private static readonly Lazy<WindowEventManager> _instance =
            new Lazy<WindowEventManager>(() => new WindowEventManager());

        public static WindowEventManager Instance => _instance.Value;
        
        
        private GlobalKeyboardHook _globalKeyboardHook;

        public WindowEventManager()
        {
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                OnKeyDown(sender, e);
            }
            else
            {
                OnKeyUp(sender, e);
            }

            var foreGroundProcessId = WindowManager.Instance.GetPoreGroundProcess().Id;
            foreach(var profile in ProfileManager.Instance.GetProfileList())
            {
                if (profile.IsRunning())
                {
                    if (profile.GetInternalProcess().Process.Id == foreGroundProcessId)
                    {
                        profile.GetScriptEnvironment().OnKeyPressed(sender, e);    
                    }
                }
            }
        }

        private void OnKeyDown(object sender, GlobalKeyboardHookEventArgs e)
        {
            //Console.WriteLine(e.KeyboardData.Key + " down");
        }

        private void OnKeyUp(object sender, GlobalKeyboardHookEventArgs e)
        {
            //Console.WriteLine(e.KeyboardData.Key + " up");
        }
    }
}