using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaverAlarm
{
    public partial class mainForm : Form
    {
        private bool isLoginForm = true;
        public bool IsLoginForm
        {
            get { return isLoginForm; } set
            {
                isLoginForm = value;
                if (value == true)
                {
                    ChangeToLoginForm();
                }
                else
                {
                    ChangeToLoggedForm();
                }
            }
        }

        public mainForm()
        {
            InitializeComponent();
            loginForm.TopLevel = false;
            loggedForm.TopLevel = false;
            loginForm.Parent = this;
            loggedForm.Parent = this;

            loginForm.Show();
            this.Size = loginForm.Size + new Size(15, 35);
            this.Text = loginForm.Text;
            this.Icon = loginForm.Icon;
        }

        login loginForm = new login();
        Form1 loggedForm = new Form1();
        private void ChangeToLoginForm()
        {
            loginForm.Show();
            loggedForm.Hide();

            this.Size = loginForm.Size + new Size(15, 35);
            this.Text = loginForm.Text;
            this.Icon = loginForm.Icon;
        }

        private void ChangeToLoggedForm()
        {
            loggedForm.Show();
            loginForm.Hide();

            this.Size = loggedForm.Size + new Size(15, 35);
            this.Text = loggedForm.Text;
            this.Icon = loggedForm.Icon;
        }
    }
}