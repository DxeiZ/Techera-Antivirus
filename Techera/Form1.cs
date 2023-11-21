using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Techera
{
    public partial class Form1 : Form
    {
        int virusCount;
        public Form1()
        {
            InitializeComponent();
        }

        //              FOLDER SELECT BUTTON CLICK EVENT                //
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string selectedPath = folderBrowserDialog1.SelectedPath;

            if (!string.IsNullOrEmpty(selectedPath))
            {
                MessageBox.Show(selectedPath);
                virusCount = 0;
                guna2ProgressBar1.Value = 0;
                //listBox1.Items.Clear();
                guna2Button2.Enabled = true; // Enable the "Scan" button
            }
        }

        //              SCAN BUTTON CLICK EVENT                //
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string[] search = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*");
            int searchLength = search.Length;

            if (double.IsNaN(searchLength))
            {
                searchLength = 0;
            }

            guna2ProgressBar1.Maximum = searchLength;
            foreach (string item in search)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(item);
                    string read = streamReader.ReadToEnd();
                    string[] virus = new string[] { "trojan", "virus", "hacking", "hacker", "adware", "malware", "spyware", "freeware", "RAT" };
                    
                    foreach(string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            virusCount += 1;
                            listBox1.Items.Add("\n");
                            listBox1.Items.Add("\n");
                            listBox1.Items.Add("\t[" + virusCount + "]\t" + st.ToUpper() + "\t\t" + item);
                        }
                    }
                    guna2ProgressBar1.Increment(1);
                }
                catch
                {
                    string read = item;
                    string[] virus = new string[] { "trojan", "virus", "hacking", "hacker", "adware", "malware", "spyware", "freeware", "RAT" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            virusCount += 1;
                            listBox1.Items.Add("\n");
                            listBox1.Items.Add("\n");
                            listBox1.Items.Add("\t[" + virusCount + "]\t" + st.ToUpper() + "\t\t" + item);
                        }
                    }
                    guna2ProgressBar1.Increment(1);
                }
            }
        }

        //              EXIT BUTTON CLICK EVENT                //
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
