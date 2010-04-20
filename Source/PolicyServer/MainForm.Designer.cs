namespace FluorineFxPolicyServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._groupBoxUsage = new System.Windows.Forms.GroupBox();
            this._groupBoxHistory = new System.Windows.Forms.GroupBox();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._usageHistoryControl = new FluorineFxPolicyServer.Control.UsageHistoryControl();
            this._usageControl = new FluorineFxPolicyServer.Control.UsageControl();
            this._groupBoxUsage.SuspendLayout();
            this._groupBoxHistory.SuspendLayout();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBoxUsage
            // 
            this._groupBoxUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._groupBoxUsage.Controls.Add(this._usageControl);
            this._groupBoxUsage.Location = new System.Drawing.Point(12, 12);
            this._groupBoxUsage.Name = "_groupBoxUsage";
            this._groupBoxUsage.Size = new System.Drawing.Size(54, 176);
            this._groupBoxUsage.TabIndex = 2;
            this._groupBoxUsage.TabStop = false;
            this._groupBoxUsage.Text = "Usage";
            // 
            // _groupBoxHistory
            // 
            this._groupBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBoxHistory.Controls.Add(this._usageHistoryControl);
            this._groupBoxHistory.Location = new System.Drawing.Point(84, 12);
            this._groupBoxHistory.Name = "_groupBoxHistory";
            this._groupBoxHistory.Size = new System.Drawing.Size(306, 176);
            this._groupBoxHistory.TabIndex = 3;
            this._groupBoxHistory.TabStop = false;
            this._groupBoxHistory.Text = "Policy Server Usage History";
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.ContextMenuStrip = this._contextMenuStrip;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "FluorineFx Silverlight Policy Server";
            this._notifyIcon.Visible = true;
            this._notifyIcon.DoubleClick += new System.EventHandler(this._notifyIcon_DoubleClick);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // _usageHistoryControl
            // 
            this._usageHistoryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._usageHistoryControl.BackColor = System.Drawing.Color.Black;
            this._usageHistoryControl.Location = new System.Drawing.Point(6, 19);
            this._usageHistoryControl.Maximum = 100;
            this._usageHistoryControl.Name = "_usageHistoryControl";
            this._usageHistoryControl.Size = new System.Drawing.Size(294, 151);
            this._usageHistoryControl.TabIndex = 1;
            // 
            // _usageControl
            // 
            this._usageControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._usageControl.BackColor = System.Drawing.Color.Black;
            this._usageControl.Location = new System.Drawing.Point(6, 19);
            this._usageControl.Maximum = 100;
            this._usageControl.Name = "_usageControl";
            this._usageControl.Size = new System.Drawing.Size(41, 151);
            this._usageControl.TabIndex = 0;
            this._usageControl.Value1 = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 200);
            this.Controls.Add(this._groupBoxHistory);
            this.Controls.Add(this._groupBoxUsage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 230);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "FluorineFx Silverlight Policy Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._groupBoxUsage.ResumeLayout(false);
            this._groupBoxHistory.ResumeLayout(false);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FluorineFxPolicyServer.Control.UsageControl _usageControl;
        private FluorineFxPolicyServer.Control.UsageHistoryControl _usageHistoryControl;
        private System.Windows.Forms.GroupBox _groupBoxUsage;
        private System.Windows.Forms.GroupBox _groupBoxHistory;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

