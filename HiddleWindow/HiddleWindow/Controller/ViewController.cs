using HiddleWindow.Controller;
using HiddleWindow.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiddleWindow.View
{
    class ViewController
    {
        private NotifyIcon notifyIcon;

        private ContextMenu contextMenu;
        private MenuItem enableItem;

        public ViewController()
        {
            LoadMenu();

            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Text = "HiddleWindow";
            notifyIcon.Icon = new Icon(@"logo.ico");//托盘中显示的图标
            notifyIcon.ContextMenu = this.contextMenu;
        }

        private void Click(object sender, EventArgs e)
        {
            dynamic b = e;
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("right");
            }
        }

        private void LoadMenu()
        {
            this.contextMenu = new ContextMenu(
                new MenuItem[] {
                    this.enableItem = new MenuItem("启用", new EventHandler(this.EnableItem_Click)),
                    new MenuItem("修改检测时间", new EventHandler(this.Alter_Time_Out_Click)),
                    new MenuItem("退出", new EventHandler(this.Exit_Click)),
                }
                );

            this.enableItem.Checked = MainController.config.enable;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void Alter_Time_Out_Click(object sender, EventArgs e)
        {
            (new Input()).Show();
        }

        private void EnableItem_Click(object sender, EventArgs e)
        {
            this.enableItem.Checked = !this.enableItem.Checked;

            MainController.config.enable = this.enableItem.Checked;
        }
    }
}
