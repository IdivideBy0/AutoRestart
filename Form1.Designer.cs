namespace AutoRestart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFileLoc = new System.Windows.Forms.TextBox();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnAddToMonitorList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program to restart";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtFileLoc
            // 
            this.txtFileLoc.Location = new System.Drawing.Point(187, 12);
            this.txtFileLoc.Name = "txtFileLoc";
            this.txtFileLoc.Size = new System.Drawing.Size(338, 20);
            this.txtFileLoc.TabIndex = 1;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(106, 10);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 2;
            this.btnGetFile.Text = "File";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddToMonitorList
            // 
            this.btnAddToMonitorList.Location = new System.Drawing.Point(15, 39);
            this.btnAddToMonitorList.Name = "btnAddToMonitorList";
            this.btnAddToMonitorList.Size = new System.Drawing.Size(510, 23);
            this.btnAddToMonitorList.TabIndex = 3;
            this.btnAddToMonitorList.Text = "Add to Monitor List";
            this.btnAddToMonitorList.UseVisualStyleBackColor = true;
            this.btnAddToMonitorList.Click += new System.EventHandler(this.btnAddToMonitorList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(510, 148);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRun.Location = new System.Drawing.Point(15, 271);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(191, 31);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Start Monitoring";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(412, 279);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(113, 17);
            this.chkAutoStart.TabIndex = 6;
            this.chkAutoStart.Text = "Start Automatically";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(30, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(479, 24);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Auto Restart is Actively Monitoring these Programs";
            this.lblStatus.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(212, 271);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(194, 32);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop Monitoring";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 315);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddToMonitorList);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.txtFileLoc);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Auto Restart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFileLoc;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnAddToMonitorList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStop;
    }
}

