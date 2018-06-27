using System;
using System.Runtime.InteropServices;

using HiddleWindow.View;
using HiddleWindow.Model;
using System.Windows.Forms;
using HiddleWindow.Controller;

namespace HiddleWindow
{
    
    class Program
    { 
        static void Main(string[] args)
        {
            MainController mainController = new MainController();
            ViewController view = new ViewController();

            mainController.start();

            // 启动消息循环
            Application.Run();
        }
    }
}
