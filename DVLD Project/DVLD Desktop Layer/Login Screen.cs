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
using Microsoft.Win32;

namespace DVLDDesltopFrontLayer
{
    public partial class Login_Screen : Form
    {
        public static int _UserID = 0;
        public Login_Screen()
        {
            InitializeComponent();
        }

        private static string _fILEpATHregistarionEditorForUserName = @"HKEY_CURRENT_USER\SOFTWARE\UserName";
        private static string _fILEpATHregistarationEditorForPassword = @"HKEY_CURRENT_USER\SOFTWARE\Password";




        private void SaveUserNameOnRegistarationEditor(string userName, string Password)
        {
            try
            {
                Registry.SetValue(_fILEpATHregistarionEditorForUserName, "UserName", userName, RegistryValueKind.String);

                Registry.SetValue(_fILEpATHregistarationEditorForPassword, "Password", Password, RegistryValueKind.String);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"error {ex.Message}");
                
            }
       
        }
        private void RemberUserNameOnRegistarationEditor()
        {
            try
            {
                // read the value to the Registry
                string UserName = Registry.GetValue(_fILEpATHregistarionEditorForUserName, "UserName", null) as string;

                string Password = Registry.GetValue(_fILEpATHregistarationEditorForPassword, "Password", null) as string;

                if (UserName != null && Password != null)
                {
                    txtUserName.Text = UserName;
                    txtPassword.Text = Password;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

         
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            RemberUserNameOnRegistarationEditor();
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
                        SaveUserNameOnRegistarationEditor(txtUserName.Text, txtPassword.Text);  
                    }
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
