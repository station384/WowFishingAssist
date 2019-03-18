using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Vision.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace TestScreenCapture
{
    public partial class MainForm : Form
    {
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int WM_SETTEXT = 0X000C;

        const UInt32 WM_KEYDOWN = 0x0100;
        const UInt32 WM_KEYUP = 0x0101;

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);



        //[DllImport("user32.dll", SetLastError = true)]
        //static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        IntPtr hWnd;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);



        const int VK_F5 = 0x74;
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);



        ScreenStateLogger screenStateLogger = new ScreenStateLogger();
        AForge.Vision.Motion.MotionDetector motionDetector = GetDefaultMotionDetector();

        int warmupTime = 5000 * 10000;
        long warmupStartTime =  DateTime.Now.Ticks + (10000 * 100000);
        bool inWarmupMode = true;
        System.Windows.Forms.Timer globalTimer = new System.Windows.Forms.Timer() { Interval=30000, Enabled= false};

        bool running = false;
        int origScreenHeight = 0;
        int origScreenWidth = 0;

        public static AForge.Vision.Motion.MotionDetector GetDefaultMotionDetector()
        {
            AForge.Vision.Motion.IMotionDetector detector = null;
            AForge.Vision.Motion.IMotionProcessing processor = null;
            AForge.Vision.Motion.MotionDetector motionDetector = null;

            //detector = new AForge.Vision.Motion.TwoFramesDifferenceDetector()
            //{
            //  DifferenceThreshold = 15,
            //  SuppressNoise = true
            //};

            //detector = new AForge.Vision.Motion.CustomFrameDifferenceDetector()
            //{
            //    DifferenceThreshold = 15,
            //    KeepObjectsEdges = true,
            //    SuppressNoise = true
            //};

            // This is currently the best one.
            detector = new AForge.Vision.Motion.SimpleBackgroundModelingDetector()
            {
                DifferenceThreshold = 15,
                FramesPerBackgroundUpdate = 5,
                KeepObjectsEdges = true,
                MillisecondsPerBackgroundUpdate = 5,
                SuppressNoise = true
            };

            //processor = new AForge.Vision.Motion.GridMotionAreaProcessing()
            //{
            //  HighlightColor = System.Drawing.Color.Red,
            //  HighlightMotionGrid = true,
            //  GridWidth = 100,
            //  GridHeight = 100,
            //  MotionAmountToHighlight = 100F
            //};

            processor = new AForge.Vision.Motion.BlobCountingObjectsProcessing()
            {
                HighlightColor = System.Drawing.Color.Red,
                HighlightMotionRegions = true,
                MinObjectsHeight = 20,
                MinObjectsWidth = 20
            };
        
            motionDetector = new AForge.Vision.Motion.MotionDetector(detector, processor);

            return (motionDetector);
        }

        public MainForm()
        {
            InitializeComponent();

        }

        private async void sendFishingCastCommand ()
        {
            Point pt = new Point(10, 10);
            Cursor.Position = pt;
            PostMessage(hWnd, WM_KEYDOWN, 0xBB, 0);
            //Thread.Sleep(100);
            await Task.Delay(100);
            PostMessage(hWnd, WM_KEYUP, 0xBB, 0);

        }

        private async void GlobalTimer_Tick(object sender, EventArgs e)
        {

            // These event fires after 30 seconds.   This is a safety catch to make sure there is a recast.    
            // If no motion as been detected this will fire, if motion has been detected then the timer for this event is reset.
            globalTimer.Enabled = false;
            if (!running) return;
            motionDetector.Reset();   

            // Use this instead of thread.sleep to avoid pausing of the program. 
            await Task.Delay(5000);   // This delay is to allow the motion detection to settle down and relearn the new background without the bobber being there.
            sendFishingCastCommand();  //  Inject a keyDown and keyUp event into windows for the '=' key.  Todo: The key should be configurable.

            inWarmupMode = true;
            warmupStartTime = DateTime.Now.Ticks;
            globalTimer.Enabled = true;
        }

        public async void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            await Task.Delay(100);
            mouse_event( MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            await Task.Delay(100);
        }

        private async void detectMovement (Bitmap b)
        {
            float motionLevel = 0;
            motionLevel = motionDetector.ProcessFrame(b);
            if (inWarmupMode || !running)
            {
                if (DateTime.Now.Ticks - warmupTime > warmupStartTime)
                    inWarmupMode = false;
                
                return;
            }
           
         
        
            Rectangle[] i = ((AForge.Vision.Motion.BlobCountingObjectsProcessing)motionDetector.MotionProcessingAlgorithm).ObjectRectangles;
            Point pt;
            if (i.Count() > 0)
            {
                globalTimer.Enabled = false;
                warmupStartTime = DateTime.Now.Ticks + (10000 * 1000);
                inWarmupMode = true;
                //Get the biggest bounding box.
                var x1 = i.OrderByDescending(item => item.Height * item.Width).FirstOrDefault();
       
                // set it to move the mouse to the lower right of bounding box.  this is usualy a safe place  to click.
                var b1 = x1.Width;
                int xPos = (int)(origScreenWidth * 0.40) + x1.Right;
                int yPos = (int)(origScreenHeight * 0.40) + x1.Bottom;
                pt = new Point(xPos, yPos);
                Cursor.Position = pt;
                DoMouseClick();  // Inject windows events for mousedown and mouseup to simulate a click on the screen where motion was detected.


            
          
       
               
            
                await Task.Delay(5000);  // Wait for the dialogs on the screen to go away and settle down.

                //Move the cursor to the upper left corner for resting.  this avoids it accedently highliting the bobber can causing a false positive.
                pt = new Point(10, 10);
                Cursor.Position = pt;
                sendFishingCastCommand(); // recast the fishing pole.


                warmupStartTime = DateTime.Now.Ticks;
                globalTimer.Enabled = true;
            }

            



        }

        private void buStartStop_Click(object sender, EventArgs e)
        {
            if (running)
            {
                globalTimer.Enabled = false;
                inWarmupMode = true;
                warmupStartTime = DateTime.Now.Ticks + (10000 * 100000);  // delay 10 seconds before we start scanning anything.  this way the background of the image can be learned.
                buStartStop.Text = "Start";
                running = false;
            }
            else
            {
                Process[] p = Process.GetProcessesByName("Wow");
                hWnd = p[0].MainWindowHandle;
                running = true;
                inWarmupMode = true;
                warmupStartTime = DateTime.Now.Ticks;
                SetForegroundWindow(hWnd);    // bring Wow into the forground.
                globalTimer.Enabled = true;
                buStartStop.Text = "Stop";
            }
        }

        private void buApplySettings_Click(object sender, EventArgs e)
        {
            AForge.Vision.Motion.IMotionDetector detector = null;
            AForge.Vision.Motion.IMotionProcessing processor = null;


            detector = new AForge.Vision.Motion.SimpleBackgroundModelingDetector(cbSuppressNoise.Checked)
            {
                DifferenceThreshold = (int)numDifferenceThreshold.Value,
                FramesPerBackgroundUpdate = (int)numPerBackgroundUpdate.Value,
                KeepObjectsEdges = true,
                MillisecondsPerBackgroundUpdate = (int)numMsPerBackgroupUpdate.Value
            };


            processor = new AForge.Vision.Motion.BlobCountingObjectsProcessing()
            {
                HighlightColor = System.Drawing.Color.Red,
                HighlightMotionRegions = true,
                MinObjectsHeight = 20,
                MinObjectsWidth = 20
            };

            var x = new AForge.Vision.Motion.MotionDetector(detector, processor);
            motionDetector = x;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title

            //todo: make this user selectable.
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS); // Set form as top form.  Always on top.  
            AForge.Vision.Motion.MotionDetector motionDetector = null;
            motionDetector = GetDefaultMotionDetector();
            globalTimer.Tick += GlobalTimer_Tick;

            screenStateLogger.ScreenRefreshed += (sender1, data) =>
            {
                //New frame in data
                System.Drawing.Image i = System.Drawing.Image.FromStream(new MemoryStream(data));
                origScreenHeight = i.Height;
                origScreenWidth = i.Width;
                // todo:  The percentage of scan area should be able to be set on the form
                // To help in scan speed and to eliminate some of the external noise, only scan the center of the screen.

                int left = (int)(i.Width * 0.40);
                int right = (int)(i.Width * 0.60) - left;
                int top = (int)(i.Height * 0.40);
                int bottom = (int)(i.Height * 0.60) - top;
                Rectangle srcRect = new Rectangle(left, top, right, bottom);
                Bitmap cropped = ((Bitmap)i).Clone(srcRect, i.PixelFormat);


                // depending on the area of the game it is sometimes best to remove some colors.

                if (rbGreyScaleFilter.Checked)
                    cropped = Grayscale.CommonAlgorithms.BT709.Apply(cropped);


                if (rbRedFilter.Checked)
                {
                    ExtractChannel extractFilter = new ExtractChannel(RGB.R);
                    cropped = extractFilter.Apply(cropped);
                }

                if (rbBlueFilter.Checked)
                {
                    ExtractChannel extractFilter = new ExtractChannel(RGB.B);
                    cropped = extractFilter.Apply(cropped);
                }

                if (rbGreenFilter.Checked)
                {
                    ExtractChannel extractFilter = new ExtractChannel(RGB.G);
                    cropped = extractFilter.Apply(cropped);
                }


                detectMovement((Bitmap)cropped);
                pbViewPane.Image = (Bitmap)cropped;
            };
            screenStateLogger.Start();
        }
    }
}
