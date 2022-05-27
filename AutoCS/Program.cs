using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCS.Client.Constants;
using AutoCS.Client.Forms;
using AutoCS.Client.Profile;
using AutoCS.Client.Script;
using AutoCS.Client.Window;

namespace AutoCS.Client
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*ScriptManager manager = ScriptManager.Instance;
            WindowEventManager windowEventManager = WindowEventManager.Instance;
            Profile.Profile testProfile = new Profile.Profile();
            testProfile.ProcessName = "notepad.exe";
            testProfile.ProfileName = "테스트a";
            testProfile.TabIndex = 1;
            foreach (var script in manager.GetScripts())
            {
                testProfile.AddScript(script);
            }

            
            ProfileManager.Instance.AddProfile(testProfile);
            testProfile.RunScript();
            Profile.Profile.ExportToJson(testProfile);
            Profile.Profile.ImportAll();*/
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new MainForm());
            
        }
    }
}
