/******************************************************
                  DirectShow .NET
		      netmaster@swissonline.ch
*******************************************************/
//					PlayWndNET MainForm

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using DShowNET;

namespace PlayWndNET
{
	/// <summary> MainForm for this sample media file player. </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuTopFile;
		private System.Windows.Forms.MenuItem menuFileOpenClip;
		private System.Windows.Forms.MenuItem menuFileCloseClip;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuTopControl;
		private System.Windows.Forms.MenuItem menuControlPause;
		private System.Windows.Forms.MenuItem menuControlStop;
		private System.Windows.Forms.MenuItem menuControlMute;
		private System.Windows.Forms.MenuItem menuControlStep;
		private System.Windows.Forms.MenuItem menuControlHalf;
		private System.Windows.Forms.MenuItem menuControlThreeQ;
		private System.Windows.Forms.MenuItem menuControlNormal;
		private System.Windows.Forms.MenuItem menuControlDouble;
		private System.Windows.Forms.MenuItem menuControlFullScr;
		private System.Windows.Forms.MenuItem menuTopRate;
		private System.Windows.Forms.MenuItem menuRateIncr;
		private System.Windows.Forms.MenuItem menuRateDecr;
		private System.Windows.Forms.MenuItem menuRateNormal;
		private System.Windows.Forms.MenuItem menuRateHalf;
		private System.Windows.Forms.MenuItem menuRateDouble;
		private System.Windows.Forms.MenuItem menuTopHelp;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.MenuItem menuFileSep1;
		private System.Windows.Forms.MenuItem menuControlSep1;
		private System.Windows.Forms.MenuItem menuControlSep2;
		private System.Windows.Forms.MenuItem menuControlSep3;
		private System.Windows.Forms.MenuItem menuRateSep1;
		/// <summary> Required designer variable. </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				CloseInterfaces();
				
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuTopFile = new System.Windows.Forms.MenuItem();
			this.menuFileOpenClip = new System.Windows.Forms.MenuItem();
			this.menuFileCloseClip = new System.Windows.Forms.MenuItem();
			this.menuFileSep1 = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuTopControl = new System.Windows.Forms.MenuItem();
			this.menuControlPause = new System.Windows.Forms.MenuItem();
			this.menuControlStop = new System.Windows.Forms.MenuItem();
			this.menuControlMute = new System.Windows.Forms.MenuItem();
			this.menuControlSep1 = new System.Windows.Forms.MenuItem();
			this.menuControlStep = new System.Windows.Forms.MenuItem();
			this.menuControlSep2 = new System.Windows.Forms.MenuItem();
			this.menuControlHalf = new System.Windows.Forms.MenuItem();
			this.menuControlThreeQ = new System.Windows.Forms.MenuItem();
			this.menuControlNormal = new System.Windows.Forms.MenuItem();
			this.menuControlDouble = new System.Windows.Forms.MenuItem();
			this.menuControlSep3 = new System.Windows.Forms.MenuItem();
			this.menuControlFullScr = new System.Windows.Forms.MenuItem();
			this.menuTopRate = new System.Windows.Forms.MenuItem();
			this.menuRateIncr = new System.Windows.Forms.MenuItem();
			this.menuRateDecr = new System.Windows.Forms.MenuItem();
			this.menuRateSep1 = new System.Windows.Forms.MenuItem();
			this.menuRateNormal = new System.Windows.Forms.MenuItem();
			this.menuRateHalf = new System.Windows.Forms.MenuItem();
			this.menuRateDouble = new System.Windows.Forms.MenuItem();
			this.menuTopHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuTopFile,
																					  this.menuTopControl,
																					  this.menuTopRate,
																					  this.menuTopHelp});
			// 
			// menuTopFile
			// 
			this.menuTopFile.Index = 0;
			this.menuTopFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuFileOpenClip,
																						this.menuFileCloseClip,
																						this.menuFileSep1,
																						this.menuFileExit});
			this.menuTopFile.Text = "&File";
			// 
			// menuFileOpenClip
			// 
			this.menuFileOpenClip.Index = 0;
			this.menuFileOpenClip.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuFileOpenClip.Text = "&Open Clip...";
			this.menuFileOpenClip.Click += new System.EventHandler(this.menuFileOpenClip_Click);
			// 
			// menuFileCloseClip
			// 
			this.menuFileCloseClip.Enabled = false;
			this.menuFileCloseClip.Index = 1;
			this.menuFileCloseClip.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
			this.menuFileCloseClip.Text = "&Close Clip";
			this.menuFileCloseClip.Click += new System.EventHandler(this.menuFileCloseClip_Click);
			// 
			// menuFileSep1
			// 
			this.menuFileSep1.Index = 2;
			this.menuFileSep1.Text = "-";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 3;
			this.menuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuTopControl
			// 
			this.menuTopControl.Index = 1;
			this.menuTopControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuControlPause,
																						   this.menuControlStop,
																						   this.menuControlMute,
																						   this.menuControlSep1,
																						   this.menuControlStep,
																						   this.menuControlSep2,
																						   this.menuControlHalf,
																						   this.menuControlThreeQ,
																						   this.menuControlNormal,
																						   this.menuControlDouble,
																						   this.menuControlSep3,
																						   this.menuControlFullScr});
			this.menuTopControl.Text = "&Control";
			// 
			// menuControlPause
			// 
			this.menuControlPause.Enabled = false;
			this.menuControlPause.Index = 0;
			this.menuControlPause.Text = "&Pause/Play\tP";
			this.menuControlPause.Click += new System.EventHandler(this.menuControlPause_Click);
			// 
			// menuControlStop
			// 
			this.menuControlStop.Enabled = false;
			this.menuControlStop.Index = 1;
			this.menuControlStop.Text = "&Stop\tS";
			this.menuControlStop.Click += new System.EventHandler(this.menuControlStop_Click);
			// 
			// menuControlMute
			// 
			this.menuControlMute.Enabled = false;
			this.menuControlMute.Index = 2;
			this.menuControlMute.Text = "&Mute/Unmute\tM";
			this.menuControlMute.Click += new System.EventHandler(this.menuControlMute_Click);
			// 
			// menuControlSep1
			// 
			this.menuControlSep1.Index = 3;
			this.menuControlSep1.Text = "-";
			// 
			// menuControlStep
			// 
			this.menuControlStep.Enabled = false;
			this.menuControlStep.Index = 4;
			this.menuControlStep.Text = "Single F&rame Step\t<Space>";
			this.menuControlStep.Click += new System.EventHandler(this.menuControlStep_Click);
			// 
			// menuControlSep2
			// 
			this.menuControlSep2.Index = 5;
			this.menuControlSep2.Text = "-";
			// 
			// menuControlHalf
			// 
			this.menuControlHalf.Enabled = false;
			this.menuControlHalf.Index = 6;
			this.menuControlHalf.RadioCheck = true;
			this.menuControlHalf.Text = "&Half size (50%)\tH";
			this.menuControlHalf.Click += new System.EventHandler(this.menuControlHalf_Click);
			// 
			// menuControlThreeQ
			// 
			this.menuControlThreeQ.Enabled = false;
			this.menuControlThreeQ.Index = 7;
			this.menuControlThreeQ.RadioCheck = true;
			this.menuControlThreeQ.Text = "&Three-quarter size (75%)\tT";
			this.menuControlThreeQ.Click += new System.EventHandler(this.menuControlThreeQ_Click);
			// 
			// menuControlNormal
			// 
			this.menuControlNormal.Enabled = false;
			this.menuControlNormal.Index = 8;
			this.menuControlNormal.RadioCheck = true;
			this.menuControlNormal.Text = "&Normal size (100%)\tN";
			this.menuControlNormal.Click += new System.EventHandler(this.menuControlNormal_Click);
			// 
			// menuControlDouble
			// 
			this.menuControlDouble.Enabled = false;
			this.menuControlDouble.Index = 9;
			this.menuControlDouble.RadioCheck = true;
			this.menuControlDouble.Text = "&Double size (200%)\tD";
			this.menuControlDouble.Click += new System.EventHandler(this.menuControlDouble_Click);
			// 
			// menuControlSep3
			// 
			this.menuControlSep3.Index = 10;
			this.menuControlSep3.Text = "-";
			// 
			// menuControlFullScr
			// 
			this.menuControlFullScr.Enabled = false;
			this.menuControlFullScr.Index = 11;
			this.menuControlFullScr.Text = "&Full screen\t<enter> or F";
			this.menuControlFullScr.Click += new System.EventHandler(this.menuControlFullScr_Click);
			// 
			// menuTopRate
			// 
			this.menuTopRate.Index = 2;
			this.menuTopRate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuRateIncr,
																						this.menuRateDecr,
																						this.menuRateSep1,
																						this.menuRateNormal,
																						this.menuRateHalf,
																						this.menuRateDouble});
			this.menuTopRate.Text = "&Rate";
			// 
			// menuRateIncr
			// 
			this.menuRateIncr.Enabled = false;
			this.menuRateIncr.Index = 0;
			this.menuRateIncr.Text = "&Increase playback rate\t<Right arrow>";
			this.menuRateIncr.Click += new System.EventHandler(this.menuRateIncr_Click);
			// 
			// menuRateDecr
			// 
			this.menuRateDecr.Enabled = false;
			this.menuRateDecr.Index = 1;
			this.menuRateDecr.Text = "&Decrease playback rate\t<Left arrow>";
			this.menuRateDecr.Click += new System.EventHandler(this.menuRateDecr_Click);
			// 
			// menuRateSep1
			// 
			this.menuRateSep1.Index = 2;
			this.menuRateSep1.Text = "-";
			// 
			// menuRateNormal
			// 
			this.menuRateNormal.Enabled = false;
			this.menuRateNormal.Index = 3;
			this.menuRateNormal.RadioCheck = true;
			this.menuRateNormal.Text = "&Normal playback rate\t<Back>";
			this.menuRateNormal.Click += new System.EventHandler(this.menuRateNormal_Click);
			// 
			// menuRateHalf
			// 
			this.menuRateHalf.Enabled = false;
			this.menuRateHalf.Index = 4;
			this.menuRateHalf.RadioCheck = true;
			this.menuRateHalf.Text = "&Half playback rate\t<Down arrow>";
			this.menuRateHalf.Click += new System.EventHandler(this.menuRateHalf_Click);
			// 
			// menuRateDouble
			// 
			this.menuRateDouble.Enabled = false;
			this.menuRateDouble.Index = 5;
			this.menuRateDouble.RadioCheck = true;
			this.menuRateDouble.Text = "Dou&ble playback rate\t<Up arrow>";
			this.menuRateDouble.Click += new System.EventHandler(this.menuRateDouble_Click);
			// 
			// menuTopHelp
			// 
			this.menuTopHelp.Index = 3;
			this.menuTopHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuHelpAbout});
			this.menuTopHelp.Text = "&Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuHelpAbout.Text = "&About...";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(408, 293);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "PlayWnd.NET";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Activated += new System.EventHandler(this.MainForm_Activated);

		}
		#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run( new MainForm() );
	}

	private void MainForm_Activated(object sender, System.EventArgs e)
	{
		if( firstActive )
			return;
		firstActive = true;

		if( ! DsUtils.IsCorrectDirectXVersion() )
		{
			MessageBox.Show( this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			this.Close(); return;
		}
	}

	private void menuFileExit_Click( object sender, System.EventArgs e )
	{
		this.Close();
	}
	private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		CloseInterfaces();
	}

	private void MainForm_Resize(object sender, System.EventArgs e)
	{
		ResizeVideoWindow();	// also resize video preview
	}

	private void menuFileOpenClip_Click(object sender, System.EventArgs e)
	{
		OpenFileDialog af = new OpenFileDialog();
		af.Title = "Open Media File...";
		af.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		af.Filter = clipFileFilters;
		if( af.ShowDialog() != DialogResult.OK )
			return;

		menuFileCloseClip_Click( null, null );

		clipFile = af.FileName;
		if( ! PlayClip() )
			menuFileCloseClip_Click( null, null );

		UpdatePlaybackMenu();
		UpdateMainTitle();
	}

	private void menuFileCloseClip_Click(object sender, System.EventArgs e)
	{
		clipFile = null;
		clipType = ClipType.None;
		CloseInterfaces();

		UpdatePlaybackMenu();
		UpdateMainTitle();
		InitPlayerWindow();
		this.Refresh();
	}



		/// <summary> start all the interfaces, graphs and preview window. </summary>
	bool PlayClip()
	{
		try {
			CloseInterfaces();
			if( ! GetInterfaces() )
				return false;
				
			CheckClipType();
			if( clipType == ClipType.None )
				return false;

			int hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
			
			if( (clipType == ClipType.AudioVideo) || (clipType == ClipType.VideoOnly) )
			{
				videoWin.put_Owner( this.Handle );
				videoWin.put_WindowStyle( WS_CHILD | WS_CLIPSIBLINGS | WS_CLIPCHILDREN );

				InitVideoWindow( 1, 1 );
				CheckSizeMenu( menuControlNormal );
				GetFrameStepInterface();
			}
			else
				InitPlayerWindow();

			hr = mediaCtrl.Run();
			if( hr >= 0 )
				playState = PlayState.Running;

			return hr >= 0;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not start clip\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
	}


		/// <summary> create the used COM components and get the interfaces. </summary>
	bool GetInterfaces()
	{
		Type comtype = null;
		object comobj = null;
		try {
			comtype = Type.GetTypeFromCLSID( Clsid.FilterGraph );
			if( comtype == null )
				throw new NotSupportedException( "DirectX (8.1 or higher) not installed?" );
			comobj = Activator.CreateInstance( comtype );
			graphBuilder = (IGraphBuilder) comobj; comobj = null;
			
			int hr = graphBuilder.RenderFile( clipFile, null );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			mediaCtrl	= (IMediaControl)  graphBuilder;
			mediaEvt	= (IMediaEventEx)  graphBuilder;
			mediaSeek	= (IMediaSeeking)  graphBuilder;
			mediaPos	= (IMediaPosition) graphBuilder;

			videoWin	= graphBuilder as IVideoWindow;
			basicVideo	= graphBuilder as IBasicVideo2;
			basicAudio	= graphBuilder as IBasicAudio;
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not get interfaces\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
		finally
		{
			if( comobj != null )
				Marshal.ReleaseComObject( comobj ); comobj = null;
		}
	}



		/// <summary> try to get the step interfaces. </summary>
	bool GetFrameStepInterface()
	{
		videoStep = graphBuilder as IVideoFrameStep;
		if( videoStep == null )
			return false;

		// Check if this decoder can step
		int hr = videoStep.CanStep( 0, null );
		if( hr != 0 )
			{
			videoStep = null;
			return false;
			}
		return true;
	}


		/// <summary> try to detect clip type (video/audio) [not reliable]. </summary>
	void CheckClipType()
	{
		if( basicAudio == null )
			clipType = ClipType.None;
		else
			clipType = ClipType.AudioOnly;

		if( (videoWin == null) || (basicVideo == null) )
			return;

		int visible;
		int hr = videoWin.get_Visible( out visible );
		if( hr < 0 )
			return;
		else
		{
			if( basicAudio == null )
				clipType = ClipType.VideoOnly;
			else
				clipType = ClipType.AudioVideo;
		}
	}


		/// <summary> configure video preview window. </summary>
	bool InitVideoWindow( int multiplier, int divider )
	{
		if( basicVideo == null )
			return false;

		int height, width, hr;

		// Read the default video size
		hr = basicVideo.GetVideoSize( out width, out height );
		if( (hr != 0) || (width < 16) || (height < 16) )
			return true;

		// Account for requests of normal, half, or double size
		width  = width  * multiplier / divider;
		height = height * multiplier / divider;
		
		this.ClientSize = new Size( width, height );
		ResizeVideoWindow();
		return true;
	}

		/// <summary> configure window for audio playback. </summary>
	bool InitPlayerWindow()
	{
		this.ClientSize = new Size( 240, 120 );
		return true;
	}


		/// <summary> resize preview video window to fill client area. </summary>
	void ResizeVideoWindow()
	{
		if( videoWin == null )
			return;
		Rectangle rc = this.ClientRectangle;
		int hr = videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
	}


		/// <summary> enable menu items to match current state. </summary>
	void UpdatePlaybackMenu()
	{
		menuFileCloseClip.Enabled = clipFile != null;

		bool enable = playState != PlayState.Init;
		menuControlPause.Enabled	= enable;
		menuControlStop.Enabled		= enable;
		menuControlMute.Enabled		= enable;
		menuControlStep.Enabled		= videoStep != null;

		menuRateIncr.Enabled		= enable;
		menuRateDecr.Enabled		= enable;
		menuRateNormal.Enabled		= enable;
		menuRateHalf.Enabled		= enable;
		menuRateDouble.Enabled		= enable;

		enable = enable && (clipType != ClipType.AudioOnly);
		menuControlHalf.Enabled		= enable;
		menuControlThreeQ.Enabled	= enable;
		menuControlNormal.Enabled	= enable;
		menuControlDouble.Enabled	= enable;
		menuControlFullScr.Enabled	= enable;
	}


		/// <summary> do cleanup and release DirectShow. </summary>
	void CloseInterfaces()
	{
		int hr;
		try {
			if( mediaCtrl != null )
			{
				hr = mediaCtrl.StopWhenReady();
				mediaCtrl = null;
			}

			playState = PlayState.Stopped;

			if( mediaEvt != null )
			{
				hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );
				mediaEvt = null;
			}

			if( videoWin != null )
			{
				hr = videoWin.put_Visible( DsHlp.OAFALSE );
				hr = videoWin.put_Owner( IntPtr.Zero );
				videoWin = null;
			}

			mediaSeek	= null;
			mediaPos	= null;
			basicVideo	= null;
			videoStep	= null;
			basicAudio	= null;

			if( graphBuilder != null )
				Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

			playState = PlayState.Init;
		}
		catch( Exception )
		{}
	}


		/// <summary> override window fn to handle graph events. </summary>
	protected override void WndProc( ref Message m )
	{
		if( m.Msg == WM_GRAPHNOTIFY )
			{
			if( mediaEvt != null )
				OnGraphNotify();
			return;
			}
		base.WndProc( ref m );
	}

		/// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
	void OnGraphNotify()
	{
		int p1, p2, hr = 0;
		DsEvCode code;
		do
		{
			hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
			if( hr < 0 )
				break;
			hr = mediaEvt.FreeEventParams( code, p1, p2 );
			if( code == DsEvCode.Complete )
				OnClipCompleted();
		}
		while( hr == 0 );
	}

		/// <summary> graph event if clip has finished </summary>
	void OnClipCompleted()
	{
		if( (mediaCtrl == null) || (mediaSeek == null) )
			return;

		DsOptInt64 pos = new DsOptInt64( 0 );
		int hr = mediaSeek.SetPositions( pos, SeekingFlags.AbsolutePositioning, null, SeekingFlags.NoPositioning );
		if( hr == 0 )
			return;
		hr = mediaCtrl.Stop();
		if( hr < 0 )
			return;
		hr = mediaCtrl.Run();
	}

		/// <summary> menu clicked to pause the playback. </summary>
	private void menuControlPause_Click(object sender, System.EventArgs e)
	{
		if( mediaCtrl == null )
			return;

		if( (playState == PlayState.Paused) || (playState == PlayState.Stopped) )
		{
			if( mediaCtrl.Run() == 0 )
				playState = PlayState.Running;
		}
		else if( playState == PlayState.Running )
		{
			if( mediaCtrl.Pause() == 0 )
				playState = PlayState.Paused;
		}
		UpdateMainTitle();
	}

		/// <summary> menu clicked to stop the playback. </summary>
	private void menuControlStop_Click(object sender, System.EventArgs e)
	{
		if( (mediaCtrl == null) || (mediaSeek == null) )
			return;

		if( (playState != PlayState.Paused) && (playState != PlayState.Running) )
			return;

		int hr = mediaCtrl.Stop();
		playState = PlayState.Stopped;

		DsOptInt64 pos = new DsOptInt64( 0 );
		hr = mediaSeek.SetPositions( pos, SeekingFlags.AbsolutePositioning, null, SeekingFlags.NoPositioning );
		hr = mediaCtrl.Pause();
		UpdateMainTitle();
	}

		/// <summary> menu clicked to mute audio. </summary>
	private void menuControlMute_Click(object sender, System.EventArgs e)
	{
		int hr, currentVolume;

		if( (graphBuilder == null) || (basicAudio == null) )
			return;
		hr = basicAudio.get_Volume( out currentVolume );
		if( hr != 0 )
			return;

		if( currentVolume != -10000 )   // midi may use -9640 ???
		{
			savedVolume = currentVolume;
			currentVolume = -10000;
			menuControlMute.Checked = true;
		}
		else
		{
			currentVolume = savedVolume;
			menuControlMute.Checked = false;
		}

		hr = basicAudio.put_Volume( currentVolume );
		hr += 1;
	}

		/// <summary> menu clicked to step one frame. </summary>
	private void menuControlStep_Click(object sender, System.EventArgs e)
	{
		int hr;
		if( (videoStep == null) || (mediaCtrl == null) )
			return;
		if( playState != PlayState.Paused )
			hr = mediaCtrl.Pause();
		playState = PlayState.Paused;
		hr = videoStep.Step( 1, null );
	}

		/// <summary> step n-numbers of frames in stream. </summary>
	private void StepFrames( int frames )
	{
		int hr;
		if( (videoStep == null) || (mediaCtrl == null) )
			return;
		hr = videoStep.CanStep( frames, null );
		if( hr != 0 )
			return;
		if( playState != PlayState.Paused )
			hr = mediaCtrl.Pause();
		playState = PlayState.Paused;
		hr = videoStep.Step( frames, null );
	}



	private void menuControlHalf_Click(object sender, System.EventArgs e)
	{
		InitVideoWindow( 1, 2 );
		CheckSizeMenu( menuControlHalf );
	}
	private void menuControlThreeQ_Click(object sender, System.EventArgs e)
	{
		InitVideoWindow( 3, 4 );
		CheckSizeMenu( menuControlThreeQ );
	}

	private void menuControlNormal_Click(object sender, System.EventArgs e)
	{
		InitVideoWindow( 1, 1 );
		CheckSizeMenu( menuControlNormal );
	}

	private void menuControlDouble_Click(object sender, System.EventArgs e)
	{
		InitVideoWindow( 2, 1 );
		CheckSizeMenu( menuControlDouble );
	}
	void CheckSizeMenu( MenuItem checkItem )
	{
		menuControlHalf.Checked		= checkItem == menuControlHalf;
		menuControlThreeQ.Checked	= checkItem == menuControlThreeQ;
		menuControlNormal.Checked	= checkItem == menuControlNormal;
		menuControlDouble.Checked	= checkItem == menuControlDouble;
	}


	private void menuControlFullScr_Click(object sender, System.EventArgs e)
	{
		ToggleFullScreen();
	}

	private void menuRateIncr_Click(object sender, System.EventArgs e)
	{
		ModifyRate( 0.25 );
	}
	private void menuRateDecr_Click(object sender, System.EventArgs e)
	{
		ModifyRate( -0.25 );
	}
	private void menuRateNormal_Click(object sender, System.EventArgs e)
	{
		SetRate( 1.0 );
	}
	private void menuRateHalf_Click(object sender, System.EventArgs e)
	{
		SetRate( 0.5 );
	}
	private void menuRateDouble_Click(object sender, System.EventArgs e)
	{
		SetRate( 2.0 );
	}


	void ModifyRate( double rateAdjust )
	{
		if( (mediaPos == null) || (rateAdjust == 0.0) )
			return;

		double rate;
		int hr = mediaPos.get_Rate( out rate );
		if( hr < 0 )
			return;
		rate += rateAdjust;
		hr = mediaPos.put_Rate( rate );
	}
	void SetRate( double newRate )
	{
		if( mediaPos == null )
			return;

		int hr = mediaPos.put_Rate( newRate );
	}




		/// <summary> update caption text of this form. </summary>
	void UpdateMainTitle()
	{
		if( clipFile == null )
		{
			this.Text = "PlayWnd.NET";
			return;
		}
		
		string txt = Path.GetFileName( clipFile ) + " : " + clipType.ToString();
		if( playState == PlayState.Paused )
			txt = txt + " -Paused-";
		this.Text = txt;
	}

	
		/// <summary> keyboard handling for shortcuts. </summary>
	private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if( playState == PlayState.Init )
			return;

		switch( e.KeyCode )
		{
			case Keys.P:
				{	menuControlPause_Click( null, null ); break; }
			case Keys.S:
				{	menuControlStop_Click( null, null ); break; }
			case Keys.M:
				{	menuControlMute_Click( null, null ); break; }

			case Keys.D1:
			case Keys.Space:
				{	menuControlStep_Click( null, null ); break; }
			case Keys.D2:
				{	StepFrames( 2 ); break; }
			case Keys.D3:
				{	StepFrames( 3 ); break; }
			case Keys.D4:
				{	StepFrames( 4 ); break; }
			case Keys.D5:
				{	StepFrames( 5 ); break; }
			case Keys.D6:
				{	StepFrames( 6 ); break; }
			case Keys.D7:
				{	StepFrames( 7 ); break; }
			case Keys.D8:
				{	StepFrames( 8 ); break; }
			case Keys.D9:
				{	StepFrames( 9 ); break; }

			case Keys.H:
				{	menuControlHalf_Click( null, null ); break; }
			case Keys.T:
				{	menuControlThreeQ_Click( null, null ); break; }
			case Keys.N:
				{	menuControlNormal_Click( null, null ); break; }
			case Keys.D:
				{	menuControlDouble_Click( null, null ); break; }

			case Keys.F:
				{	ToggleFullScreen(); break; }
			case Keys.Enter:
				{	ToggleFullScreen(); break; }
			case Keys.Escape:
				{
					if( fullScreen )
						ToggleFullScreen();
					break;
				}

			case Keys.Left:
				{	menuRateDecr_Click( null, null ); break; }
			case Keys.Right:
				{	menuRateIncr_Click( null, null ); break; }
			case Keys.Up:
				{	menuRateDouble_Click( null, null ); break; }
			case Keys.Down:
				{	menuRateHalf_Click( null, null ); break; }
			case Keys.Back:
				{	menuRateNormal_Click( null, null ); break; }
		}
	}

		/// <summary> full-screen toggle. </summary>
	void ToggleFullScreen()
	{
		if( (clipType != ClipType.VideoOnly) && (clipType != ClipType.AudioVideo) )
			return;
		if( videoWin == null )
			return;

		int mode;
		int hr = videoWin.get_FullScreenMode( out mode );
		if( mode == DsHlp.OAFALSE )
		{
			hr = videoWin.get_MessageDrain( out drainWin );
			hr = videoWin.put_MessageDrain( this.Handle );
			mode = DsHlp.OATRUE;
			hr = videoWin.put_FullScreenMode( mode );
			if( hr >= 0 )
				fullScreen = true;
		}
		else
		{
			mode = DsHlp.OAFALSE;
			hr = videoWin.put_FullScreenMode( mode );
			if( hr >= 0 )
				fullScreen = false;
			hr = videoWin.put_MessageDrain( drainWin );
			this.BringToFront();
			this.Refresh();
		}
	}

	private void menuHelpAbout_Click( object sender, System.EventArgs e )
	{
		MessageBox.Show( this, "Presented by:\r\nNETMaster", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Information );
	}


		/// <summary> file name of clip. </summary>
	private	string					clipFile;

		/// <summary> flag to detect first Form appearance </summary>
	private bool					firstActive;

		/// <summary> type of clip, video / audio. </summary>
	private	ClipType				clipType;
	private	PlayState				playState;
	private	bool					fullScreen;

	private IGraphBuilder			graphBuilder;

		/// <summary> control interface. </summary>
	private IMediaControl			mediaCtrl;

		/// <summary> graph event interface. </summary>
	private IMediaEventEx			mediaEvt;

		/// <summary> seek interface for positioning in stream. </summary>
	private IMediaSeeking			mediaSeek;
		/// <summary> seek interface to set position in stream. </summary>
	private IMediaPosition			mediaPos;

		/// <summary> video preview window interface. </summary>
	private IVideoWindow			videoWin;
		/// <summary> interface to get information and control video. </summary>
	private IBasicVideo2			basicVideo;
		/// <summary> interface to single-step video. </summary>
	private IVideoFrameStep			videoStep;

		/// <summary> audio interface used to control volume. </summary>
	private IBasicAudio				basicAudio;
	private int						savedVolume = -5000;
	private IntPtr					drainWin;


	private const int WM_GRAPHNOTIFY	= 0x00008001;	// message from graph

	private const int WS_CHILD			= 0x40000000;	// attributes for video window
	private const int WS_CLIPCHILDREN	= 0x02000000;
	private const int WS_CLIPSIBLINGS	= 0x04000000;

	private const string clipFileFilters =
		"Video Files (avi qt mov mpg mpeg m1v)|*.avi;*.qt;*.mov;*.mpg;*.mpeg;*.m1v|" +
		"Audio files (wav mpa mp2 mp3 au aif aiff snd)|*.wav;*.mpa;*.mp2;*.mp3;*.au;*.aif;*.aiff;*.snd|" +
		"MIDI Files (mid midi rmi)|*.mid;*.midi;*.rmi|" +
		"Image Files (jpg bmp gif tga)|*.jpg;*.bmp;*.gif;*.tga|" +
		"All Files (*.*)|*.*";

}

internal enum PlayState
{
	Init, Stopped, Paused, Running
}

internal enum ClipType
{
	None, AudioVideo, VideoOnly, AudioOnly
}


} // namespace PlayWndNET
