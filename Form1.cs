using System;
using System.Windows.Forms;

namespace NaverAlarm
{
    public partial class Form1 : Form
    {
        public string ID;
        public string PassWord;

        public Form1()
        {
            InitializeComponent();
            this.ID = Program.ID;
            this.PassWord = Program.PW;

            if(Naver.Login(this.ID, this.PassWord))
            {
                this.Text = "네리미";
            }
        }

        int oldCt = 0;
        int newCt = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            newCt = Naver.GET_NOTI_COUNT(ID, PassWord);
            if(oldCt != newCt)
            {
                this.label1.Text = newCt.ToString();

                NotiChanged(newCt);
            }
            if(newCt > oldCt)
            {
                newNoti(newCt);
            }
            oldCt = newCt;
        }

        private void NotiChanged(int noti)
        {
            this.label1.Text = "아직 안 읽은 알림 : " + noti.ToString();
        }

        private void newNoti(int noti)
        {
            if (this.checkBox1.Checked)
            {
                notifyIcon1.BalloonTipText = "새로운 알림이 왔습니다!";
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void LogOut()
        {
            Program.main.IsLoginForm = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        
        private void 종료QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 로그아웃OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }
    }
}