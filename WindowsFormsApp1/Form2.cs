using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void axMsRdpClient8NotSafeForScripting1_OnConnecting(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rdp.DesktopWidth = Screen.PrimaryScreen.Bounds.Width;
                rdp.DesktopHeight = Screen.PrimaryScreen.Bounds.Height;
                rdp.AdvancedSettings9.EnableCredSspSupport = true;
                rdp.Domain = "linkdc";
                rdp.Server = textBox1.Text.ToString();
                rdp.UserName = textBox2.Text.ToString();
                IMsTscNonScriptable secure = (IMsTscNonScriptable)rdp.GetOcx();
                secure.ClearTextPassword = textBox3.Text.ToString();
                rdp.Connect();
                //rdp.SyncSessionDisplaySettings();
                rdp.AdvancedSettings9.SmartSizing = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void axMsRdpClient8NotSafeForScripting1_OnConnecting_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rdp_OnConnecting(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //IMsRdpClient10 client = (IMsRdpClient10)rdp.GetOcx();
            //Size ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //rdp.ClientSize = ScreenSize;
            rdp.FullScreen = true;


        }

        private void rdp_OnConnecting_1(object sender, EventArgs e)
        {

        }
    
}
}
