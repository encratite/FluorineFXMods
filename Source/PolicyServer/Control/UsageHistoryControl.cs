using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FluorineFxPolicyServer.Control
{
	/// <summary>
	/// Usage History Control.
	/// </summary>
	public class UsageHistoryControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private const int _squareWidth = 12;
		private const int _maxLastValuesCount = 2000;
		private const int _shiftStep = 3;

		private int _shift = 0;

		private int [] _lastValues = new int[_maxLastValuesCount];
		private int _nextValueIndex;
		private int _lastValuesCount;

		private int _max = 100;
		private int _min = 0;

        public UsageHistoryControl()
        {
            InitializeComponent();
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            Reset();
        }

		public void Reset()
		{
			_lastValues.Initialize();
			_nextValueIndex = 0;
			_lastValuesCount = 0;
			Invalidate();
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
			// UsageHistoryControl
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.Name = "UsageHistoryControl";

		}
		#endregion

		protected override void OnResize(EventArgs e)
		{
			// Invalidate the control to get a repaint.
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			for(int i = 0; i <= ClientRectangle.Width+_squareWidth; i += _squareWidth)
			{
				g.DrawLine(Pens.Green, i-_shift, 0, i-_shift, ClientRectangle.Height);
			}

			for(int i = 0; i < ClientRectangle.Height; i += _squareWidth)
			{
				g.DrawLine(Pens.Green, 0, i, ClientRectangle.Width, i);
			}

			int startValueIndex = (_nextValueIndex-1+_maxLastValuesCount)%_maxLastValuesCount;

			int prevVal1 = GetRelativeValue(_lastValues[startValueIndex]);

			for(int i = 1; i < _lastValuesCount; ++i)
			{
				int index = _nextValueIndex - 1 - i;
				if (index < 0)
				{
					index += _maxLastValuesCount;
				}
				int val1 = GetRelativeValue(_lastValues[index]);
				g.DrawLine(Pens.LawnGreen,ClientRectangle.Width-(i-1)*_shiftStep, ClientRectangle.Height-prevVal1,ClientRectangle.Width-i*_shiftStep, ClientRectangle.Height-val1);
				prevVal1 = val1;
			}
		}

		private int GetRelativeValue(int val)
		{
			int result = val * (ClientRectangle.Height-2) / _max + 1;
			return result;
		}

		public void AddValue(int val1)
		{
            if (val1 > _max)
                _max = val1 + 10;
			_lastValues[_nextValueIndex] = val1;
			
			_nextValueIndex++;
			_nextValueIndex %= _maxLastValuesCount;
			_lastValuesCount++;
			if (_lastValuesCount > _maxLastValuesCount)
			{
				_lastValuesCount = _maxLastValuesCount;
			}
			_shift += _shiftStep;
			_shift %= _squareWidth;
			Invalidate();
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
				this.Invalidate();
			}
		}

	}
}
