using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            //// Start the timer when the form loads
            //timer1.Start();
            //isTimerRunning = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //elapsedTime++;

            //if (elapsedTime >= 20 && isTimerRunning)
            //{
            //    // Stop the timer and display a notification
            //    timer1.Stop();
            //    isTimerRunning = false;
            //    ShowNotification("Lỗi mạng, vui lòng thử lại!");
            //    Application.Exit();
            //}
        }

        //private void ShowNotification(string message)
        //{
        //    // Display a notification to the user
        //    MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
    }
}
