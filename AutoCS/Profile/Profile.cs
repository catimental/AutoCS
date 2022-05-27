using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCS.Client.Constants;
using AutoCS.Client.Forms;
using AutoCS.Client.Script;
using AutoCS.Client.Script.Conversations;
using AutoCS.Client.Window;
using Jint;
using Jint.Native;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Control = System.Windows.Forms.Control;

namespace AutoCS.Client.Profile
{
    public class Profile
    {
        
        private List<Script.Script> applyScriptList = new List<Script.Script>();
        private ScriptEnvironment _scriptEnvironment;
        private ProfileControl _profileControl;
        private InternalProcess _internalProcess;
        public string ProcessName
        {
            get;
            set;
        }

        public string ProfileName
        {
            get;
            set;
        }

        public Profile()
        {
            _profileControl = new ProfileControl(this);
            _scriptEnvironment = new ScriptEnvironment(this);
        }

        public void RunScript()
        {
            GetScriptEnvironment().RunScript(applyScriptList);
        }

        public void DisposeScript()
        {
            GetScriptEnvironment().DisposeScript();
        }

        public bool IsRunning()
        {
            return GetScriptEnvironment().IsRunning;
        }
        public ScriptEnvironment GetScriptEnvironment()
        {
            return _scriptEnvironment;
        }

        public void ClearScripts()
        {
            applyScriptList.Clear();
        }
        public void AddScript(Script.Script script)
        {
            //todo 다시짜기
            if (!IsRunning() && !applyScriptList.Exists(appliedScript => script.Equals(appliedScript)))
            {
                applyScriptList.Add(script);    
            }
        }

        public static void ExportToJson(Profile profile, string jsonName)
        {
            File.WriteAllText(DirectoryConstants.ProfileDirectoryInfo.FullName+jsonName+".json", profile.Serialize());
        }

        public static List<Profile> ImportAll()
        {
            string[] profileNames = DirectoryConstants.GetFilesNameFromPath(DirectoryConstants.ProfileDirectoryInfo);
            var profiles = new List<Profile>();
            foreach (var profileName in profileNames)
            {
                profiles.Add(ImportFromJson(profileName));
            }

            return profiles;
        }
        
        public static Profile ImportFromJson(string fileName)
        {
            Profile profile = new Profile();
            string path = DirectoryConstants.ProfileDirectoryInfo.FullName + '\\' + fileName;
            using(StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject json = (JObject) JToken.ReadFrom(reader);
                profile.ProcessName = json["MainTitleName"]?.ToString();
                profile.ProfileName = json["ProfileName"]?.ToString();
                profile._profileControl.SetMainTitleName(json["MainTitleName"]?.ToString());
                
                var scripts = json.SelectToken("scripts");
                foreach (var script in scripts)
                {
                    profile._profileControl.SelectScript(script["Name"].ToString());
                }
            }
            return profile;
        }
        
        private string Serialize()
        {
            JObject profileSpec = new JObject(
                new JProperty("MainTitleName", this._profileControl.GetMainTitleName()),
                new JProperty("ProfileName", this.ProfileName)
            );
            profileSpec.Add("scripts", JArray.FromObject(this.applyScriptList));
            return profileSpec.ToString();
        }

        public override string ToString()
        {
            return ProfileName;
        }

        public Control[] GetFormControls()
        {
            _profileControl.UpdateControls();
            return _profileControl.GetControls();
        }

        public void WriteLog(string log)
        {
            _profileControl.WriteLog(log);
        }

        public void SetInternalProcess(Process process)
        {
            _internalProcess = new InternalProcess(process);
        }
        
        public InternalProcess GetInternalProcess()
        {
            return _internalProcess;
        }
    }
}
