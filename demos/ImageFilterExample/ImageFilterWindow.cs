using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Exocortex.DSP;

namespace ImageFilterApp
{
	/// <summary>
	/// Summary description for ImageFilterApp.
	/// <p>Comments? Questions? Bugs? Tell Ben Houston at ben@exocortex.org</p>
	/// <p>Version: March 22, 2002</p>
	/// </summary>
	public class ImageFilterWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miClose;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MenuItem menuFilter;
		private System.Windows.Forms.PictureBox _pictureBox;
		private System.Windows.Forms.MenuItem miForwardFFT;
		private System.Windows.Forms.MenuItem miBackwardFFT;
		private System.Windows.Forms.StatusBar _statusbar;
		private System.Windows.Forms.Panel _panelContent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageFilterWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ImageFilterWindow));
			this._pictureBox = new System.Windows.Forms.PictureBox();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.miClose = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.menuFilter = new System.Windows.Forms.MenuItem();
			this.miForwardFFT = new System.Windows.Forms.MenuItem();
			this.miBackwardFFT = new System.Windows.Forms.MenuItem();
			this._statusbar = new System.Windows.Forms.StatusBar();
			this._panelContent = new System.Windows.Forms.Panel();
			this._panelContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// _pictureBox
			// 
			this._pictureBox.BackColor = System.Drawing.SystemColors.ControlText;
			this._pictureBox.Name = "_pictureBox";
			this._pictureBox.Size = new System.Drawing.Size(352, 272);
			this._pictureBox.TabIndex = 0;
			this._pictureBox.TabStop = false;
			this._pictureBox.Visible = false;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuFilter});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miOpen,
																					 this.miSave,
																					 this.miClose,
																					 this.menuItem5,
																					 this.miExit});
			this.menuFile.Text = "&File";
			// 
			// miOpen
			// 
			this.miOpen.Index = 0;
			this.miOpen.Text = "&Open...";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miSave
			// 
			this.miSave.Index = 1;
			this.miSave.Text = "&Save...";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// miClose
			// 
			this.miClose.Index = 2;
			this.miClose.Text = "&Close";
			this.miClose.Click += new System.EventHandler(this.miClose_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 4;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// menuFilter
			// 
			this.menuFilter.Index = 1;
			this.menuFilter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.miForwardFFT,
																					   this.miBackwardFFT});
			this.menuFilter.Text = "F&ilter";
			// 
			// miForwardFFT
			// 
			this.miForwardFFT.Index = 0;
			this.miForwardFFT.Text = "&Forward FFT";
			this.miForwardFFT.Click += new System.EventHandler(this.miForwardFFT_Click);
			// 
			// miBackwardFFT
			// 
			this.miBackwardFFT.Index = 1;
			this.miBackwardFFT.Text = "&Backward FFT";
			this.miBackwardFFT.Click += new System.EventHandler(this.miBackwardFFT_Click);
			// 
			// _statusbar
			// 
			this._statusbar.Location = new System.Drawing.Point(0, 363);
			this._statusbar.Name = "_statusbar";
			this._statusbar.Size = new System.Drawing.Size(440, 22);
			this._statusbar.TabIndex = 1;
			this._statusbar.Text = "No bitmap loaded.";
			// 
			// _panelContent
			// 
			this._panelContent.AutoScroll = true;
			this._panelContent.BackColor = System.Drawing.SystemColors.ControlDark;
			this._panelContent.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this._pictureBox});
			this._panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this._panelContent.Name = "_panelContent";
			this._panelContent.Size = new System.Drawing.Size(440, 363);
			this._panelContent.TabIndex = 2;
			// 
			// ImageFilterWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 385);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this._panelContent,
																		  this._statusbar});
			this.Menu = this.mainMenu;
			this.Name = "ImageFilterWindow";
			this.Text = "Exocortex.DSP: Image Filter Demo";
			this._panelContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected CImage _cimage = null;
		public CImage	ActiveCImage {
			get {	return	_cimage;	}
			set	{
				_cimage = value;
				if( _cimage != null ) {
					Bitmap bitmap = _cimage.ToBitmap();
					_pictureBox.Location = new Point( 0, 0 );
					_pictureBox.Image = bitmap;
					_pictureBox.Size = bitmap.Size;
					_pictureBox.Visible = true;
					_statusbar.Text = "( " + _cimage.Width + ", " + _cimage.Height + " )"; 
				}
				else {
					_pictureBox.Image = null;
					_pictureBox.Visible = false;
					_statusbar.Text = "No bitmap loaded.";
				}
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ImageFilterWindow());
		}

		private void miOpen_Click(object sender, System.EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			if( ofd.ShowDialog( this ) != DialogResult.OK ) {
				return;
			}

			try {
				this.ActiveCImage = new CImage( ofd.FileName );
			}
			catch( Exception ex ) {
				MessageBox.Show( this, "Error opening file '" + ofd.FileName + " because '" + ex.Message + " (" + ex.GetType().Name + ")'.", "Open...", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private void miSave_Click(object sender, System.EventArgs e) {
			if( this.ActiveCImage == null ) {
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			sfd.FileName = "untitled.bmp";
			if( sfd.ShowDialog( this ) != DialogResult.OK ) {
				return;
			}

			try {
				this.ActiveCImage.Save( sfd.FileName );
			}
			catch( Exception ex ) {
				MessageBox.Show( this, "Error saving file '" + sfd.FileName + " because '" + ex.Message + " (" + ex.GetType().Name + ")'.", "Save...", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}

		}

		private void miClose_Click(object sender, System.EventArgs e) {
			this.ActiveCImage = null;
		}

		private void miExit_Click(object sender, System.EventArgs e) {
			this.ActiveCImage = null;
			Application.Exit();
		}
								
		private unsafe void miGaussianBlur_Click(object sender, System.EventArgs e) {
			if( this.ActiveCImage == null ) {
				return;
			}

			CImage cimage = this.ActiveCImage;
			float scale = 1f / (float) Math.Sqrt( cimage.Width * cimage.Height );
			ComplexF[] data = cimage.Data;

			Fourier.FFT3( data, cimage.Width, cimage.Height, 1, FourierDirection.Forward );
			
			for( int i = 0; i < data.Length; i ++ ) {
				data[i] *= scale;
			}

			Fourier.FFT3( data, cimage.Width, cimage.Height, 1, FourierDirection.Backward );
			
			for( int i = 0; i < data.Length; i ++ ) {
				data[i] *= scale;
			}

			cimage.FrequencySpace = true;

			this.ActiveCImage = cimage;
		}

		private void miForwardFFT_Click(object sender, System.EventArgs e) {
			if( this.ActiveCImage == null ) {
				return;
			}

			CImage cimage = this.ActiveCImage;
			float scale = 1f / (float) Math.Sqrt( cimage.Width * cimage.Height );
			ComplexF[] data = cimage.Data;

			int offset = 0;
			for( int y = 0; y < cimage.Height; y ++ ) {
				for( int x = 0; x < cimage.Width; x ++ ) {
					if( (( x + y ) & 0x1 ) != 0 ) {
						data[ offset ] *= -1;
					}
					offset++;
				}
			}

			Fourier.FFT2( data, cimage.Width, cimage.Height, FourierDirection.Forward );
			
			cimage.FrequencySpace = true;

			for( int i = 0; i < data.Length; i ++ ) {
				data[i] *= scale;
			}

			this.ActiveCImage = cimage;		
		}

		private void miBackwardFFT_Click(object sender, System.EventArgs e) {
			if( this.ActiveCImage == null ) {
				return;
			}

			CImage cimage = this.ActiveCImage;
			float scale = 1f / (float) Math.Sqrt( cimage.Width * cimage.Height );
			ComplexF[] data = cimage.Data;

			Fourier.FFT2( data, cimage.Width, cimage.Height, FourierDirection.Backward );
			
			int offset = 0;
			for( int y = 0; y < cimage.Height; y ++ ) {
				for( int x = 0; x < cimage.Width; x ++ ) {
					if( (( x + y ) & 0x1 ) != 0 ) {
						data[ offset ] *= -1;
					}
					offset++;
				}
			}

			cimage.FrequencySpace = false;
			
			for( int i = 0; i < data.Length; i ++ ) {
				data[i] *= scale;
			}

			this.ActiveCImage = cimage;		
		}
	}
}
