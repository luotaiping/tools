using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiddleWindow.Controller;

namespace HiddleWindow.View
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
            inputBox.Text = (MainController.config.time_out / 1000).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainController.config.time_out = Int32.Parse(inputBox.Text)*1000;

            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
