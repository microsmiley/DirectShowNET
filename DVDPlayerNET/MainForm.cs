/******************************************************
                  DirectShow .NET
		      netmaster@swissonline.ch
*******************************************************/
//				DVDPlayerNET MainForm

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

using DShowNET;
using DShowNET.Dvd;


namespace DVDPlayerNET
{


/// <summary> MainForm for DVD Player. </summary>
public class MainForm : System.Windows.Forms.Form
{
	/// <summary> Required designer variable. </summary>
	private System.ComponentModel.Container components = null;
	private System.Windows.Forms.MainMenu mainMenu;
	private System.Windows.Forms.MenuItem menuTopFile;
	private System.Windows.Forms.MenuItem menuFileSelDVD;
	private System.Windows.Forms.MenuItem menuFileCloseDVD;
	private System.Windows.Forms.MenuItem menuFileSep1;
	private System.Windows.Forms.MenuItem menuFileExit;
	private System.Windows.Forms.MenuItem menuTopPlayback;
	private System.Windows.Forms.MenuItem menuPbackPlay;
	private System.Windows.Forms.MenuItem menuPbackPause;
	private System.Windows.Forms.MenuItem menuPbackStop;
	private System.Windows.Forms.MenuItem menuPbackStepFw;
	private System.Windows.Forms.MenuItem menuPbackSep1;
	private System.Windows.Forms.MenuItem menuPbackGoTo;
	private System.Windows.Forms.MenuItem menuPbackNextChapt;
	private System.Windows.Forms.MenuItem menuPbackPrevChapt;
	private System.Windows.Forms.MenuItem menuPbackSep2;
	private System.Windows.Forms.MenuItem menuPbackFullscreen;
	private System.Windows.Forms.MenuItem menuTopOptions;
	private System.Windows.Forms.MenuItem menuOptionRootMenu;
	private System.Windows.Forms.MenuItem menuOptionSep1;
	private System.Windows.Forms.MenuItem menuOptionVideoAttr;
	private System.Windows.Forms.MenuItem menuOptionTitleMenu;

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
		this.mainMenu = new System.Windows.Forms.MainMenu();
		this.menuTopFile = new System.Windows.Forms.MenuItem();
		this.menuFileSelDVD = new System.Windows.Forms.MenuItem();
		this.menuFileCloseDVD = new System.Windows.Forms.MenuItem();
		this.menuFileSep1 = new System.Windows.Forms.MenuItem();
		this.menuFileExit = new System.Windows.Forms.MenuItem();
		this.menuTopPlayback = new System.Windows.Forms.MenuItem();
		this.menuPbackPlay = new System.Windows.Forms.MenuItem();
		this.menuPbackPause = new System.Windows.Forms.MenuItem();
		this.menuPbackStop = new System.Windows.Forms.MenuItem();
		this.menuPbackStepFw = new System.Windows.Forms.MenuItem();
		this.menuPbackSep1 = new System.Windows.Forms.MenuItem();
		this.menuPbackGoTo = new System.Windows.Forms.MenuItem();
		this.menuPbackNextChapt = new System.Windows.Forms.MenuItem();
		this.menuPbackPrevChapt = new System.Windows.Forms.MenuItem();
		this.menuPbackSep2 = new System.Windows.Forms.MenuItem();
		this.menuPbackFullscreen = new System.Windows.Forms.MenuItem();
		this.menuTopOptions = new System.Windows.Forms.MenuItem();
		this.menuOptionRootMenu = new System.Windows.Forms.MenuItem();
		this.menuOptionTitleMenu = new System.Windows.Forms.MenuItem();
		this.menuOptionSep1 = new System.Windows.Forms.MenuItem();
		this.menuOptionVideoAttr = new System.Windows.Forms.MenuItem();
		// 
		// mainMenu
		// 
		this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.menuTopFile,
																				 this.menuTopPlayback,
																				 this.menuTopOptions});
		// 
		// menuTopFile
		// 
		this.menuTopFile.Index = 0;
		this.menuTopFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuFileSelDVD,
																					this.menuFileCloseDVD,
																					this.menuFileSep1,
																					this.menuFileExit});
		this.menuTopFile.Text = "&File";
		// 
		// menuFileSelDVD
		// 
		this.menuFileSelDVD.Enabled = false;
		this.menuFileSelDVD.Index = 0;
		this.menuFileSelDVD.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
		this.menuFileSelDVD.Text = "&Select DVD media";
		this.menuFileSelDVD.Click += new System.EventHandler(this.menuFileSelDVD_Click);
		// 
		// menuFileCloseDVD
		// 
		this.menuFileCloseDVD.Enabled = false;
		this.menuFileCloseDVD.Index = 1;
		this.menuFileCloseDVD.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
		this.menuFileCloseDVD.Text = "&Close DVD";
		this.menuFileCloseDVD.Click += new System.EventHandler(this.menuFileCloseDVD_Click);
		// 
		// menuFileSep1
		// 
		this.menuFileSep1.Index = 2;
		this.menuFileSep1.Text = "-";
		// 
		// menuFileExit
		// 
		this.menuFileExit.Index = 3;
		this.menuFileExit.Text = "E&xit";
		this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
		// 
		// menuTopPlayback
		// 
		this.menuTopPlayback.Index = 1;
		this.menuTopPlayback.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuPbackPlay,
																						this.menuPbackPause,
																						this.menuPbackStop,
																						this.menuPbackStepFw,
																						this.menuPbackSep1,
																						this.menuPbackGoTo,
																						this.menuPbackSep2,
																						this.menuPbackFullscreen});
		this.menuTopPlayback.Text = "&Playback";
		// 
		// menuPbackPlay
		// 
		this.menuPbackPlay.Index = 0;
		this.menuPbackPlay.Text = "&Play\tP";
		this.menuPbackPlay.Click += new System.EventHandler(this.menuPbackPlay_Click);
		// 
		// menuPbackPause
		// 
		this.menuPbackPause.Enabled = false;
		this.menuPbackPause.Index = 1;
		this.menuPbackPause.Text = "P&ause\tA";
		this.menuPbackPause.Click += new System.EventHandler(this.menuPbackPause_Click);
		// 
		// menuPbackStop
		// 
		this.menuPbackStop.Enabled = false;
		this.menuPbackStop.Index = 2;
		this.menuPbackStop.Text = "&Stop\tS";
		this.menuPbackStop.Click += new System.EventHandler(this.menuPbackStop_Click);
		// 
		// menuPbackStepFw
		// 
		this.menuPbackStepFw.Enabled = false;
		this.menuPbackStepFw.Index = 3;
		this.menuPbackStepFw.Text = "S&tep Forward\t<SPACE>";
		this.menuPbackStepFw.Click += new System.EventHandler(this.menuPbackStepFw_Click);
		// 
		// menuPbackSep1
		// 
		this.menuPbackSep1.Index = 4;
		this.menuPbackSep1.Text = "-";
		// 
		// menuPbackGoTo
		// 
		this.menuPbackGoTo.Enabled = false;
		this.menuPbackGoTo.Index = 5;
		this.menuPbackGoTo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuPbackNextChapt,
																					  this.menuPbackPrevChapt});
		this.menuPbackGoTo.Text = "&Go To";
		// 
		// menuPbackNextChapt
		// 
		this.menuPbackNextChapt.Enabled = false;
		this.menuPbackNextChapt.Index = 0;
		this.menuPbackNextChapt.Text = "&Next Chapter\tN";
		this.menuPbackNextChapt.Click += new System.EventHandler(this.menuPbackNextChapt_Click);
		// 
		// menuPbackPrevChapt
		// 
		this.menuPbackPrevChapt.Enabled = false;
		this.menuPbackPrevChapt.Index = 1;
		this.menuPbackPrevChapt.Text = "&Previous Chapter\tR";
		this.menuPbackPrevChapt.Click += new System.EventHandler(this.menuPbackPrevChapt_Click);
		// 
		// menuPbackSep2
		// 
		this.menuPbackSep2.Index = 6;
		this.menuPbackSep2.Text = "-";
		// 
		// menuPbackFullscreen
		// 
		this.menuPbackFullscreen.Enabled = false;
		this.menuPbackFullscreen.Index = 7;
		this.menuPbackFullscreen.Text = "&Fullscreen\tF";
		this.menuPbackFullscreen.Click += new System.EventHandler(this.menuPbackFullscreen_Click);
		// 
		// menuTopOptions
		// 
		this.menuTopOptions.Index = 2;
		this.menuTopOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuOptionRootMenu,
																					   this.menuOptionTitleMenu,
																					   this.menuOptionSep1,
																					   this.menuOptionVideoAttr});
		this.menuTopOptions.Text = "&Options";
		// 
		// menuOptionRootMenu
		// 
		this.menuOptionRootMenu.Enabled = false;
		this.menuOptionRootMenu.Index = 0;
		this.menuOptionRootMenu.Text = "Show R&oot Menu\t<Home>";
		this.menuOptionRootMenu.Click += new System.EventHandler(this.menuOptionRootMenu_Click);
		// 
		// menuOptionTitleMenu
		// 
		this.menuOptionTitleMenu.Enabled = false;
		this.menuOptionTitleMenu.Index = 1;
		this.menuOptionTitleMenu.Text = "Show Title &Menu\tM";
		this.menuOptionTitleMenu.Click += new System.EventHandler(this.menuOptionTitleMenu_Click);
		// 
		// menuOptionSep1
		// 
		this.menuOptionSep1.Index = 2;
		this.menuOptionSep1.Text = "-";
		// 
		// menuOptionVideoAttr
		// 
		this.menuOptionVideoAttr.Enabled = false;
		this.menuOptionVideoAttr.Index = 3;
		this.menuOptionVideoAttr.Text = "Get Video Attributes...\tI";
		this.menuOptionVideoAttr.Click += new System.EventHandler(this.menuOptionVideoAttr_Click);
		// 
		// MainForm
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.Black;
		this.ClientSize = new System.Drawing.Size(568, 397);
		this.Menu = this.mainMenu;
		this.Name = "MainForm";
		this.Text = ".NET DVD Player";
		this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
		this.Resize += new System.EventHandler(this.MainForm_Resize);
		this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
		this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
		this.Activated += new System.EventHandler(this.MainForm_Activated);
		this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);

	}
	#endregion


	/// <summary> The main entry point for the application. </summary>
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

	private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		CloseInterfaces();
	}

	private void MainForm_Resize( object sender, System.EventArgs e )
	{
		ResizeVideoWindow();
	}

		/// <summary> menu clicked to open DVD volume. </summary>
	private void menuFileSelDVD_Click(object sender, System.EventArgs e)
	{
		// NOT YET IMPL.
	}

		/// <summary> menu clicked to close DVD volume. </summary>
	private void menuFileCloseDVD_Click(object sender, System.EventArgs e)
	{
		CloseInterfaces();
		UpdateMenu();
		UpdateFrameCaption();
	}

	private void menuFileExit_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}

		/// <summary> menu clicked to start playback. </summary>
	private void menuPbackPlay_Click(object sender, System.EventArgs e)
	{
		if( playState == PlayState.Init )
			FirstPlayDvd();
		else
		{
			if( (mediaCtrl == null) || (playState == PlayState.Playing) )
				return;
				
			int hr = mediaCtrl.Run();
			if( hr >= 0 )
				playState = PlayState.Playing;

			if( (menuMode == MenuMode.Still) && (dvdCtrl != null) )
				hr = dvdCtrl.StillOff();
		}
		UpdateMenu();
		UpdateFrameCaption();
	}

		/// <summary> menu clicked to pause playback. </summary>
	private void menuPbackPause_Click(object sender, System.EventArgs e)
	{
		if( (mediaCtrl == null) || (playState != PlayState.Playing) )
			return;
		int hr = mediaCtrl.Pause();
		if( hr >= 0 )
		{
			playState = PlayState.Paused;
			UpdateMenu();
			UpdateFrameCaption();
		}
	}

		/// <summary> menu clicked to stop playback. </summary>
	private void menuPbackStop_Click(object sender, System.EventArgs e)
	{
		if( (mediaCtrl == null) ||
			((playState != PlayState.Playing) && (playState != PlayState.Paused) ) )
			return;
		int hr = mediaCtrl.Stop();
		if( hr >= 0 )
		{
			playState = PlayState.Stopped;
			UpdateMenu();
			UpdateFrameCaption();
		}
	}

		/// <summary> menu clicked to single-step. </summary>
	private void menuPbackStepFw_Click(object sender, System.EventArgs e)
	{
		int hr;
		if( (videoStep == null) || (mediaCtrl == null) )
			return;
		if( playState != PlayState.Paused )
			hr = mediaCtrl.Pause();
		playState = PlayState.Paused;
		hr = videoStep.Step( 1, null );
		UpdateMenu();
		UpdateFrameCaption();
	}

		/// <summary> menu clicked to play next chapter. </summary>
	private void menuPbackNextChapt_Click(object sender, System.EventArgs e)
	{
		if( (playState != PlayState.Playing) || (dvdCtrl == null) )
			return;

		int hr = dvdCtrl.PlayNextChapter( DvdCmdFlags.SendEvt, cmdOption );
		if( hr < 0 )
			{
			Trace.WriteLine( "!!! PlayNextChapter error : 0x" + hr.ToString("x") );
			return;
			}

		if( cmdOption.dvdCmd != null )
			{
			Trace.WriteLine( "PlayNextChapter cmd pending.........." );
			pendingCmd = true;
			}

		UpdateMenu();
	}

		/// <summary> menu clicked to play previous chapter. </summary>
	private void menuPbackPrevChapt_Click( object sender, System.EventArgs e )
	{
		if( (playState != PlayState.Playing) || (dvdCtrl == null) )
			return;

		int hr = dvdCtrl.PlayPrevChapter( DvdCmdFlags.SendEvt, cmdOption );
		if( hr < 0 )
			{
			Trace.WriteLine( "!!! PlayPrevChapter error : 0x" + hr.ToString("x") );
			return;
			}

		if( cmdOption.dvdCmd != null )
			{
			Trace.WriteLine( "PlayPrevChapter cmd pending.........." );
			pendingCmd = true;
			}

		UpdateMenu();
	}


	private void menuPbackFullscreen_Click(object sender, System.EventArgs e)
	{
		ToggleFullScreen();
	}

		/// <summary> menu clicked to show dvd-root-menu. </summary>
	private void menuOptionRootMenu_Click( object sender, System.EventArgs e )
	{
		if( (playState != PlayState.Playing) || (dvdCtrl == null) )
			return;
		int hr = dvdCtrl.ShowMenu( DvdMenuID.Root, DvdCmdFlags.Block | DvdCmdFlags.Flush, null );
	}

		/// <summary> menu clicked to show dvd-title-menu. </summary>
	private void menuOptionTitleMenu_Click( object sender, System.EventArgs e )
	{
		if( (playState != PlayState.Playing) || (dvdCtrl == null) )
			return;
		int hr = dvdCtrl.ShowMenu( DvdMenuID.Title, DvdCmdFlags.Block | DvdCmdFlags.Flush, null );
	}

		/// <summary> show dialog about dvd information. </summary>
	private void menuOptionVideoAttr_Click(object sender, System.EventArgs e)
	{
		if( (playState != PlayState.Playing) || (dvdInfo == null) )
			return;
		DvdVideoAttr att;
		dvdInfo.GetCurrentVideoAttributes( out att );
		StringBuilder txt = new StringBuilder( 600 );
		txt.AppendFormat( "Resolution  : {0} / {1}\r\n", att.sourceResolutionX.ToString(), att.sourceResolutionY.ToString() );
		txt.AppendFormat( "Aspect      : {0} : {1}\r\n", att.aspectX.ToString(), att.aspectY.ToString() );
		txt.AppendFormat( "Frame Rate  : {0}\r\n", att.frameRate.ToString() );
		txt.AppendFormat( "Compression : {0}\r\n", att.compression.ToString() );
		MessageBox.Show( this, txt.ToString(), "GetCurrentVideoAttributes", MessageBoxButtons.OK, MessageBoxIcon.Information );
	}


		/// <summary> handling the very first start of dvd playback. </summary>
	bool FirstPlayDvd()
	{
		int hr;
		
		try {
			pendingCmd = true; UpdateMenu();
			
			CloseInterfaces();
			if( ! GetInterfaces() )
				return false;

			hr = dvdCtrl.SetOption( DvdOptionFlag.HmsfTimeCodeEvt, true );	// use new HMSF timecode format
			if( hr >= 0 )
				hr = dvdCtrl.SetOption( DvdOptionFlag.ResetOnStop, false );
			if( hr >= 0 )
				hr = mediaEvt.SetNotifyWindow( this.Handle, WM_DVD_EVENT, IntPtr.Zero );
			if( hr >= 0 )
				hr = videoWin.put_Owner( this.Handle );
			if( hr >= 0 )
				hr = videoWin.put_WindowStyle( WS_CHILD | WS_CLIPSIBLINGS | WS_CLIPCHILDREN );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			ResizeVideoWindow();

			hr = mediaCtrl.Run();
			if( hr >= 0 )
				hr = videoWin.put_MessageDrain( this.Handle );
			if( hr >= 0 )
				hr = dvdCtrl.PlayForwards( 1.0, DvdCmdFlags.None, null );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			playState = PlayState.Playing;
			pendingCmd = false;
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not start DVD\r\n" + ee.Message, "DVDPlayer.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			CloseInterfaces();
			return false;
		}
	}


		/// <summary> resize preview video window to fill client area. </summary>
	void ResizeVideoWindow()
	{
		if( videoWin == null )
			return;
		Rectangle rc = this.ClientRectangle;
		int hr = videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
	}


		/// <summary> create the used COM components and get the interfaces. </summary>
	bool GetInterfaces()
	{
		int		hr;
		Type	comtype = null;
		object	comobj = null;
		DvdRenderStatus status;

		try {
			comtype = Type.GetTypeFromCLSID( Clsid.DvdGraphBuilder );
			if( comtype == null )
				throw new NotSupportedException( "DirectX (8.1 or higher) not installed?" );
			comobj = Activator.CreateInstance( comtype );
			dvdGraph = (IDvdGraphBuilder) comobj; comobj = null;
			
			hr = dvdGraph.RenderDvdVideoVolume( null, DvdGraphFlags.Default, out status );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			Guid riid = typeof( IDvdInfo2 ).GUID;
			hr = dvdGraph.GetDvdInterface( ref riid, out comobj );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			dvdInfo = (IDvdInfo2) comobj; comobj = null;

			riid = typeof( IDvdControl2 ).GUID;
			hr = dvdGraph.GetDvdInterface( ref riid, out comobj );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			dvdCtrl = (IDvdControl2) comobj; comobj = null;

			hr = dvdGraph.GetFiltergraph( out graphBuilder );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			mediaCtrl	= (IMediaControl)  graphBuilder;
			mediaEvt	= (IMediaEventEx)  graphBuilder;

			riid = typeof( IVideoWindow ).GUID;
			hr = dvdGraph.GetDvdInterface( ref riid, out comobj );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			videoWin = (IVideoWindow) comobj; comobj = null;

			GetFrameStepInterface();
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not get interfaces\r\n" + ee.Message, "DVDPlayer.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			CloseInterfaces();
			return false;
		}
		finally
		{
			if( comobj != null )
				Marshal.ReleaseComObject( comobj ); comobj = null;
		}
	}


		/// <summary> detect if we can single step. </summary>
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


		/// <summary> do cleanup and release DirectShow. </summary>
	void CloseInterfaces()
	{
		int hr;
		try {
			if( dvdCtrl != null )
				hr = dvdCtrl.SetOption( DvdOptionFlag.ResetOnStop, true );

			if( mediaCtrl != null )
			{
				hr = mediaCtrl.Stop();
				mediaCtrl = null;
			}
			playState = PlayState.Stopped;

			if( mediaEvt != null )
			{
				hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_DVD_EVENT, IntPtr.Zero );
				mediaEvt = null;
			}

			if( videoWin != null )
			{
				hr = videoWin.put_Visible( DsHlp.OAFALSE );
				hr = videoWin.put_MessageDrain( IntPtr.Zero );
				hr = videoWin.put_Owner( IntPtr.Zero );
				videoWin = null;
			}

			videoStep	= null;

			if( cmdOption.dvdCmd != null )
				Marshal.ReleaseComObject( cmdOption.dvdCmd ); cmdOption.dvdCmd = null;
			pendingCmd = false;

			if( graphBuilder != null )
				Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

			dvdCtrl		= null;
			if( dvdInfo != null )
				Marshal.ReleaseComObject( dvdInfo ); dvdInfo = null;

			if( dvdGraph != null )
				Marshal.ReleaseComObject( dvdGraph ); dvdGraph = null;

			playState = PlayState.Init;
		}
		catch( Exception )
		{}
	}

	void ToggleFullScreen()
	{
		if( videoWin == null )
			return;

		int mode;
		int hr = videoWin.get_FullScreenMode( out mode );
		if( mode == DsHlp.OAFALSE )
		{
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
			this.TopMost = true;
			this.Refresh();
		}
	}


		/// <summary> override message handler to get dvd events</summary>
	protected override void WndProc( ref Message m )
	{
		if( m.Msg == WM_DVD_EVENT )
			{
			if( mediaEvt != null )
				OnDvdEvent();
			return;
			}
		base.WndProc( ref m );
	}


		/// <summary> DVD event message handler</summary>
	void OnDvdEvent()
	{
		int p1, p2, hr = 0;
		DsEvCode code;
		do
		{
			hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
			if( hr < 0 )
				break;

			// Trace.WriteLine( "DVD EVT :" + code.ToString() );
			
			switch( code )
			{
				case DsEvCode.DvdCurrentHmsfTime:
				{
					byte[] ati = BitConverter.GetBytes( p1 );
					currnTime.bHours	= ati[0];
					currnTime.bMinutes	= ati[1];
					currnTime.bSeconds	= ati[2];
					currnTime.bFrames	= ati[3];
					UpdateFrameCaption();
					break;
				}
				case DsEvCode.DvdChaptStart:
				{
					currnChapter = p1;
					UpdateFrameCaption();
					break;
				}
				case DsEvCode.DvdTitleChange:
				{
					currnTitle = p1;
					UpdateFrameCaption();
					break;
				}
				case DsEvCode.DvdDomChange:
				{
					currnDomain = (DvdDomain) p1;
					UpdateFrameCaption();
					break;
				}
			
				case DsEvCode.DvdCmdStart:
				{
					if( pendingCmd )
						Trace.WriteLine( "  DvdCmdStart with pending" );
					break;
				}
				case DsEvCode.DvdCmdEnd:
				{
					OnCmdComplete( p1, p2 );
					break;
				}

				case DsEvCode.DvdStillOn:
				{
					if( p1 == 0 )
						menuMode = MenuMode.Buttons;
					else
						menuMode = MenuMode.Still;
					break;
				}
				case DsEvCode.DvdStillOff:
				{
					if( menuMode == MenuMode.Still )
						menuMode = MenuMode.No;
					break;
				}
				case DsEvCode.DvdButtonChange:
				{
					if( p1 <= 0 )
						menuMode = MenuMode.No;
					else
						menuMode = MenuMode.Buttons;
					break;
				}

				case DsEvCode.DvdNoFpPgc:
				{
					if( dvdCtrl != null )
						hr = dvdCtrl.PlayTitle( 1, DvdCmdFlags.None, null );
					break;
				}
			}

			hr = mediaEvt.FreeEventParams( code, p1, p2 );
		}
		while( hr == 0 );
	}


		/// <summary> update text of window caption</summary>
	void UpdateFrameCaption()
	{
		if( playState == PlayState.Init )
		{
			this.Text = "DVD";
			return;
		}
		string ti = String.Format( "{0:00}:{1:00}:{2:00}", currnTime.bHours, currnTime.bMinutes, currnTime.bSeconds );
		if( playState == PlayState.Paused )
			ti = ti + " (Paused)";
		else if( playState == PlayState.Stopped )
			ti = ti + " (Stopped)";

		this.Text = String.Format( "DVD Chapter:{0} Title:{1}  {2}", currnChapter, currnTitle, ti );
	}


		/// <summary> asynchronous command completed </summary>
	void OnCmdComplete( int p1, int hrg )
	{
		// Trace.WriteLine( "DVD OnCmdComplete.........." );
		if( (pendingCmd == false) || (dvdInfo == null) )
			return;

		IDvdCmd		cmd;
		int hr = dvdInfo.GetCmdFromEvent( p1, out cmd );
		if( (hr != 0) || (cmd == null) )
			{
			Trace.WriteLine( "!!!DVD OnCmdComplete GetCmdFromEvent failed!!!" );
			return;
			}

		if( cmd != cmdOption.dvdCmd )
		{
			Trace.WriteLine( "DVD OnCmdComplete UNKNOWN CMD!!!" );
			Marshal.ReleaseComObject( cmd ); cmd = null;
			return;
		}

		Marshal.ReleaseComObject( cmd ); cmd = null;
		Marshal.ReleaseComObject( cmdOption.dvdCmd ); cmdOption.dvdCmd = null;
		pendingCmd = false;
		// Trace.WriteLine( "DVD OnCmdComplete OK." );
		UpdateMenu();
	}

		/// <summary> update menu items to match current playback state </summary>
	private void UpdateMenu()
	{
		bool enable = (mediaCtrl != null) && (! pendingCmd);

		menuFileCloseDVD.Enabled	= enable;
		menuPbackPlay.Enabled		= (! pendingCmd) && (playState != PlayState.Playing);
		menuPbackPause.Enabled		= enable && (playState == PlayState.Playing);
		menuPbackStop.Enabled		= enable && ( (playState == PlayState.Playing) || (playState == PlayState.Paused));
		menuPbackStepFw.Enabled		= enable && ( (playState == PlayState.Playing) || (playState == PlayState.Paused));
		menuPbackGoTo.Enabled		= enable;
		menuPbackNextChapt.Enabled	= enable && (playState == PlayState.Playing);
		menuPbackPrevChapt.Enabled	= enable && (playState == PlayState.Playing);
		menuPbackFullscreen.Enabled	= enable;
		menuOptionRootMenu.Enabled	= enable && (playState == PlayState.Playing);
		menuOptionTitleMenu.Enabled	= enable && (playState == PlayState.Playing);
		menuOptionVideoAttr.Enabled	= enable && (playState == PlayState.Playing);
	}

		/// <summary> for dvd menus, forward mouse movements </summary>
	private void MainForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if( (dvdCtrl == null) || (menuMode != MenuMode.Buttons) )
			return;
		DsPOINT pt;
		pt.X = e.X;
		pt.Y = e.Y;
		dvdCtrl.SelectAtPosition( pt );
	}

		/// <summary> for dvd menus, forward mouse button clicks </summary>
	private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if( (dvdCtrl == null) || (menuMode != MenuMode.Buttons) )
			return;
		DsPOINT pt;
		pt.X = e.X;
		pt.Y = e.Y;
		dvdCtrl.ActivateAtPosition( pt );
	}

		/// <summary> keyboard handling for shortcuts. </summary>
	private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if( pendingCmd )
			return;

		if( e.KeyCode == Keys.P )
			{	menuPbackPlay_Click( null, null ); return; }

		if( playState == PlayState.Init )
			return;

		switch( e.KeyCode )
		{
			case Keys.A:
				{	menuPbackPause_Click( null, null ); break; }
			case Keys.S:
				{	menuPbackStop_Click( null, null ); break; }
			case Keys.D1:
			case Keys.Space:
				{	menuPbackStepFw_Click( null, null ); break; }

			case Keys.N:
				{	menuPbackNextChapt_Click( null, null ); break; }
			case Keys.R:
				{	menuPbackPrevChapt_Click( null, null ); break; }

			case Keys.F:
				{	menuPbackFullscreen_Click( null, null ); break; }
			case Keys.Escape:
			{
				if( fullScreen )
					ToggleFullScreen();
				break;
			}

			case Keys.Home:
				{	menuOptionRootMenu_Click( null, null ); break; }
			case Keys.M:
				{	menuOptionTitleMenu_Click( null, null ); break; }
			case Keys.I:
				{	menuOptionVideoAttr_Click( null, null ); break; }



			case Keys.Left:
			{
				if( (menuMode == MenuMode.Buttons) && (dvdCtrl != null) )
					dvdCtrl.SelectRelativeButton( DvdRelButton.Left );
				break;
			}
			case Keys.Right:
			{
				if( (menuMode == MenuMode.Buttons) && (dvdCtrl != null) )
					dvdCtrl.SelectRelativeButton( DvdRelButton.Right );
				break;
			}
			case Keys.Up:
			{
				if( (menuMode == MenuMode.Buttons) && (dvdCtrl != null) )
					dvdCtrl.SelectRelativeButton( DvdRelButton.Upper );
				break;
			}
			case Keys.Down:
			{
				if( (menuMode == MenuMode.Buttons) && (dvdCtrl != null) )
					dvdCtrl.SelectRelativeButton( DvdRelButton.Lower );
				break;
			}
			case Keys.Enter:
			{
				if( (menuMode == MenuMode.Buttons) && (dvdCtrl != null) )
					dvdCtrl.ActivateButton();
				else if( (menuMode == MenuMode.Still) && (dvdCtrl != null) )
					dvdCtrl.StillOff();
				break;
			}
		}
	}


		/// <summary> flag to detect first Form appearance </summary>
	private bool					firstActive;
	
		/// <summary> current state of playback (playing/paused/...) </summary>
	private	PlayState				playState;

		/// <summary> current mode of playback (movie/menu/still). </summary>
	private	MenuMode				menuMode;

		/// <summary> flag to toggle full-screen. </summary>
	private	bool					fullScreen;

		/// <summary> asynchronous command interface. </summary>
	private	OptIDvdCmd				cmdOption = new OptIDvdCmd();
		/// <summary> asynchronous command pending. </summary>
	private	bool					pendingCmd;

		/// <summary> dvd graph builder interface. </summary>
	private IDvdGraphBuilder		dvdGraph;
		/// <summary> dvd control interface. </summary>
	private IDvdControl2			dvdCtrl;
		/// <summary> dvd information interface. </summary>
	private IDvdInfo2				dvdInfo;

		/// <summary> dvd video playback window interface. </summary>
	private IVideoWindow			videoWin;

	private IGraphBuilder			graphBuilder;

		/// <summary> control interface. </summary>
	private IMediaControl			mediaCtrl;

		/// <summary> graph event interface. </summary>
	private IMediaEventEx			mediaEvt;

		/// <summary> interface to single-step video. </summary>
	private IVideoFrameStep			videoStep;

	private DvdTimeCode				currnTime;		// copy of current playback states, see OnDvdEvent()
	private int						currnTitle;
	private int						currnChapter;
	private DvdDomain				currnDomain;

	private const int WM_DVD_EVENT		= 0x00008002;	// message from dvd graph

	private const int WS_CHILD			= 0x40000000;	// attributes for video window
	private const int WS_CLIPCHILDREN	= 0x02000000;
	private const int WS_CLIPSIBLINGS	= 0x04000000;
}


internal enum PlayState
{
	Init, Playing, Paused, Stopped
}

internal enum MenuMode
{
	No, Buttons, Still
}

}
