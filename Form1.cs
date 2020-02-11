using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemLab10
{
    public partial class Form1 : Form
    {
        DriveInfo[] allDrives;
        DirectoryInfo dirInfo;
        DirectoryInfo[] dir;
       
        FileInfo[] allFiles;
        private string flag;
        public Form1()
        {
            InitializeComponent();
            ShowItems();
            //ShowDirectory();
            //ShowDirectory2();
            flag = "";
        }

        public void ShowItems()
        {
            allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                Dist1.Items.Add(d.Name);
                Dist2.Items.Add(d.Name);
            }
        }

        public void ShowDirectory()
        {
            
            dirInfo = new DirectoryInfo(textBox1.Text);
            dir = dirInfo.GetDirectories();
            allFiles = dirInfo.GetFiles();
            Dist1.Items.Clear();
            
            
        }
        public void ShowDirectory2()
        {
            dirInfo = new DirectoryInfo(textBox2.Text);
            dir = dirInfo.GetDirectories();
            allFiles = dirInfo.GetFiles();
            Dist2.Items.Clear();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBox1.Text += Dist1.SelectedItem.ToString();
            textBox1.Text += "\\";
            button1.Enabled = true;
            flag = "Dist1";
        }

        private void Dist1_DoubleClick(object sender, EventArgs e)
        {
            ShowDirectory();
            foreach (DirectoryInfo di in dir)
            {
                Dist1.Items.Add(di);
                //Dist2.Items.Add(di);

            }
            foreach (FileInfo f in allFiles)
            {
                Dist1.Items.Add(f);
                //Dist2.Items.Add(f);
            }

        }

        private void button1_Click(object sender, EventArgs e) //Move from left to right
        {
            string sourcefile = textBox1.Text;
            string destfile = textBox2.Text;
            destfile += Dist1.SelectedItem;
            
            Directory.Move(sourcefile, destfile);
            MessageBox.Show("Moved Successfully");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void Dist2_SelectedIndexChanged(object sender, EventArgs e) //Dist2 items
        {

            textBox2.Text += Dist2.SelectedItem.ToString();
            textBox2.Text += "\\";
            button2.Enabled = true;
            flag = "Dist2";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dist2_DoubleClick(object sender, EventArgs e)
        {
            ShowDirectory2();
            foreach (DirectoryInfo di in dir)
            {
                //Dist1.Items.Add(di);
                Dist2.Items.Add(di);

            }
            foreach (FileInfo f in allFiles)
            {
                //Dist1.Items.Add(f);
                Dist2.Items.Add(f);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Move from right to left
        {
            string sourcefile = textBox2.Text;
            string destfile = textBox1.Text;
            destfile += Dist2.SelectedItem;
            Directory.Move(sourcefile, destfile);
            MessageBox.Show("Moved Successfully");
        }

        private void button4_Click(object sender, EventArgs e) //Copy Button
            //note: remove last \ from textbox to copy the file
        {
            if(Dist1.SelectedItem != null)
            {
                string sourcefile = textBox1.Text;
                string destfile = textBox2.Text;
                string fileName = Dist1.SelectedItem.ToString();
                File.Copy(sourcefile, Path.Combine(destfile, fileName), true);
                MessageBox.Show("Copies Successfully");
            }
            if(Dist2.SelectedItem != null)
            {
                string sourcefile = textBox2.Text;
                string destfile = textBox1.Text;
                string fileName = Dist2.SelectedItem.ToString();
                File.Copy(sourcefile, Path.Combine(destfile, fileName), true);
                MessageBox.Show("Copies Successfully");
            }
        }

        private void button3_Click(object sender, EventArgs e) //Delete Button
        {
            if (flag == "Dist1")
            {
                Directory.Delete(textBox1.Text, true);
                MessageBox.Show("Deleted successful!");
                Dist1.Refresh();

            }
            if (flag == "Dist2")
            {
                Directory.Delete(textBox2.Text, true);
                MessageBox.Show("Deleted successful!");
                Dist2.Refresh();
            }
        }
    }
}
