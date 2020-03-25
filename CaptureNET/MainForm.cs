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
using DShowNET.Device;

namespace CaptureNET
{
/// <summary> Summary description for MainForm. </summary>
public class MainForm : System.Windows.Forms.Form
{
	private System.ComponentModel.IContainer components;
	private System.Windows.Forms.ToolBar toolBar;
	private System.Windows.Forms.Panel videoPanel;
	private System.Windows.Forms.ImageList tbarImageList;
	private System.Windows.Forms.ToolBarButton tbtnStop;

	public MainForm()
	{
		// Required for Windows Form Designer support
		InitializeComponent();
	}

	/// <summary> Clean up any resources being used. </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.tbtnStop = new System.Windows.Forms.ToolBarButton();
            this.tbarImageList = new System.Windows.Forms.ImageList(this.components);
            this.videoPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbtnStop});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.tbarImageList;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(432, 41);
            this.toolBar.TabIndex = 0;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnStop
            // 
            this.tbtnStop.ImageIndex = 0;
            this.tbtnStop.Name = "tbtnStop";
            this.tbtnStop.Text = "Stop";
            // 
            // tbarImageList
            // 
            this.tbarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tbarImageList.ImageStream")));
            this.tbarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tbarImageList.Images.SetKeyName(0, "");
            // 
            // videoPanel
            // 
            this.videoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPanel.Location = new System.Drawing.Point(0, 41);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(432, 364);
            this.videoPanel.TabIndex = 1;
            this.videoPanel.Resize += new System.EventHandler(this.videoPanel_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(432, 405);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.toolBar);
            this.Name = "MainForm";
            this.Text = "Capture .NET";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new MainForm());
	}

	private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		this.Hide();
		CloseInterfaces();
	}


		/// <summary> handler for ToolBar button clicks. </summary>
	private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
	{
		if( capGraph == null )
			return;

		if( e.Button == tbtnStop )
		{
			this.Close();
		}
	}


		/// <summary> detect first form appearance, start capturing. </summary>
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

		if( ! DsDev.GetDevicesOfCat( FilterCategory.VideoInputDevice, out capDevices ) )
		{
			MessageBox.Show( this, "No video capture devices found!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			this.Close(); return;
		}

		SaveFileDialog sd = new SaveFileDialog();
		sd.FileName = @"CaptureNET.avi";
		sd.Title = "Save Video Stream as...";
		sd.Filter = "Video file (*.avi)|*.avi";
		sd.FilterIndex = 1;
		if( sd.ShowDialog() != DialogResult.OK )
			{ this.Close(); return; }
		fileName = sd.FileName;

		DsDevice dev = null;
		if( capDevices.Count == 1 )
			dev = capDevices[0] as DsDevice;
		else
		{
			DeviceSelector selector = new DeviceSelector( capDevices );
			selector.ShowDialog( this );
			dev = selector.SelectedDevice;
		}

		if( dev == null )
		{
			this.Close(); return;
		}

		if( ! StartupVideo( dev.Mon ) )
			this.Close();
		this.Text = "- capturing -";
	}

		/// <summary> start all the interfaces, graphs and preview window. </summary>
	bool StartupVideo( UCOMIMoniker mon )
	{
		int hr;
		try {
			if( ! CreateCaptureDevice( mon ) )
				return false;

			if( ! GetInterfaces() )
				return false;

			if( ! SetupGraph() )
				return false;

			if( ! SetupVideoWindow() )
				return false;

			#if DEBUG
				DsROT.AddGraphToRot( graphBuilder, out rotCookie );		// graphBuilder capGraph
			#endif
			
			hr = mediaCtrl.Run();
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not start video stream\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
	}


		/// <summary> build the capture graph. </summary>
	bool SetupGraph()
	{
		int hr;
		IBaseFilter		mux = null;
		IFileSinkFilter	sink = null;

		try {
			hr = capGraph.SetFiltergraph( graphBuilder );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			hr = graphBuilder.AddFilter( capFilter, "Ds.NET Video Capture Device" );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			DsUtils.ShowCapPinDialog( capGraph, capFilter, this.Handle );

			Guid sub = MediaSubType.Avi;
			hr = capGraph.SetOutputFileName( ref sub, fileName, out mux, out sink );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			Guid cat = PinCategory.Capture;
			Guid med = MediaType.Video;
			hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, mux ); // stream to file 
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			cat = PinCategory.Preview;
			med = MediaType.Video;
			hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, null ); // preview window
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not setup graph\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
		finally
		{
			if( mux != null )
				Marshal.ReleaseComObject( mux ); mux = null;
			if( sink != null )
				Marshal.ReleaseComObject( sink ); sink = null;
		}
	}


		/// <summary> create the used COM components and get the interfaces. </summary>
	bool GetInterfaces()
	{
		Type comType = null;
		object comObj = null;
		try {
			comType = Type.GetTypeFromCLSID( Clsid.FilterGraph );
			if( comType == null )
				throw new NotImplementedException( @"DirectShow FilterGraph not installed/registered!" );
			comObj = Activator.CreateInstance( comType );
			graphBuilder = (IGraphBuilder) comObj; comObj = null;

			Guid clsid = Clsid.CaptureGraphBuilder2;
			Guid riid = typeof(ICaptureGraphBuilder2).GUID;
			comObj = DsBugWO.CreateDsInstance( ref clsid, ref riid );
			capGraph = (ICaptureGraphBuilder2) comObj; comObj = null;

			mediaCtrl	= (IMediaControl)	graphBuilder;
			videoWin	= (IVideoWindow)	graphBuilder;
			mediaEvt	= (IMediaEventEx)	graphBuilder;
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not get interfaces\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
		finally
		{
			if( comObj != null )
				Marshal.ReleaseComObject( comObj ); comObj = null;
		}
	}


		/// <summary> create the user selected capture device. </summary>
	bool CreateCaptureDevice( UCOMIMoniker mon )
	{
		object capObj = null;
		try {
			Guid gbf = typeof( IBaseFilter ).GUID;
			mon.BindToObject( null, null, ref gbf, out capObj );
			capFilter = (IBaseFilter) capObj; capObj = null;
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not create capture device\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
		finally
		{
			if( capObj != null )
				Marshal.ReleaseComObject( capObj ); capObj = null;
		}

	}

		/// <summary> make the video preview window to show in videoPanel. </summary>
	bool SetupVideoWindow()
	{
		int hr;
		try {
			// Set the video window to be a child of the main window
			hr = videoWin.put_Owner( videoPanel.Handle );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			// Set video window style
			hr = videoWin.put_WindowStyle( WS_CHILD | WS_CLIPCHILDREN );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			// Use helper function to position video window in client rect of owner window
			ResizeVideoWindow();

			// Make the video window visible, now that it is properly positioned
			hr = videoWin.put_Visible( DsHlp.OATRUE );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			return true;
		}
		catch( Exception ee )
		{
			MessageBox.Show( this, "Could not setup video window\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			return false;
		}
	}

		/// <summary> the videoPanel is resized. </summary>
	private void videoPanel_Resize(object sender, System.EventArgs e)
	{
		ResizeVideoWindow();
	}

		/// <summary> if the videoPanel is resized, adjust video preview window. </summary>
	void ResizeVideoWindow()
	{
		if( videoWin != null )
		{
			Rectangle rc = videoPanel.ClientRectangle;
			videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
		}
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
		DsEvCode	code;
		int p1, p2, hr = 0;
		do
		{
			hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
			if( hr < 0 )
				break;
			hr = mediaEvt.FreeEventParams( code, p1, p2 );
		}
		while( hr == 0 );
	}


		/// <summary> do cleanup and release DirectShow. </summary>
	void CloseInterfaces()
	{
		int hr;
		try {
			#if DEBUG
				if( rotCookie != 0 )
					DsROT.RemoveGraphFromRot( ref rotCookie );
			#endif

			if( mediaCtrl != null )
			{
				hr = mediaCtrl.Stop();
				mediaCtrl = null;
			}

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

			if( capGraph != null )
				Marshal.ReleaseComObject( capGraph ); capGraph = null;

			if( graphBuilder != null )
				Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

			if( capFilter != null )
				Marshal.ReleaseComObject( capFilter ); capFilter = null;
			
			if( capDevices != null )
			{
				foreach( DsDevice d in capDevices )
					d.Dispose();
				capDevices = null;
			}
		}
		catch( Exception )
		{}
	}


		/// <summary> flag to detect first Form appearance </summary>
	private bool					firstActive;
		/// <summary> file name for AVI. </summary>
	private string					fileName;

		/// <summary> list of installed video devices. </summary>
	private ArrayList				capDevices;

		/// <summary> base filter of the actually used video devices. </summary>
	private IBaseFilter				capFilter;

		/// <summary> graph builder interface. </summary>
	private IGraphBuilder			graphBuilder;

		/// <summary> capture graph builder interface. </summary>
	private ICaptureGraphBuilder2	capGraph;

		/// <summary> video window interface. </summary>
	private IVideoWindow			videoWin;

		/// <summary> control interface. </summary>
	private IMediaControl			mediaCtrl;

		/// <summary> event interface. </summary>
	private IMediaEventEx			mediaEvt;

	private const int WM_GRAPHNOTIFY	= 0x00008001;	// message from graph

	private const int WS_CHILD			= 0x40000000;	// attributes for video window
	private const int WS_CLIPCHILDREN	= 0x02000000;
	private const int WS_CLIPSIBLINGS	= 0x04000000;

	#if DEBUG
		private int		rotCookie = 0;
	#endif
	}

}
