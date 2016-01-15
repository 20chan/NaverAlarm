using System;
using System.Windows.Forms;

namespace NaverAlarm
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Login()
        {
            string id = textBox1.Text, pw = textBox2.Text;
            if(Naver.Login(id, pw))
            {
                if (this.checkBox1.Checked)
                    Properties.Settings.Default.ID = id;
                if (this.checkBox2.Checked)
                    Properties.Settings.Default.PassWord = pw;

                Program.ID = this.textBox1.Text;
                Program.PW = this.textBox2.Text;
                Properties.Settings.Default.SaveID = this.checkBox1.Checked;
                Properties.Settings.Default.SavePassword = this.checkBox2.Checked;
                Properties.Settings.Default.AutoLogin = this.checkBox3.Checked;
                Properties.Settings.Default.Save();
                Program.main.IsLoginForm = false;
            }
            else
            {
                MessageBox.Show("로그인 실패! 아이디와 비밀번호를 확인하시거나, 인터넷 웹브라우저로 로그인 후 다시 시도해주세요.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = Properties.Settings.Default.SaveID;
            this.checkBox2.Checked = Properties.Settings.Default.SavePassword;
            this.checkBox3.Checked = Properties.Settings.Default.AutoLogin;

            if (this.checkBox1.Checked)
                this.textBox1.Text = Properties.Settings.Default.ID;

            if (this.checkBox2.Checked)
                this.textBox2.Text = Properties.Settings.Default.PassWord;

            if (this.checkBox3.Checked)
            {
                Login();
            }
        }
    }
}
