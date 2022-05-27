using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetroFramework.Controls;

namespace AutoCS.Client.Profile
{
    partial class ProfileControl
    {
        private List<Control> _controls = new List<Control>();
        private MetroTextBox logTextBox = new MetroTextBox();
        private MetroLabel logLabel = new MetroLabel();
        private MetroButton toggleButton = new MetroButton();
        private MetroListView scriptListView = new MetroListView();
        private MetroLabel scriptLabel = new MetroLabel();
        private MetroListView processListListView = new MetroListView();
        private MetroLabel processNameLabel = new MetroLabel();
        private MetroTextBox processNameTextBox = new MetroTextBox();
        private ColumnHeader cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        private ColumnHeader scriptName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        private void InitializeComponent()
        { 
            this.logTextBox.CustomButton.Image = null;
            this.logTextBox.CustomButton.Location = new System.Drawing.Point(7, 2);
            this.logTextBox.CustomButton.Name = "";
            this.logTextBox.CustomButton.Size = new System.Drawing.Size(129, 129);
            this.logTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.logTextBox.CustomButton.TabIndex = 1;
            this.logTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.logTextBox.CustomButton.UseSelectable = true;
            this.logTextBox.CustomButton.Visible = false;
            this.logTextBox.Lines = new string[0];
            this.logTextBox.Location = new System.Drawing.Point(503, 84);
            this.logTextBox.MaxLength = 32767;
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.PasswordChar = '\0';
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.logTextBox.SelectedText = "";
            this.logTextBox.SelectionLength = 0;
            this.logTextBox.SelectionStart = 0;
            this.logTextBox.ShortcutsEnabled = true;
            this.logTextBox.Size = new System.Drawing.Size(139, 134);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.UseSelectable = true;
            this.logTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.logTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            _controls.Add(logTextBox);
            
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(460, 84);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(37, 19);
            this.logLabel.TabIndex = 1;
            this.logLabel.Text = "로그";
            _controls.Add(logLabel);
            
            this.toggleButton.Location = new System.Drawing.Point(22, 33);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(75, 23);
            this.toggleButton.TabIndex = 2;
            this.toggleButton.Text = "start/stop";
            this.toggleButton.UseSelectable = true;
            _controls.Add(toggleButton);

            this.scriptListView.View = View.Details;
            this.scriptListView.CheckBoxes = true;
            this.scriptListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.cck,
                this.scriptName});
            this.scriptListView.OwnerDraw = true;
            this.scriptListView.HideSelection = false;
            this.scriptListView.Location = new System.Drawing.Point(317, 84);
            this.scriptListView.Name = "scriptListView";
            this.scriptListView.Size = new System.Drawing.Size(133, 134);
            this.scriptListView.TabIndex = 8;
            this.scriptListView.UseCompatibleStateImageBehavior = false;
            this.scriptListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.scriptListView_DrawColumnHeader);
            this.scriptListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.scriptListView_DrawItem);
            this.scriptListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.scriptListView_DrawSubItem);         
            _controls.Add(scriptListView);
            
            this.scriptLabel.AutoSize = true;
            this.scriptLabel.Location = new System.Drawing.Point(246, 84);
            this.scriptLabel.Name = "scriptLabel";
            this.scriptLabel.Size = new System.Drawing.Size(65, 19);
            this.scriptLabel.TabIndex = 4;
            this.scriptLabel.Text = "스크립트";
            _controls.Add(scriptLabel);
            
            //this.processListListView.View = View.Details;
            this.processListListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.processListListView.FullRowSelect = true;
            this.processListListView.Location = new System.Drawing.Point(127, 113);
            this.processListListView.Name = "processListListView";
            this.processListListView.OwnerDraw = true;
            this.processListListView.Size = new System.Drawing.Size(109, 105);
            this.processListListView.TabIndex = 5;
            this.processListListView.UseCompatibleStateImageBehavior = false;
            this.processListListView.UseSelectable = true;
            _controls.Add(processListListView);
            
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(22, 84);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(97, 19);
            this.processNameLabel.TabIndex = 6;
            this.processNameLabel.Text = "프로세스 이름";
            _controls.Add(processNameLabel);
            
            this.processNameTextBox.CustomButton.Image = null;
            this.processNameTextBox.CustomButton.Location = new System.Drawing.Point(87, 1);
            this.processNameTextBox.CustomButton.Name = "";
            this.processNameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.processNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.processNameTextBox.CustomButton.TabIndex = 1;
            this.processNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.processNameTextBox.CustomButton.UseSelectable = true;
            this.processNameTextBox.CustomButton.Visible = false;
            this.processNameTextBox.Lines = new string[0];
            this.processNameTextBox.Location = new System.Drawing.Point(127, 84);
            this.processNameTextBox.MaxLength = 32767;
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.PasswordChar = '\0';
            this.processNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.processNameTextBox.SelectedText = "";
            this.processNameTextBox.SelectionLength = 0;
            this.processNameTextBox.SelectionStart = 0;
            this.processNameTextBox.ShortcutsEnabled = true;
            this.processNameTextBox.Size = new System.Drawing.Size(109, 23);
            this.processNameTextBox.TabIndex = 7;
            this.processNameTextBox.UseSelectable = true;
            this.processNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.processNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);            
            _controls.Add(processNameTextBox);
            
            this.cck.Text = "";

            this.scriptName.Text = "이름";
        }
    }
}