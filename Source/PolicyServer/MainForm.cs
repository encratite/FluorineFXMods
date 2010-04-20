using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FluorineFx.Silverlight;
using log4net;

namespace FluorineFxPolicyServer
{
    public partial class MainForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        PolicyServer _policyServer;

        public MainForm()
        {
            InitializeComponent();
#if MONO
			this.MinimizeBox = true;
			this.ShowInTaskbar = true;
#endif
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _usageControl.Maximum = 10;
            _usageHistoryControl.Maximum = 10;
            _policyServer = new PolicyServer("clientaccesspolicy.xml");
            _policyServer.Connect += new ConnectHandler(_policyServer_Connect);
            _policyServer.Disconnect += new DisconnectHandler(_policyServer_Disconnect);
            _timer.Enabled = true;
        }

        void _policyServer_Disconnect(object sender, DisconnectEventArgs e)
        {
            this.BeginInvoke(new DecreaseUsageDelegate(DecreaseUsage));
        }

        void _policyServer_Connect(object sender, ConnectEventArgs e)
        {
            this.BeginInvoke(new IncreaseUsageDelegate(IncreaseUsage));
        }

        delegate void IncreaseUsageDelegate();
        delegate void DecreaseUsageDelegate();

        void IncreaseUsage()
        {
            _usageControl.Value1++;
            _usageHistoryControl.AddValue(_usageControl.Value1);
        }

        void DecreaseUsage()
        {
            _usageControl.Value1--;
            _usageHistoryControl.AddValue(_usageControl.Value1);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _usageHistoryControl.AddValue(_usageControl.Value1);
        }

        public void HideApp()
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
        }

        public void ShowApp()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
#if !MONO			
            // method overidden so the form can be minimized, instead of closed
            if (this.Visible == true)
            {
                e.Cancel = true;
                // let's minimize the form, and hide it
                this.WindowState = FormWindowState.Minimized;
                Hide();
            }
            // otherwise, let the framework close the app
#else
            _policyServer.Close();
			base.OnClosing(e);
#endif
        }

        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowApp();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false; // hide icon from the systray
            _policyServer.Close();
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowApp();
        }

    }
}