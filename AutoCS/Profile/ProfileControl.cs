using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
//using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using AutoCS.Client.Script;
using AutoCS.Client.Window;
using MetroFramework.Controls;
using MetroFramework.Drawing.Html;

namespace AutoCS.Client.Profile
{
    public partial class ProfileControl
    {
        private Profile _profile;
        public ProfileControl(Profile profile)
        {
            _profile = profile;
            InitializeComponent();
            toggleButton.Click += OnToggleButtonClick;
            processNameTextBox.TextChanged += OnProcessNameTextBoxTextChanged;
            processListListView.SelectedIndexChanged += OnProcessListListViewSelectedIndexChanged;
        }

        private void OnToggleButtonClick(object sender, EventArgs args)
        {
            var scriptManager = ScriptManager.Instance;
            if (_profile.IsRunning() == false)
            {
                _profile.ClearScripts();
                foreach (ListViewItem item in scriptListView.Items)
                {
                    if (item.Checked)
                    {
                        _profile.AddScript(scriptManager.GetScript(item.SubItems[1].Text));        
                    }
                }
                _profile.RunScript();   
            }
            else
            {
                _profile.DisposeScript();
            }
        }

        private void OnProcessNameTextBoxTextChanged(object sender, EventArgs args)
        {
            if ((sender as MetroTextBox).Text.Equals(String.Empty))
            {
                UpdateProcessListView(true);
            }
            else
            {
                UpdateProcessListView(false);
            }
        }

        private void OnProcessListListViewSelectedIndexChanged(object sender, EventArgs args)
        {
            if (processListListView.SelectedIndices.Count > 0) // changed
            {
                string processTitleName = processListListView.SelectedItems[0].Text; 
               _profile.SetInternalProcess(WindowManager.Instance.GetProcesses(process => process.MainWindowTitle.Equals(processTitleName))[0]);
               WriteLog(_profile.GetInternalProcess().Process.MainWindowTitle+" 프로세스 선택됌");
            }
        }
        
        private void scriptListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if ((e.ColumnIndex == 0))
            {
                CheckBox cck = new CheckBox();
                //Text = "";       
                scriptListView.SuspendLayout();  // 컨트롤의 레이아웃 논리를 임시로 일시 중단
                e.DrawBackground();  // 열 머리글의 배경색을 그리기
                cck.BackColor = Color.Transparent;
                cck.UseVisualStyleBackColor = true;  // 비주얼 스타일을 사용하여 배경을 그리면 true

                // 컨트롤의 범위를 지정된 위치와 크기로 설정 (Left x, Top y, width, height)
                cck.SetBounds(e.Bounds.X, e.Bounds.Y, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);

                // 컨트롤의 높이와 너비를 가져오거나 설정

                cck.Size = new Size((cck.GetPreferredSize(new Size((e.Bounds.Width - 1), e.Bounds.Height)).Width + 1), e.Bounds.Height);
                cck.Location = new Point(4, 0); // 왼쪽 위를 기준으로 컨트롤의 왼쪽 위의 좌표를 가져오거나 설정
                scriptListView.Controls.Add(cck);
                cck.Show();
                //cck.BringToFront();
                //Visible = true;  // 컨트롤과 모든 해당 자식 컨트롤이 표시되면 true

                e.DrawText((TextFormatFlags.VerticalCenter | TextFormatFlags.Left));
                cck.Click += new EventHandler(Bink);  // 컨트롤을 클릭하면 발생
                scriptListView.ResumeLayout(true);  // 일반 레이아웃 논리를 다시 시작

            }
            else
            {
                e.DrawDefault = true;
            }
        }
        private void Bink(object sender, System.EventArgs e)
        {
            CheckBox cck = sender as CheckBox;
            for (int i = 0; i < scriptListView.Items.Count; i++)
            {
                scriptListView.Items[i].Checked = cck.Checked;
            }
        }

        private void scriptListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void scriptListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }        
        
        public void UpdateControls()
        {
            UpdateScriptListView();
            UpdateProcessListView(true);
        }

        public void UpdateScriptListView()
        {
            scriptListView.Items.Clear();
            ScriptManager scriptManager = ScriptManager.Instance;
            
            foreach (var script in scriptManager.GetScripts())
            {
                ListViewItem lvt = new ListViewItem();
                lvt.SubItems.Add(script.Name);
                scriptListView.Items.Add(lvt);
            }
        }
        
        public void UpdateProcessListView(bool forceUpdateProcessList)
        {
            processListListView.Items.Clear();
            WindowManager windowManager = WindowManager.Instance;
            if (forceUpdateProcessList)
            {
                Console.WriteLine("ProcessList Updated!");
                windowManager.UpdateProcesses();
            }
            
            foreach (var process in windowManager.GetProcesses((process => process.MainWindowTitle.Equals(string.Empty) == false)))
            {
                if (this.processNameTextBox.Text.Equals(string.Empty) 
                    || process.MainWindowTitle.Contains(this.processNameTextBox.Text))
                {
                    var lvt = new ListViewItem(process.MainWindowTitle);
                    lvt.SubItems.Add(process.MainWindowTitle);
                    processListListView.Items.Add(lvt);                    
                }

            }
        }
        
        public Control[] GetControls()
        {
            return _controls.ToArray();
        }

        public void WriteLog(string log)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action(()=>logTextBox.AppendText(log + "\r\n")));    
            }
            else
            {
                logTextBox.AppendText(log + "\r\n");
            }
        }

        public string GetMainTitleName()
        {
            return processNameTextBox.Text; // 이거 이름 바꿔야할 듯
        }

        public void SetMainTitleName(string name)
        {
            processNameTextBox.Text = name;
        }

        public void SelectScript(string scriptName)
        {
            UpdateScriptListView();
            foreach (ListViewItem item in scriptListView.Items)
            {
                Console.WriteLine(item.SubItems[1].Text);
                if (item.SubItems[1].Text.Equals(scriptName))
                {
                    item.Checked = true;
                }
            }
        }
    }
}