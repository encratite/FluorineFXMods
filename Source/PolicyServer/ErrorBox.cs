using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FluorineFxPolicyServer
{
	/// <summary>
	/// Represents the form that that displays an exception.
	/// </summary>
	public class ErrorBox : System.Windows.Forms.Form
	{
		private string _error = string.Empty;	
		private string _detailedError = string.Empty;
		private Size _smallSize = new Size(520, 280);
		private Size _largeSize = new Size(520, 450);
		private bool _showingDetails = false;
		private string _feedbackText = "<Please provide your feedback here. (optional)>";

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RichTextBox richTextBoxDetails;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonDetails;
		private System.Windows.Forms.Button buttonSendSupport;
		private System.Windows.Forms.Button _buttonExit;
		private System.Windows.Forms.Label _labelInfoConf;
		private System.Windows.Forms.CheckBox _checkBoxEmailAddress;
		private System.Windows.Forms.TextBox _textBoxEmailAddress;
		private System.Windows.Forms.RichTextBox _richTextBoxFeedback;

		public ErrorBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ErrorBox));
			this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelError = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonDetails = new System.Windows.Forms.Button();
			this.buttonSendSupport = new System.Windows.Forms.Button();
			this._buttonExit = new System.Windows.Forms.Button();
			this._richTextBoxFeedback = new System.Windows.Forms.RichTextBox();
			this._labelInfoConf = new System.Windows.Forms.Label();
			this._checkBoxEmailAddress = new System.Windows.Forms.CheckBox();
			this._textBoxEmailAddress = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// richTextBoxDetails
			// 
			this.richTextBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxDetails.Location = new System.Drawing.Point(16, 240);
			this.richTextBoxDetails.Name = "richTextBoxDetails";
			this.richTextBoxDetails.Size = new System.Drawing.Size(480, 144);
			this.richTextBoxDetails.TabIndex = 3;
			this.richTextBoxDetails.Text = "";
			this.richTextBoxDetails.WordWrap = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// labelError
			// 
			this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelError.Location = new System.Drawing.Point(64, 16);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(438, 40);
			this.labelError.TabIndex = 2;
			this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonClose.Location = new System.Drawing.Point(416, 72);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(80, 24);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			// 
			// buttonDetails
			// 
			this.buttonDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonDetails.Location = new System.Drawing.Point(16, 72);
			this.buttonDetails.Name = "buttonDetails";
			this.buttonDetails.Size = new System.Drawing.Size(136, 24);
			this.buttonDetails.TabIndex = 0;
			this.buttonDetails.Text = "Show Details";
			this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
			// 
			// buttonSendSupport
			// 
			this.buttonSendSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSendSupport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonSendSupport.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonSendSupport.Location = new System.Drawing.Point(160, 72);
			this.buttonSendSupport.Name = "buttonSendSupport";
			this.buttonSendSupport.Size = new System.Drawing.Size(120, 24);
			this.buttonSendSupport.TabIndex = 1;
			this.buttonSendSupport.Text = "Send to support";
			this.buttonSendSupport.Click += new System.EventHandler(this.buttonSendSupport_Click);
			// 
			// _buttonExit
			// 
			this._buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._buttonExit.Location = new System.Drawing.Point(288, 72);
			this._buttonExit.Name = "_buttonExit";
			this._buttonExit.Size = new System.Drawing.Size(120, 24);
			this._buttonExit.TabIndex = 0;
			this._buttonExit.Text = "Exit Application";
			this._buttonExit.Click += new System.EventHandler(this._buttonExit_Click);
			// 
			// _richTextBoxFeedback
			// 
			this._richTextBoxFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._richTextBoxFeedback.Location = new System.Drawing.Point(16, 103);
			this._richTextBoxFeedback.Name = "_richTextBoxFeedback";
			this._richTextBoxFeedback.Size = new System.Drawing.Size(480, 41);
			this._richTextBoxFeedback.TabIndex = 4;
			this._richTextBoxFeedback.Text = "<Please provide your feedback here. (optional)>";
			this._richTextBoxFeedback.WordWrap = false;
			this._richTextBoxFeedback.Leave += new System.EventHandler(this._richTextBoxFeedback_Leave);
			this._richTextBoxFeedback.Enter += new System.EventHandler(this._richTextBoxFeedback_Enter);
			// 
			// _labelInfoConf
			// 
			this._labelInfoConf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._labelInfoConf.Location = new System.Drawing.Point(16, 152);
			this._labelInfoConf.Name = "_labelInfoConf";
			this._labelInfoConf.Size = new System.Drawing.Size(480, 40);
			this._labelInfoConf.TabIndex = 5;
			this._labelInfoConf.Text = "We will treat this report as confidential and anonymous. Should you like to be co" +
				"ntacted back by our support team, please provide a contact e-mail address.";
			this._labelInfoConf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _checkBoxEmailAddress
			// 
			this._checkBoxEmailAddress.Location = new System.Drawing.Point(16, 200);
			this._checkBoxEmailAddress.Name = "_checkBoxEmailAddress";
			this._checkBoxEmailAddress.Size = new System.Drawing.Size(248, 32);
			this._checkBoxEmailAddress.TabIndex = 6;
			this._checkBoxEmailAddress.Text = "Provide a contact e-mail address";
			this._checkBoxEmailAddress.CheckedChanged += new System.EventHandler(this._checkBoxEmailAddress_CheckedChanged);
			// 
			// _textBoxEmailAddress
			// 
			this._textBoxEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._textBoxEmailAddress.Location = new System.Drawing.Point(264, 208);
			this._textBoxEmailAddress.Name = "_textBoxEmailAddress";
			this._textBoxEmailAddress.Size = new System.Drawing.Size(232, 20);
			this._textBoxEmailAddress.TabIndex = 7;
			this._textBoxEmailAddress.Text = "";
			// 
			// ErrorBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(512, 398);
			this.Controls.Add(this._textBoxEmailAddress);
			this.Controls.Add(this._checkBoxEmailAddress);
			this.Controls.Add(this._labelInfoConf);
			this.Controls.Add(this._richTextBoxFeedback);
			this.Controls.Add(this.buttonSendSupport);
			this.Controls.Add(this.buttonDetails);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelError);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.richTextBoxDetails);
			this.Controls.Add(this._buttonExit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 280);
			this.Name = "ErrorBox";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ErrorBox";
			this.Load += new System.EventHandler(this.ErrorBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ErrorBox_Load(object sender, System.EventArgs e)
		{
			richTextBoxDetails.Text = _detailedError;
			labelError.Text = _error;
			this.Width = _smallSize.Width;
			this.Height = _smallSize.Height;
			buttonDetails.Text = "Details";
			buttonClose.Text = "Close";
            buttonSendSupport.Text = "Send";
			_buttonExit.Text = "Exit Application";

			_feedbackText = "<" + "Feedback" + ". (" + "Optional" + ") >";
			this._richTextBoxFeedback.Text = _feedbackText;

			this._checkBoxEmailAddress.Text = "Email";
			this._labelInfoConf.Text = "Info";

			_checkBoxEmailAddress.Checked = false;
			_textBoxEmailAddress.Text = string.Empty;
			_textBoxEmailAddress.Enabled = false;
		}
	
		private void _richTextBoxFeedback_Enter(object sender, System.EventArgs e)
		{
			if( String.Compare( _richTextBoxFeedback.Text, _feedbackText ) == 0 )
				_richTextBoxFeedback.Text = "";
		}

		private void _richTextBoxFeedback_Leave(object sender, System.EventArgs e)
		{
			if( _richTextBoxFeedback.Text.Length == 0 )
				_richTextBoxFeedback.Text = _feedbackText;
		}

		private void _buttonExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void buttonSendSupport_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

                string to = "support@thesilentgroup.com";
				string subject = "BUG: " + _error;
				string body = richTextBoxDetails.Text;

				if( _checkBoxEmailAddress.Checked && _textBoxEmailAddress.Text.Length > 0 )
				{
					body = "Contact e-mail address: " + _textBoxEmailAddress.Text + "\n\n" + richTextBoxDetails.Text;
				}

				if( String.Compare( _richTextBoxFeedback.Text, _feedbackText ) != 0 )
				{
					body = "Feedback:\n" + _richTextBoxFeedback.Text + "\n\n" + body;
				}

                body += string.Format("\n\nSent from {0}, Version {1}.", Application.ProductName, Application.ProductVersion);
				try
				{
                    string[] bodyLines = body.Replace("\r", "").Split("\n".ToCharArray());
                    MailTo(to, "", "", subject, bodyLines);
				}
				catch
				{
				}

				this.Close();
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void buttonDetails_Click(object sender, System.EventArgs e)
		{
			if( _showingDetails )
			{
				this.Width = _smallSize.Width;
				this.Height = _smallSize.Height;
				buttonDetails.Text = "Show Details";
			}
			else
			{
				this.Width = _largeSize.Width;
				this.Height = _largeSize.Height;
				buttonDetails.Text = "Hide Details";
			}

			_showingDetails = ! _showingDetails;
		}

		public static void Show( Form parent, string error, string text, string detailedError )
		{
			using( ErrorBox errorBox = new ErrorBox() )
			{
				errorBox._error = error;
				errorBox._detailedError = detailedError;
				errorBox.Text = text;
				errorBox.ShowDialog( parent );
			}
		}

		private void _checkBoxEmailAddress_CheckedChanged(object sender, System.EventArgs e)
		{
			if( _checkBoxEmailAddress.Checked )
				_textBoxEmailAddress.Enabled = true;
			else
				_textBoxEmailAddress.Enabled = false;
		}

		private static ApplicationException GetInnerApplicationException( Exception ex )
		{
			Exception temp = ex;

			while( true )
			{
				if( temp == null )
					return null;
				if( temp is ApplicationException )
					return temp as ApplicationException;
                
				temp = temp.InnerException;
			}
		}

		public static void Show( string error, string text, string detailedError )
		{
			using( ErrorBox errorBox = new ErrorBox() )
			{
				errorBox._error = error;
				errorBox._detailedError = detailedError;
				errorBox.Text = text;
				errorBox.ShowDialog();
			}
		}

		public static void Show( Form parent, Exception ex )
		{
			ApplicationException appEx = GetInnerApplicationException( ex );
			if( appEx != null )
			{
                MessageBox.Show(parent, appEx.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				using( ErrorBox errorBox = new ErrorBox() )
				{
					errorBox._error = ex.Message;
					errorBox._detailedError = ex.ToString();
					errorBox.Text = "Error";
					errorBox.ShowDialog( parent );
				}
			}
		}

		public static void Show( Exception ex )
		{
			ApplicationException appEx = GetInnerApplicationException( ex );
			if( appEx != null )
			{
                MessageBox.Show(null, appEx.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{

				using( ErrorBox errorBox = new ErrorBox() )
				{
					errorBox._error = ex.Message;
					errorBox._detailedError = ex.ToString();
					errorBox.Text = "Error";
					errorBox.ShowDialog();
				}
			}
		}

		public string Error
		{
			get{ return _error; }
			set{ _error = value; }
		}

		public string DetailedError
		{
			get{ return _detailedError; }
			set{ _detailedError = value; }
		}

        public static void MailTo(string to, string cc, string bcc, string subject, string[] bodyLines)
        {
            string mailTo = string.Format("mailto:{0}?", to.Trim());
            if (cc.Trim() != string.Empty)
                mailTo += string.Format("cc={0}", cc.Trim());
            if (bcc.Trim() != string.Empty)
            {
                if (cc.Trim() != string.Empty)
                    mailTo += "&";
                mailTo += string.Format("bcc={0}", bcc.Trim());
            }
            if (cc.Trim() != string.Empty || bcc.Trim() != string.Empty)
                mailTo += "&";
            mailTo += string.Format("subject={0}", subject.Trim());

            if (bodyLines != null && bodyLines.Length > 0)
            {
                mailTo += "&body=";
                for (int i = 0; i < bodyLines.Length; i++)
                {
                    mailTo += bodyLines[i];
                    if (i < bodyLines.Length - 1)
                        mailTo += "%0D%0A";
                }
            }

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = mailTo;
            //startInfo.Arguments = " /w " + "\"" + fileName + "\"";
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = startInfo;
            process.Start();
        }
	}
}
