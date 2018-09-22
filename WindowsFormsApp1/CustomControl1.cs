using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace WindowsFormsApp1
{
    public partial class customcontrol1 : UserControl
    {
        public customcontrol1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel2.Width = button1.Width;
            SidePanel2.Left = button1.Left;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            SidePanel2.Width = button2.Width;
            SidePanel2.Left = button2.Left;






        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void copyIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
                //sc.Add(listView1.FocusedItem.SubItems[1].Text);
                Clipboard.SetText(listView1.FocusedItem.SubItems[1].Text);
            }
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
                //sc.Add(listView1.FocusedItem.SubItems[0].Text);

                Clipboard.SetText(listView1.FocusedItem.SubItems[0].Text);
            }

        }

        private void openRdcpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 rdp = new Form2();
            rdp.textBox1.Text = listView1.FocusedItem.SubItems[1].Text;
            rdp.textBox2.Text = listView1.FocusedItem.SubItems[0].Text;
            rdp.textBox3.Text = "";
            rdp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(listView1.FocusedItem.SubItems[1].Text.ToString(), 1000);
            MessageBox.Show(reply.Status.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
