using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCS.Client.Constants;
using AutoCS.Client.Profile;
using AutoCS.Client.Script;
using AutoCS.Client.Window;
using MetroFramework.Controls;

namespace AutoCS.Client.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += OnMainFormLoad;
            this.Closing += OnMainFormClosing;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            DirectoryConstants.InitializeDirectory();
            var windowEventManager = WindowEventManager.Instance; // 왜 lazyEvalution 처리했을까 귀찮너
            var profileManager = ProfileManager.Instance; // 아이고 귀찮너..
            
            foreach (var profile in profileManager.GetProfileList())
            {
                InitializeProfileTabPage(profile);    
            }
        }

        private void OnMainFormClosing(object sender, CancelEventArgs e)
        {
            var profileManager = ProfileManager.Instance;
            int index = 0;
            foreach (var profile in profileManager.GetProfileList())
            {
                if (profile.IsRunning()) // dispoingWorks
                {
                    profile.DisposeScript();
                }
                
                Profile.Profile.ExportToJson(profile, index.ToString());
                index++;
            }
        }
        
        private void createNewProfileButton_Click(object sender, EventArgs e)
        {
            var profile = new Profile.Profile();            
            profile.ProfileName = "새 프로필";
            InitializeProfileTabPage(profile);
            ProfileManager.Instance.AddProfile(profile);
        }

        private void InitializeProfileTabPage(Profile.Profile profile)
        {
            var tabPage = new MetroTabPage();
            tabPage.Text = profile.ProfileName;
            
            foreach (var formControl in profile.GetFormControls())
            {
                tabPage.Controls.Add(formControl);                
            }
            metroTabControl1.TabPages.Add(tabPage);
        }
    }
}
