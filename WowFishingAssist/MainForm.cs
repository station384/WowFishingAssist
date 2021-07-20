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

namespace WowFishingAssist
{
    public partial class MainForm : Form
    {
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        //private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        //private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int WM_SETTEXT = 0X000C;

        const UInt32 WM_KEYDOWN = 0x0100;
        const UInt32 WM_KEYUP = 0x0101;
        const UInt32 WM_CHAR = 0x0102;
        private int mouseClickTime  = 100;
        private Random rnd = new Random();
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
        private static bool useLure = false;
        private static bool useBait = false;
        private static int numCastsBeforeSellJunk = 150;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);



        ScreenStateLogger screenStateLogger = new ScreenStateLogger();
        AForge.Vision.Motion.MotionDetector motionDetector = GetDefaultMotionDetector();

        int warmupTime = 5000 * 10000;
        long warmupStartTime =  DateTime.Now.Ticks + (10000 * 100000);
        bool inWarmupMode = true;
        readonly System.Timers.Timer globalTimer = new System.Timers.Timer() { Interval=30000, Enabled= false, AutoReset = true }; // 30 Seconds
        readonly System.Timers.Timer lureTimer = new System.Timers.Timer() { Interval = 900000, Enabled = false, AutoReset = true }; // 15 minutes
        readonly System.Timers.Timer baitTimer = new System.Timers.Timer() { Interval = 1800000, Enabled = false, AutoReset = true }; // 30 minutes



        System.Windows.Forms.Timer screenUpdateTimer = new System.Windows.Forms.Timer() { Interval = 1000, Enabled = true };

        bool running = false;
        int origScreenHeight = 0;
        int origScreenWidth = 0;
        int CastCount = 0;

        private  void PauseFishing()
        {
            warmupStartTime = DateTime.Now.Ticks + (10000 * 100000);  // delay 10 seconds before we start scanning anything.  this way the background of the image can be learned.
            globalTimer.Stop();
            inWarmupMode = true;
            running = false;
        }

        private void ResumeFishing()
        {
            running = true;
            inWarmupMode = true;
            warmupStartTime = DateTime.Now.Ticks;
            globalTimer.Start();
        }

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

        private async void sendAKey (int key)
        {
            await Task.Delay(50);
            PostMessage(hWnd, WM_KEYDOWN, key, 0);
            //await Task.Delay(50);
            PostMessage(hWnd, WM_KEYUP, key, 0);
            await Task.Delay(50);
        }

        private  void sendAChar(int key)
        {
   
            PostMessage(hWnd, WM_CHAR, key, 0x0280001);
           
        }

        private async Task sendFishingCastCommand ()
        {
            SetForegroundWindow(hWnd);    // bring Wow into the forground.
            Point pt = new Point(10, 10);
            Cursor.Position = pt;
            // sendAKey(0xBB);
            sendAKey(0xBF);  // - / 
            await Task.Delay(100);
            sendAChar(0x43);  // - C
            sendAChar(0x41);  // - A   
            sendAChar(0x53);  // - S 
            sendAChar(0x54);  // - T
            sendAChar(0x20);  // - 
            sendAChar(0x66);  // -f
            sendAChar(0x49);  // -i
            sendAChar(0x53);  // -s 
            sendAChar(0x48);  // -h
            sendAChar(0x49);  // -i
            sendAChar(0x4E);  // -n
            sendAChar(0x47);  // -g
            sendAKey(0x0D);//Enter
            await Task.Delay(100);
            CastCount++;
        }

        private async Task sendUseLure()
        {
        //    PauseFishing();
            SetForegroundWindow(hWnd);    // bring Wow into the forground.
            await Task.Delay(1000);
            sendAKey(0xBF);  // - / 
            await Task.Delay(100);
            sendAChar(0x55);  // -u
            sendAChar(0x53);  // -s   
            sendAChar(0x45);  // -e 
            sendAChar(0x20);  // - 

            sendAChar(0x53);  // -s 
            sendAChar(0x43);  // -c
            sendAChar(0x41);  // -a
            sendAChar(0x52);  // -r 
            sendAChar(0x4C);  // -l
            sendAChar(0x45);  // -e
            sendAChar(0x54);  // -T
            sendAChar(0x20);  // - 
            sendAChar(0x48);  // -h
            sendAChar(0x45);  // -e
            sendAChar(0x52);  // -r
            sendAChar(0x52);  // -r
            sendAChar(0x49);  // -i
            sendAChar(0x4E);  // -n
            sendAChar(0x47);  // -g
            sendAChar(0x20);  // - 
            sendAChar(0x4C);  // -l
            sendAChar(0x55);  // -u
            sendAChar(0x52);  // -r
            sendAChar(0x45);  // -e

          
            sendAKey(0x0D);//Enter
            await Task.Delay(5000);

          //  Point pt = new Point(998, 650);  // todo: this position needs to be relative.  its the position on a 1080 screen.   needs to be relative to what ever the rez is set to.
         //   Cursor.Position = pt;
          //  DoMouseClick(pt);
            await Task.Delay(5000);
           // await sendFishingCastCommand();
        //    ResumeFishing();

        }

        private async Task sendUseBait()
        {
        //    PauseFishing();
            //SetForegroundWindow(hWnd);    // bring Wow into the forground.
            //await Task.Delay(1000);
            //sendAKey(0xBF);  // - / 
            //await Task.Delay(100);
            //sendAChar(0x55);  // -u
            //sendAChar(0x53);  // -s   
            //sendAChar(0x45);  // -e 
            //sendAChar(0x20);  // - 
            //sendAChar(0x45);  // -e
            //sendAChar(0x4C);  // -l
            //sendAChar(0x79);  // -y
            //sendAChar(0x53);  // -s 
            //sendAChar(0x49);  // -i
            //sendAChar(0x41);  // -a
            //sendAChar(0x4E);  // -n
            //sendAChar(0x20);  // - 
            //sendAChar(0x74);  // -t
            //sendAChar(0x48);  // -h
            //sendAChar(0x41);  // -a
            //sendAChar(0x64);  // -d
            //sendAChar(0x45);  // -e
            //sendAChar(0x20);  // - 
            //sendAChar(0x62);  // -b
            //sendAChar(0x61);  // -a
            //sendAChar(0x69);  // -i
            //sendAChar(0x74);  // -t
            //sendAKey(0x0D);//Enter
            //await Task.Delay(5000);

            // Seems bait has to be tied to an action key.    so Tieing to the old fishing key of =   the bait you want to use needs to be place in that slot.
            SetForegroundWindow(hWnd);    // bring Wow into the forground.
            await Task.Delay(1000);
            sendAKey(0xBB);

            //Point pt = new Point(998, 650);  // todo: this position needs to be relative.  its the position on a 1080 screen.   needs to be relative to what ever the rez is set to.
            //Cursor.Position = pt;
            //DoMouseClick(pt);
            await Task.Delay(1000);
         //   await sendFishingCastCommand();
          //  ResumeFishing();

        }



        private async Task sendSellSequence ()
        {
            //PauseFishing();
            SetForegroundWindow(hWnd);    // bring Wow into the forground.
            await Task.Delay(1000);
            sendAKey(0x23);  // - End
            await Task.Delay(1000);
            sendAKey(0x23);  // - End
            await Task.Delay(1000);
            sendAKey(0x23);  // - End
            await Task.Delay(1000);
            sendAKey(0x23);  // - End
            await Task.Delay(100);
            sendAKey(0xBF);  // - / 
            await Task.Delay(100);
            sendAChar(0x43);  // -C
            sendAChar(0x41);  // -A   
            sendAChar(0x53);  // -S 
            sendAChar(0x54);  // -T
            sendAChar(0x20);  // - 
            sendAChar(0x54);  // -T  
            sendAChar(0x52);  // -r 
            sendAChar(0x41);  // -a
            sendAChar(0x56);  // -v
            sendAChar(0x45);  // -e
            sendAChar(0x4C);  // -l
            sendAChar(0x45);  // -e
            sendAChar(0x52);  // -r
            sendAChar(0x27);  // -'
            sendAChar(0x53);  // -s
            sendAChar(0x20);  // -
            sendAChar(0x54);  // -T
            sendAChar(0x55);  // -u
            sendAChar(0x4E);  // -n
            sendAChar(0x44);  // -d
            sendAChar(0x52);  // -r
            sendAChar(0x41);  // -a
            sendAChar(0x20);  // -
            sendAChar(0x4D);  // -M
            sendAChar(0x41);  // -a
            sendAChar(0x4D);  // -m
            sendAChar(0x4D);  // -m
            sendAChar(0x4F);  // -o
            sendAChar(0x54);  // -t
            sendAChar(0x48);  // -h
            sendAKey(0x0D);   // Enter
            await Task.Delay(5000);

            Point pt = new Point(998, 650);  // todo: this position needs to be relative.  its the position on a 1080 screen.   needs to be relative to what ever the rez is set to.
            Cursor.Position = pt;
            DoMouseClick(pt);

            await Task.Delay(5000);
            //zoom back in
            await Task.Delay(1000);
            sendAKey(0x24);  // - End
            await Task.Delay(1000);
            sendAKey(0x24);  // - End
            await Task.Delay(1000);
            sendAKey(0x24);  // - End
            await Task.Delay(1000);
            sendAKey(0x24);  // - End
            await Task.Delay(1000);
            // await sendFishingCastCommand();
            // ResumeFishing();

        }


        public async void DoMouseClick(Point p)
        {

            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
            await Task.Delay(mouseClickTime);
            mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
            await Task.Delay(100);
            // ClickOnPointTool.ClickOnPoint(hWnd, p);

        }



        private async void ClickBobber(Rectangle x1)
        {
            Point pt;
            PauseFishing();
            //Get the biggest bounding box.
  

            // set it to move the mouse to the center of bounding box. 
            int clickxPos = ((int)(origScreenWidth * 0.40) + x1.Right) - (x1.Width / 2);
            int clickyPos = ((int)(origScreenHeight * 0.50) + x1.Bottom) - (x1.Height / 2);
            pt = new Point(clickxPos, clickyPos);
            Cursor.Position = pt;
            await Task.Delay(rnd.Next((int)numMinBobClickTime.Value*1000,(int)numMaxBobClickTime.Value*1000));
            DoMouseClick(pt);  // Inject windows events for mousedown and mouseup to simulate a click on the screen where motion was detected.

            await Task.Delay(2000);  // Wait for the dialogs on the screen to go away and settle down.

            //Move the cursor to the upper left corner for resting.  this avoids it accedently highliting the bobber can causing a false positive.
            pt = new Point(10, 10);
            Cursor.Position = pt;
    

      
            if ((CastCount % numCastsBeforeSellJunk+1) == numCastsBeforeSellJunk && cbSellJunk.Checked)
            {
                await sendSellSequence();
                //return;
            }
            if (useLure && cbHerringLure.Checked)
            {
                await sendUseLure();
                useLure = false;
                lureTimer.Start();
                //return;
            }
            if (useBait && cbUseBait.Checked)
            {
                await sendUseBait();
                useBait = false;
                baitTimer.Start();
                //return;
            }

            await sendFishingCastCommand();
            ResumeFishing();
        }

        private  void detectMovement (Bitmap b)
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
           
            if (i.Count() > 0)
            {
                Rectangle x1 = i.OrderByDescending(item => item.Height * item.Width).FirstOrDefault();
                ClickBobber(x1);
            }
  
    
        }

        
        
        private void buStartStop_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("Wow");
           if (p.Length == 0)
            {
                p = Process.GetProcessesByName("WowClassic");
                return;
            }

            if (p.Length == 0)
            {
                MessageBox.Show("WOW.exe Process not found, Load World of Warcraft.");
                return;
            }

            hWnd = p[0].MainWindowHandle;
           

            //  sendSellSequence();
            if (running)
            {
                buStartStop.Text = "Start";
                PauseFishing();
            }
            else
            {
                buStartStop.Text = "Stop";
                SetForegroundWindow(hWnd);    // bring Wow into the forground.
                if (cbHerringLure.Checked) useLure = true;
                if (cbHerringLure.Checked) useBait = true;
                ResumeFishing();
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
            mouseClickTime = (int)numericUpDown1.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title

            //todo: make this user selectable.
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS); // Set form as top form.  Always on top.  
            AForge.Vision.Motion.MotionDetector motionDetector = null;
            motionDetector = GetDefaultMotionDetector();
            globalTimer.Elapsed += GlobalTimer_Elapsed;
            lureTimer.Elapsed += LureTimer_Elapsed;
            baitTimer.Elapsed += BaitTimer_Elapsed;
            screenUpdateTimer.Tick += ScreenUpdateTimer_Tick;

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
                int top = (int)(i.Height * 0.50);
                int bottom = (int)(i.Height * 0.70) - top;
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

        private void BaitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            useBait = true;
            baitTimer.Stop();
        }

        private async void GlobalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // These event fires after 30 seconds.   This is a safety catch to make sure there is a recast.    
            // If no motion as been detected this will fire, if motion has been detected then the timer for this event is reset.
            if (!running) return;
            PauseFishing();
            motionDetector.Reset();

            await sendFishingCastCommand();  //  Inject a keyDown and keyUp event into windows for the '=' key.  Todo: The key should be configurable.

            ResumeFishing();
        }

        private void LureTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            useLure = true;
            lureTimer.Stop();
        }

       

        private void ScreenUpdateTimer_Tick(object sender, EventArgs e)
        {
            lblCastCount.Text = String.Concat(CastCount.ToString(),":", (CastCount % numCastsBeforeSellJunk));
            lblLureTime.Text = useLure ? "1" : "0";
        }



        private void numMinBobClickTime_ValueChanged(object sender, EventArgs e)
        {
            numMaxBobClickTime.Minimum = this.numMinBobClickTime.Value;
        }

        private void numMaxBobClickTime_ValueChanged(object sender, EventArgs e)
        {
            numMinBobClickTime.Maximum = numMaxBobClickTime.Value;
        }

        private void cbHerringLure_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHerringLure.Checked) { useLure = true; } else { useLure = false; }
        }

        private void numCastsBeforeSell_ValueChanged(object sender, EventArgs e)
        {
            numCastsBeforeSellJunk = (int)numCastsBeforeSell.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gbBaitType.Enabled = cbUseBait.Checked;
            useBait = cbUseBait.Checked;
        }
    }
}
