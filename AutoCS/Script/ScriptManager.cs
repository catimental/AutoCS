using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCS.Client.Constants;

namespace AutoCS.Client.Script
{
    public sealed class ScriptManager
    {
        private List<Script> _scripts = new List<Script>();
        private static readonly Lazy<ScriptManager> _instance = new Lazy<ScriptManager>(() => new ScriptManager()); // lazyEvalution Singleton

        private ScriptManager() //private Constructor
        {
            foreach(var scriptFile in DirectoryConstants.ScriptDirectoryInfo.GetFiles())
            {
                if (Path.GetExtension(scriptFile.Name).Equals(DirectoryConstants.ScriptSubFix))
                {
                    _scripts.Add(new Script(scriptFile.Name, scriptFile.FullName));
                }
            }
        } 

        public static ScriptManager Instance
        {
            get { return _instance.Value; }
        }

        public List<Script> GetScripts()
        {
            return this._scripts;
        }
        
        public Script GetScript(string scriptName)
        {
            return this._scripts.Find(script => script.Name.Equals(scriptName));
        }
    }
}
