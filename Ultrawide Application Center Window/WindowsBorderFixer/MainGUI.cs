using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows;
using static PInvoke.User32;
using System.Threading;
using Vanara.PInvoke;

namespace WindowsBorderFixer {
    public partial class MainGUI : Form {

        public MainGUI() {
            InitializeComponent();
            btnRefresh_Click(null, null);
        }

        List<KeyValuePair<IntPtr, string>> kvpWindows = new List<KeyValuePair<IntPtr, string>>();

        private void btnRefresh_Click(object sender, EventArgs e) {
            cbxWindows.Items.Clear();
            kvpWindows.Clear();

            Process[] p = System.Diagnostics.Process.GetProcessesByName(cbxProcessName.Text.Split("//")[0].Trim()); //this is for sticky notes
            foreach (Process p1 in p) {
                IntPtr MainWindowHandle = p1.MainWindowHandle;
                List<IntPtr> childWindowHandles = GetChildWindows(MainWindowHandle);
                int windowTextLength = PInvoke.User32.GetWindowTextLength(MainWindowHandle);
                
                if (windowTextLength != 0) {
                    string windowTextHandle = PInvoke.User32.GetWindowText(MainWindowHandle);


                    kvpWindows.Add(new KeyValuePair<IntPtr, string>(MainWindowHandle, PInvoke.User32.GetWindowText(MainWindowHandle)));

                    foreach (var hWind in childWindowHandles) {
                        kvpWindows.Add(new KeyValuePair<IntPtr, string>(hWind, PInvoke.User32.GetWindowText(hWind)));
                    }
                }
            }

            foreach (var kvp in kvpWindows) 
                cbxWindows.Items.Add($"{kvp.Key:X8} | {kvp.Value}");

            if (kvpWindows.Count == 1) 
                cbxWindows.SelectedIndex = 0;
        }

        public static List<IntPtr> GetChildWindows(IntPtr parent) {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            } finally {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        List<IntPtr> GetRootWindowsOfProcess(int pid) {

            List<IntPtr> rootWindows = GetChildWindows(IntPtr.Zero);
            List<IntPtr> dsProcRootWindows = new List<IntPtr>();
            foreach (IntPtr hWnd in rootWindows) {
                int lpdwProcessId;

                PInvoke.User32.GetWindowThreadProcessId(hWnd, out lpdwProcessId);
                if (lpdwProcessId == pid)
                    dsProcRootWindows.Add(hWnd);
            }
            return dsProcRootWindows;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer) {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null) {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void btnBordered_Click(object sender, EventArgs e) {
            int selectedIndex = cbxWindows.SelectedIndex;
            var kvp = kvpWindows[selectedIndex];
            IntPtr hWind = kvp.Key;

            int winState = PInvoke.User32.GetWindowLong(hWind, PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE);


            long lExStyle = (uint)PInvoke.User32.WindowStyles.WS_CAPTION
                | (uint)PInvoke.User32.WindowStyles.WS_MINIMIZEBOX
                | (uint)PInvoke.User32.WindowStyles.WS_MAXIMIZEBOX
                | (uint)PInvoke.User32.WindowStyles.WS_SYSMENU;

            SetWindowLong(hWind
                , (int)PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE
                , (int)lExStyle);
        }

        private void btnBorderless_Click(object sender, EventArgs e) {
            int selectedIndex = cbxWindows.SelectedIndex;
            var kvp = kvpWindows[selectedIndex];
            IntPtr hWind = kvp.Key;
            
            SetWindowLong(hWind
               , (int)WindowLongIndexFlags.GWL_STYLE
               , (int)WindowStyles.WS_VISIBLE);

            //int winState = PInvoke.User32.GetWindowLong(hWind, PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE);
            //uint lExStyle = (uint)winState;
            //lExStyle &= ~(
            //    (uint)PInvoke.User32.WindowStyles.WS_CAPTION
            //    | (uint)0x00040000L // WS_THICKFRAME
            //    | (uint)PInvoke.User32.WindowStyles.WS_MINIMIZEBOX
            //    | (uint)PInvoke.User32.WindowStyles.WS_MAXIMIZEBOX
            //    | (uint)PInvoke.User32.WindowStyles.WS_SYSMENU
            //);
        }

        private void btnGetWindowFlags_Click(object sender, EventArgs e) {
            int selectedIndex = cbxWindows.SelectedIndex;
            var kvp = kvpWindows[selectedIndex];
            IntPtr hWind = kvp.Key;

            int winState = PInvoke.User32.GetWindowLong(hWind, PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE);
            PInvoke.User32.WindowLongIndexFlags wlif = (PInvoke.User32.WindowLongIndexFlags)winState;

            System.Windows.Forms.MessageBox.Show("WindowLongIndexFlags\n" + wlif.ToString());
        }

        private void btnMoveYTop_Click(object sender, EventArgs e) {
            int selectedIndex = cbxWindows.SelectedIndex;
            var kvp = kvpWindows[selectedIndex];
            IntPtr hWind = kvp.Key;

            // Get the current window location
            var resSplit    = cbxResolution.Text.Trim().Split('x');
            var wSizeWidth  = resSplit[0].ToInt32(2560); // Default to 2560x1440
            var wSizeHeight = resSplit[1].ToInt32(1440);
            
            SetWindowPos(hWind, (IntPtr)SpecialWindowHandles.HWND_TOP,
                Screen.AllScreens[0].Bounds.Width / 2 - (wSizeWidth / 2),
                Screen.AllScreens[0].Bounds.Top,
                wSizeWidth, wSizeHeight, SetWindowPosFlags.SWP_SHOWWINDOW);
        }

        private void btnReset_Click(object sender, EventArgs e) {
            int selectedIndex = cbxWindows.SelectedIndex;
            var kvp = kvpWindows[selectedIndex];
            IntPtr hWind = kvp.Key;
            long lExStyle = 256;

            SetWindowLong(hWind
               , (int)PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE
               , (int)lExStyle);
        }



        private PInvoke.RECT get_window_rect(IntPtr hWindow) {
            PInvoke.RECT rect;
            PInvoke.User32.GetWindowRect(hWindow, out rect);

            Vanara.PInvoke.HWND hWND = new Vanara.PInvoke.HWND(hWindow);

            global::Vanara.PInvoke.DwmApi.DwmGetWindowAttribute(hWND
                , Vanara.PInvoke.DwmApi.DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS
                , out Vanara.PInvoke.RECT frame);

            PInvoke.RECT border;
            border.left = frame.left - rect.left;
            border.top = frame.top - rect.top;
            border.right = frame.right - rect.right;
            border.bottom = frame.bottom - rect.bottom;

            rect.left -= border.left;
            rect.top -= border.top;
            rect.right += border.left + border.right;
            rect.bottom += border.top + border.bottom;

            return rect;
        }

        private void btnDebug_Click(object sender, EventArgs e) {
            var wSizeWidth = 2560;  //rect.right - rect.left;
            var wSizeHeight = 1440; // Window ? rect.bottom;

            var workingAreaWidth = Screen.AllScreens[0].WorkingArea.Width;
            var startX = Screen.AllScreens[0].WorkingArea.Width / 2 - (wSizeWidth / 2);

            int dbg = 0;
        }
    }

    public static class StringExtension {
        public static string[] Split(this string str, string splitter) {
            return str.Split(new[] { splitter }, StringSplitOptions.None);
        }
    }
}
