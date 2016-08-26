using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Exocortex.DSP;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Form1.
	/// <p>Comments? Questions? Bugs? Tell Ben Houston at ben@exocortex.org</p>
	/// <p>Version: March 22, 2002</p>
	/// </summary>
	public class MandelbrotWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox _pictureBox;
		private System.Windows.Forms.Timer _timer;
		private System.ComponentModel.IContainer components;

		public const int cFractalWidth	= 1024;
		public const int cFractalHeight = 1024;

		public const int cStripHeight = 128;

		public MandelbrotWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			_bitmap = new Bitmap( cFractalWidth, cFractalHeight, PixelFormat.Format32bppArgb );

			this._pictureBox.Image = _bitmap;

			_timer.Tick += new EventHandler( this.OnTimer );
			_timer.Interval = 100;
			_timer.Start();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MandelbrotWindow));
			this._pictureBox = new System.Windows.Forms.PictureBox();
			this._timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// _pictureBox
			// 
			this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pictureBox.Name = "_pictureBox";
			this._pictureBox.Size = new System.Drawing.Size(520, 461);
			this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._pictureBox.TabIndex = 0;
			this._pictureBox.TabStop = false;
			// 
			// _timer
			// 
			this._timer.Interval = 1;
			// 
			// MandelbrotWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 461);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this._pictureBox});
			this.Name = "MandelbrotWindow";
			this.Text = "Exocortex.DSP: Mandelbrot Demo";
			this.ResumeLayout(false);

		}
		#endregion

		private Bitmap	_bitmap = null;
		private int		_start = 0;

		public void OnTimer( object o, EventArgs args ) {
			_timer.Stop();

			ComputeMandelbrotStrip( _bitmap, cFractalWidth, cFractalHeight, _start, _start + cStripHeight );
			_pictureBox.Image = _bitmap;
			_start += cStripHeight;

			if( _start < cFractalHeight ) {
				_timer.Start();
			}
		}

		public int	GetMandelbrotDepth( ComplexF c ) {
			int depth = 0;
			ComplexF a = ComplexF.Zero;

			// iterate until either the limit is reached or it is 
			// certain that a(k+1) = a(k)^2 + c goes to infinity.
			do {
				a = a*a + c;
				depth += 8;
			} while ( ( depth < 512 ) && ( a.GetModulusSquared() < 4.0f ) );

			if( a.GetModulusSquared() < 4.0f ) {
				return	255;
			}

			return	( depth % 256 );
		}

		public int[]	CreatePalette() {
			int[] palette = new int[256];
			for( int i = 0; i < 256; i ++ ) {
				palette[i] = Color.FromArgb( ( i < 128) ? ( i * 2 ) : ( 255 - ( i - 128 )*2 ), i, ( 255 - i ) ).ToArgb();
			}
			palette[255] = Color.Black.ToArgb();
			return	palette;
		}

		public unsafe void ComputeMandelbrotStrip( Bitmap bitmap, int width, int height, int start, int end ) {
			Rectangle rect = new Rectangle( 0, 0, width, height );
			BitmapData bitmapData = bitmap.LockBits( rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb );

			int* pixels = (int*) bitmapData.Scan0.ToPointer();

			int[]	palette = CreatePalette();

			// loop through each pixel in the bitmap
			for( int y = start; y < Math.Min( end, height ); y ++ ) {
				for( int x = 0; x < width; x ++ ) {
					
					// convert (0,width)x(0,height) --> (-2,1)x(-1.5,1.5)
					float xx = ( x * 3f / width ) - 2;
					float yy = ( y * 3f / height ) - 1.5f;

					int depth = Math.Min( 255, GetMandelbrotDepth( new ComplexF( xx, yy ) ) );

					// set the pixel at (x,y) to a color based on the number of needed iterations
					pixels[ x + y * width ] = palette[ depth ];
				}
			}

			bitmap.UnlockBits( bitmapData );
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MandelbrotWindow());
		}
	}
}
