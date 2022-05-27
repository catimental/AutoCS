
using System.Windows.Forms;

namespace AutoCS.Client.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.createNewProfileButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Location = new System.Drawing.Point(24, 51);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Size = new System.Drawing.Size(675, 290);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // createNewProfileButton
            // 
            this.createNewProfileButton.Location = new System.Drawing.Point(759, 50);
            this.createNewProfileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNewProfileButton.Name = "createNewProfileButton";
            this.createNewProfileButton.Size = new System.Drawing.Size(93, 18);
            this.createNewProfileButton.TabIndex = 1;
            this.createNewProfileButton.Text = "새 프로필 추가";
            this.createNewProfileButton.UseSelectable = true;
            this.createNewProfileButton.Click += new System.EventHandler(this.createNewProfileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 359);
            this.Controls.Add(this.createNewProfileButton);
            this.Controls.Add(this.metroTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 16);
            this.Text = "AutoCS";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroButton createNewProfileButton;
    }
}