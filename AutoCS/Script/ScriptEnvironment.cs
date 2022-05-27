using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using AutoCS.Client.Constants;
using AutoCS.Client.Library;
using AutoCS.Client.Script.Conversations;
using Jint;
using Jint.Native;

namespace AutoCS.Client.Script
{
    public class ScriptEnvironment
    {
        private Engine _scriptEngine = null;
        private List<JsValue> _onTicks = new List<JsValue>();
        private List<JsValue> _onKeyPresses = new List<JsValue>();
        private Thread _onTickThread;
        private object lockObject = new object();
        private Profile.Profile _profile;
        public bool IsRunning
        {
            get { return _scriptEngine != null; }
        }

        
        public ScriptEnvironment(Profile.Profile profile)
        {
            _profile = profile;
        }
        
        public void RunScript(IEnumerable<Script> scripts)
        {
            _scriptEngine = new Engine();
            //binding class With Attributes
            var types =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsDefined(typeof(ConversationAttribute), false)
                select new {Type = type, ScopeName = (type.GetCustomAttribute(typeof(ConversationAttribute), false) as ConversationAttribute)?.ScopeName};
            
            foreach (var type in types)
            {
                _scriptEngine.SetValue(type.ScopeName, Activator.CreateInstance(type.Type));
            }

            _scriptEngine.SetValue("Logger", new Logger(_profile));
            _scriptEngine.SetValue("Keyboard", new Keyboard(_profile));

            foreach (var script in scripts)
            {
                string scriptBody = System.IO.File.ReadAllText(script.Path);
                _scriptEngine.Execute(scriptBody);
                registScriptEvent();
            }

            if (_onTicks.Count > 0)
            {
                _onTickThread = new Thread(() =>
                {
                    while (true)
                    {
                        lock (lockObject)
                        {
                            _onTicks.ForEach(onTick => onTick.Invoke());
                            Thread.Sleep(0); //contextSwitching
                        }
                    }
                });
                _onTickThread.Priority = ThreadPriority.AboveNormal;
                _onTickThread.Start();
            }
        }

        public void DisposeScript()
        {
            if (_scriptEngine != null)
            {
                _onTickThread.Abort();
                _onTickThread.Join();
                _scriptEngine = null;

                _onTicks.Clear();
                _onKeyPresses.Clear();
            }
        }

        private void registScriptEvent()
        {
            var onTick = _scriptEngine.GetValue(ScriptConstants.EVENT_ONTICK);
            if (!onTick.IsUndefined())
            {
                _onTicks.Add(onTick);
            }
            
            var onKeyPress = _scriptEngine.GetValue(ScriptConstants.EVENT_ONKEYPRESS);
            if (!onKeyPress.IsUndefined())
            {
                onKeyPress.Invoke();
                _onKeyPresses.Add(onKeyPress);
            }
            var onLoad = _scriptEngine.GetValue(ScriptConstants.EVENT_ONLOAD);
            if (!onLoad.IsUndefined())
            {
                onLoad.Invoke();
            }
        }

        public void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e) // 간단하게 짰음
        {
            lock (lockObject)
            {
                if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown) // 임시로 키다운시에만 작동하게 픽스
                {
                    _onKeyPresses.ForEach(onKeyPress => onKeyPress.Invoke(e.KeyboardData.Key.ToString()));    
                }
            }
        }
    }
}
