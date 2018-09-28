using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("shiftcompanion_AzureStorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue messageQueue = queueClient.GetQueueReference("shift");
            //CloudQueueMessage message = new CloudQueueMessage("Hello, World");
            //messageQueue.AddMessage(message);



            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                messageQueue.FetchAttributes();
                while (messageQueue.ApproximateMessageCount > 0)
                {
                    //MessageBox.Show(messageQueue.ApproximateMessageCount.ToString(), "yes");
                    CloudQueueMessage retrievedMessage = messageQueue.GetMessage();
                    //handle each message
                    if(retrievedMessage.AsString != null)
                    {
                        string[] words = retrievedMessage.AsString.Split(',');
                        ListViewItem li = new ListViewItem(words[0]);
                        li.SubItems.Add(words[1]);
                        li.SubItems.Add(words[2]);
                        li.SubItems.Add(words[3]);
                        li.SubItems.Add(words[4]);
                        li.Group = customcontrol11.listView1.Groups[words[5]];


                        if (customcontrol11.listView1.InvokeRequired)
                        {
                            customcontrol11.listView1.Invoke((MethodInvoker)delegate ()
                            {
                              
                                customcontrol11.listView1.Items.Add(li);
                            });
                        }
                        messageQueue.DeleteMessage(retrievedMessage);
                    }
                    messageQueue.FetchAttributes();
                }
            }, null, startTimeSpan, periodTimeSpan);


        }



 

       

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            this.customcontrol11.BringToFront();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            customcontrol11.listView1.View = View.LargeIcon;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            customcontrol11.listView1.View = View.List;
        }

        private void customcontrol11_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            customcontrol11.listView1.View = View.Details;

        }

        private void customcontrol11_Load_1(object sender, EventArgs e)
        {
        }

        private void customControl21_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
