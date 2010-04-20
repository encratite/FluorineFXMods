using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace FluorineFxPolicyServer.Control
{
	/// <summary>
	/// Usage Control.
	/// </summary>
	public class UsageControl : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components = null;
		
		private const int _ovalWidth = 18;
		private const int _columns = 2;

		private int _fixedWidth;
		private int _rows = 1; 

        /// <summary>
        /// Minimum value for progress range
        /// </summary>
		private int _min = 0;
        /// <summary>
        /// Maximum value for progress range
        /// </summary>
        private int _max = 100;
        /// <summary>
        /// Current progress
        /// </summary>
		private int _value = 0;

		public UsageControl()
		{
			InitializeComponent();
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            _fixedWidth = 2 + (_ovalWidth + 1) * _columns + 1;
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


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// UsageControl
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.Name = "UsageControl";
			this.Size = new System.Drawing.Size(192, 160);

		}
		#endregion

		protected override void OnResize(EventArgs e)
		{
			Width = _fixedWidth;
			_rows = (ClientRectangle.Height / 4) - 1;
			// Invalidate the control to get a repaint.
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int percent1 = ((_value - _min) * 100) / (_max - _min);
			int filledCount1 = (_rows * percent1) / 100;
			int i = 0;
			for(i = 0; i < filledCount1; ++i)
			{
				for(int j = 0; j < _columns; ++j)
				{
					DrawOval(g, Pens.LawnGreen, 2 + j*(1+_ovalWidth), ClientRectangle.Bottom - 5 - i*4);
				}
			}

			for(; i < _rows; ++i)
			{
				for(int j = 0; j < _columns; ++j)
				{
                    DrawOval(g, Pens.Green, 2 + j * (1 + _ovalWidth), ClientRectangle.Bottom - 5 - i * 4);
				}
			}
			Draw3DBorder(g);
			base.OnPaint (e);
		}

		private void DrawOval(Graphics g, Pen pen, int x, int y)
		{
			g.DrawLine(pen, x+1 , y, x+_ovalWidth-2, y);
			g.DrawLine(pen, x, y+1, x+_ovalWidth-1, y+1);
			g.DrawLine(pen, x+1, y+2, x+_ovalWidth-2, y+2);
		}

		public int Maximum
		{
			get
			{
				return _max;
			}

			set
			{
				// Make sure that the maximum value is never set lower than the minimum value.
				if (value < _min)
					_min = value;
				_max = value;
				// Make sure that value is still in range.
				if (_value > _max)
					_value = _max;
				this.Invalidate();
			}
		}

		public int Value1
		{
			get
			{
				return _value;
			}

			set
			{
				// Make sure that the value does not stray outside the valid range.
				if (value < _min)
					_value = _min;
				else if (value > _max)
                    _max = value + 10;
				else
					_value = value;
				Invalidate();
			}
		}

		private void Draw3DBorder(Graphics g)
		{
			int PenWidth = (int)Pens.White.Width;

			g.DrawLine(Pens.DarkGray,
				new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
				new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
			g.DrawLine(Pens.DarkGray,
				new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
				new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
			g.DrawLine(Pens.White,
				new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
				new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
			g.DrawLine(Pens.White,
				new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
				new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
		}
	}
}
