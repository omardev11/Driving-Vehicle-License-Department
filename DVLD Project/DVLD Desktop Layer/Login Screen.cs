using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;

namespace DVLDDesltopFrontLayer
{
    public partial class Login_Screen : Form
    {
        public static int _UserID = 0;
        public Login_Screen()
        {
            InitializeComponent();
        }
        //public string _FilePath = "";
        private static string _FilePath = @"E:\apps\c++\My Projects\DVLD project\DVLD Project\UserName and password.txt";

        private void SaveUserName(string userName , string Password)
        {

            string content = $"{userName}:{Password}";

            File.WriteAllText(_FilePath, content);
        }
        private void RemberUserName(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                string content  = File.ReadAllText(FilePath);

                if (!string.IsNullOrWhiteSpace(content))
                {
                    var parts = content.Split(':');

                    txtUserName.Text = parts[0];
                    txtPassword.Text = parts[1];
                }
               
            }
        }
        private void Login_Screen_Load(object sender, EventArgs e)
        {
            RemberUserName(_FilePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            _UserID = clsDVLDBusinessUsers.FindUserByUsernameAndPassword(txtUserName.Text, txtPassword.Text);
            if (_UserID != -1)
            {
                if (clsDVLDBusinessUsers.isThisUserActive(_UserID))
                {
                    if (checkBox1.Checked)
                    {
                        SaveUserName(txtUserName.Text, txtPassword.Text);
                    }
                    //this.Hide();
                    Main main = new Main();

                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("The User is No Longer Active");
                }

            }
            else
            {
                MessageBox.Show("The UserName / Password is Wrong");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
