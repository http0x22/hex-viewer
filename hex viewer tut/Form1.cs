using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hex_viewer_tut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Program";
            openFileDialog.Filter = "Exe files (*.exe)|*.exe";
            openFileDialog.FilterIndex = 1;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string title = openFileDialog.SafeFileName;
                ByteViewer byteViewer = new ByteViewer();
                TabPage newTab = new TabPage();
                tabControl1.TabPages.Add(newTab);
                newTab.Controls.Add(byteViewer);
                newTab.Text = title;
                byteViewer.Dock = DockStyle.Fill;
                byteViewer.SetFile(openFileDialog.FileName);
                tabControl1.SelectTab(newTab);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount != 0)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                MessageBox.Show("no tabs to be removed");
            }
        }
    }
}
