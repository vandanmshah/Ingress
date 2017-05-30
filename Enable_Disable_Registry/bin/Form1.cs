using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enable_Disable_Rigistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey regkey = default(RegistryKey);
            string keyValueInt = "-1";
            //0x00000000 (0)
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                //regkey.DeleteSubKey("DisableTaskMgr");
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
                MessageBox.Show("You Have enabled Task Manager....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey regkey = default(RegistryKey);
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
                MessageBox.Show("You Have disabled Task Manager....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                //localMachine = RegistryKey.OpenRemoteBaseKey(baseRegistryKey, remoteIP);
                RegistryKey regKey = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                regKey.SetValue("Userinit", "C:\\Program Files\\EMS\\EMS\\Demo.exe", RegistryValueKind.String);
                regKey.Close();
                MessageBox.Show("You Have enabled startup software....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);

                RegistryKey regKey = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                regKey.SetValue("Userinit", "C:\\Windows\\System32\\userinit.exe", RegistryValueKind.String);
                regKey.Close();
                MessageBox.Show("You Have disabled startup software....");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!");
            }
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {

            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            regkey.SetValue("NoControlPanel", false, Microsoft.Win32.RegistryValueKind.DWord);
            regkey.Close();

            regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            regkey.SetValue("NoControlPanel", false, Microsoft.Win32.RegistryValueKind.DWord);
            regkey.Close();
            MessageBox.Show("You Have enabled control panel....");
        }

        private void btn_disable_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            regkey.SetValue("NoControlPanel", true, Microsoft.Win32.RegistryValueKind.DWord);
            regkey.Close();

            regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            regkey.SetValue("NoControlPanel", true, Microsoft.Win32.RegistryValueKind.DWord);
            regkey.Close();
            MessageBox.Show("You Have disabled control panel....");
        }
    }
}
