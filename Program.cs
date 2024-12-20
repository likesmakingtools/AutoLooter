using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AutoLooter
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            // wait time in seconds
            int plant = 480;
            int cow = 600;
            int wait = plant;

            // 43200 seconds in 12 hours
            int limit = 43200 / wait;
            
            IntPtr window = FindWindow(null, "Melvor Idle");
            IntPtr active = GetForegroundWindow();
            int WM_KEYDOWN = 0x100;
            int WM_KEYUP = 0x101;
            int VK_RETURN = 0x0D;

            for(int i = 0; i < limit; i++)
            {
                Thread.Sleep(wait * 1000);

                active = GetForegroundWindow();
                SetForegroundWindow(window);

                Thread.Sleep(100); // 10 miliseconds
                PostMessage(window, WM_KEYDOWN, VK_RETURN, IntPtr.Zero);
                PostMessage(window, WM_KEYUP, VK_RETURN, IntPtr.Zero);
                Thread.Sleep(100); // 10 miliseconds

                SetForegroundWindow(active);
            }
            
            //line = Console.ReadLine();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);
    }
}
