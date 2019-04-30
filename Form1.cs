using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using AutoRestart.Properties;
using System.Threading;
using System.Diagnostics;

namespace AutoRestart
{
    public partial class Form1 : Form
    {
        
        Thread th;

        string titleCaption = "Auto Restart";

        public Form1()
        {
            InitializeComponent();

            // Look for data folder and load settings
            // if data folder does NOT exist, create it.

            string pathString = GetPathString();

            if (Directory.Exists(pathString))
            {
                //read settings data
                ReadSettingsFile();
                chkAutoStart.Checked = Settings.Default.RunAutomatically;

                if (chkAutoStart.Checked == true)
                {
                    // start the program monitor on programs inside the datagridview or data file
                    StartMonitor();

                }
            }
            else
            {
                CreateDataFolder(pathString);
                CreateNewDataFile(pathString, "settings.txt");
            }


        }



        private string GetPathString()
        {
            string folderName = Environment.GetEnvironmentVariable("localappdata"); ;
            string pathString = System.IO.Path.Combine(folderName, "AutoRestartData");
            return pathString;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("programfiles");
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileLoc.Text = openFileDialog1.FileName.ToString();
        }

        private void btnAddToMonitorList_Click(object sender, EventArgs e)
        {
            //Append data to file
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(GetPathString() + "\\settings.txt", true))
            {
                file.WriteLine(txtFileLoc.Text);
            }

            ReadSettingsFile();

        }

        private void CreateDataFolder(string path)
        {
            try
            {

                System.IO.Directory.CreateDirectory(path);

            }

            catch
            {
                MessageBox.Show("Unable to create data folder", titleCaption);
            }
        }

        private void CreateNewDataFile(string pathname, string filename)
        {
            string pathString = System.IO.Path.Combine(pathname, filename);

            if (!System.IO.File.Exists(pathString))
            {
                System.IO.FileStream fs = System.IO.File.Create(pathString);
                fs.Close();
            }
            else
            {
                MessageBox.Show("File ->" + filename + " already exists.", titleCaption);
                return;
            }

        }

        private void ReadSettingsFile()
        {
            string[] lines = System.IO.File.ReadAllLines(GetPathString() + "\\settings.txt");

            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

            int l = lines.Length;

            for (int i = 0; i < l; i++)
            {


                list.Add(new KeyValuePair<int, string>(i, lines[i]));

            }

            dataGridView1.DataSource = list;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult choice = MessageBox.Show("Do you wish to remove this item from monitoring?", titleCaption, MessageBoxButtons.YesNo);


            if (choice == DialogResult.Yes)
            {

                int row = e.RowIndex;

                string[] lines = System.IO.File.ReadAllLines(GetPathString() + "\\settings.txt");

                List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
                int l = lines.Length;

                for (int i = 0; i < l; i++)
                {
                    list.Add(new KeyValuePair<int, string>(i, lines[i]));
                }


                list.RemoveAt(row);

                // clear previous file contents

                System.IO.File.WriteAllBytes(GetPathString() + "\\settings.txt", new byte[0]);


                //Append data to file

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(GetPathString() + "\\settings.txt", true))
                {


                    foreach (KeyValuePair<int, string> pair in list)
                    {
                        file.WriteLine(pair.Value);
                    }

                }

                ReadSettingsFile();

            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            // Run monitor routines (timed interval to test if app is running

            // System.Diagnostics.Process.Start ("location of the executable");

            StartMonitor();


        }

        private void SaveSettings()
        {

            //Settings.Default.BaudRate = int.Parse(cmbBaudRate.Text);
            Settings.Default.RunAutomatically = chkAutoStart.Checked;
            Settings.Default.Save();

        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {

            //if (chkAutoStart.Checked == true)
            //    btnRun.Enabled = false;
            //else
            //    btnRun.Enabled = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
                th.Abort();
            SaveSettings();
        }

        private void StartMonitor()
        {
            th = new Thread(TestApp); //test and make sure app is running  
            th.Start();
            lblStatus.Visible = true;
            btnRun.Enabled = false;
            dataGridView1.Enabled = false;

        }

        public void TestApp()
        {
            // if app is not running then Start app



            string[] lines = System.IO.File.ReadAllLines(GetPathString() + "\\settings.txt");

            Process[] processes;

            int l = lines.Length;
            while (th.IsAlive)
            {
                for (int i = 0; i < l; i++)
                {

                    processes = Process.GetProcessesByName(lines[i].Substring(lines[i].LastIndexOf(@"\") + 1, (lines[i].LastIndexOf(".") - lines[i].LastIndexOf(@"\")) - 1));
                    if (processes.Length == 0)
                        StartApp(lines[i].ToString());

                }

                System.Threading.Thread.Sleep(100);  // throttle cpu usage for other events .1 of a second
            }
        }

        private void StartApp(string app)
        {
            string args = "";

            if (app.IndexOf('/') > 0)
            {
                args = app.Substring(app.IndexOf('/'));
                app = app.Replace(args, "");
            }

            
            
            System.Diagnostics.Process.Start(app, args);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (th != null)
                th.Abort();
            lblStatus.Visible = false;
            btnRun.Enabled = true;
            dataGridView1.Enabled = true;
        }

    }
}
