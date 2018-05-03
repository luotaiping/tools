using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HiddleWindow
{
    // 创建结构体用于返回捕获时间  
    [StructLayout(LayoutKind.Sequential)]
    struct LASTINPUTINFO
    {
        // 设置结构体块容量  
        //[MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        // 捕获的时间  
        //[MarshalAs(UnmanagedType.U4)]
        public uint dwTime;
    }

    public delegate bool Callback(int hwnd, int lParam);
    

    class Program
    { 
        const int VK_LWIN = 0x5B;
        const int VK_D = 0x44;
        const int KEYEVENTF_KEYUP = 0x0002;

        const int TIME_OUT = 2 * 60 * 1000;     // 超时时间，默认是2分钟

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        static void Main(string[] args)
        {
            string time_out_setting = ConfigurationManager.AppSettings["time_out"];
            int time_out = TIME_OUT;

            if (null != time_out_setting)
            {
                // 输入的是秒，要转为毫秒
                time_out = Int32.Parse(time_out_setting) * 1000;
            }

            // 已经按过的标志
            bool press = false;

            while (true)
            {
                long time = GetLastInputTime();

                if (0 == time && press)
                {
                    Win_D();
                    press = false;
                }
                else if (time > time_out && !press)
                {
                    Win_D();
                    press = true;
                }

                System.Threading.Thread.Sleep(200);
            }
        }

        // 获取键盘和鼠标没有操作的时间
        private static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            // 捕获时间  
            if (!GetLastInputInfo(ref vLastInputInfo))
                return 0;
            else
                return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        // 按下 win+D 来最小化窗口
        private static void Win_D()
        {
            keybd_event(VK_LWIN, 0, 0, 0);
            keybd_event(VK_D, 0, 0, 0);
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
        }

    }
}
