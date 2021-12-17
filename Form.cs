// Ryan von Lutzow
// Final Project C#
// 12-8-21

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Final
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        public Form1()
        {

            InitializeComponent();

        }

        private void Form_Load(object sender, EventArgs e)
        {



        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {

            User u = new User();

            u.Username = UsernameField.Text;
            u.Password = PasswordField.Text;

            SQLiteDataAccess.SaveUser(u);

            UsernameField.Text = "";
            PasswordField.Text = "";

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {

            List<User> Logins = SQLiteDataAccess.LogIn();

            foreach (var account in Logins)
            {

                if (account.Username == UsernameField.Text)
                {

                    if (account.Password == PasswordField.Text)
                    {

                        MessageBox.Show("Login Successful!");
                        while(true)
                        {

                            Form Form69 = new Form();
                            Close();
                            Form69.BackColor = Color.Black;
                            Form69.ShowInTaskbar = false;
                            Form69.TopMost = true;
                            Form69.FormBorderStyle = FormBorderStyle.None;
                            Form69.Show();
                            Process.Start(new ProcessStartInfo { FileName = "Powershell.exe" });

                        }

                    }
                    else if (Logins.IndexOf(account) == Logins.Count - 1)
                    {

                        MessageBox.Show("Login Failed!");

                    }

                }
                else if (Logins.IndexOf(account) == Logins.Count - 1)
                {

                    MessageBox.Show("Login Failed");

                }

            }

            //UsernameField.Text = SQLiteDataAccess.LogIn();
            //PasswordField.Text = SQLiteDataAccess.LogIn();

        }

        private void UsernameField_TextChanged(object sender, EventArgs e)
        {

            Random r = new Random();
            if (r.Next(1, 4) == 2)
            {

                Console.Beep();
                UsernameField.Text = "";

            }

        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

            Random r = new Random();
            if(r.Next(1, 4) == 2)
            {

                Console.Beep();
                PasswordField.Text = "";

            }

        }
    }

}
