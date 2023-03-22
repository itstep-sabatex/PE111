namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.buttonTimerStop = new System.Windows.Forms.Button();
            this.buttonStartDelegate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Promatical progress";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(766, 35);
            this.progressBar1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Timer Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonTimerStop
            // 
            this.buttonTimerStop.Location = new System.Drawing.Point(152, 90);
            this.buttonTimerStop.Name = "buttonTimerStop";
            this.buttonTimerStop.Size = new System.Drawing.Size(125, 52);
            this.buttonTimerStop.TabIndex = 3;
            this.buttonTimerStop.Text = "Timer stop";
            this.buttonTimerStop.UseVisualStyleBackColor = true;
            this.buttonTimerStop.Click += new System.EventHandler(this.buttonTimerStop_Click);
            // 
            // buttonStartDelegate
            // 
            this.buttonStartDelegate.Location = new System.Drawing.Point(320, 90);
            this.buttonStartDelegate.Name = "buttonStartDelegate";
            this.buttonStartDelegate.Size = new System.Drawing.Size(153, 52);
            this.buttonStartDelegate.TabIndex = 4;
            this.buttonStartDelegate.Text = "Start Delegate";
            this.buttonStartDelegate.UseVisualStyleBackColor = true;
            this.buttonStartDelegate.Click += new System.EventHandler(this.buttonStartDelegate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartDelegate);
            this.Controls.Add(this.buttonTimerStop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "WinFormThreadDemo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonTimerStop;
        private System.Windows.Forms.Button buttonStartDelegate;
    }
}

