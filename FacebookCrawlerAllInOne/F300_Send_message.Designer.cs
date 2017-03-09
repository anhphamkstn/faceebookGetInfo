namespace FacebookCrawlerAllInOne
{
    partial class F300_Send_message
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
            this.m_clb_receiver = new System.Windows.Forms.CheckedListBox();
            this.m_txt_image = new System.Windows.Forms.TextBox();
            this.m_cmd_choose_file = new System.Windows.Forms.Button();
            this.m_cmd_send_message = new System.Windows.Forms.Button();
            this.m_cbo_cookies = new System.Windows.Forms.ComboBox();
            this.m_bgwk = new System.ComponentModel.BackgroundWorker();
            this.m_txt_message = new System.Windows.Forms.TextBox();
            this.tbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_clb_receiver
            // 
            this.m_clb_receiver.FormattingEnabled = true;
            this.m_clb_receiver.Items.AddRange(new object[] {
            "100005520764735",
            "100004685250081",
            "100009405466687",
            "100004227003627",
            "100009519490365"});
            this.m_clb_receiver.Location = new System.Drawing.Point(274, 13);
            this.m_clb_receiver.Name = "m_clb_receiver";
            this.m_clb_receiver.Size = new System.Drawing.Size(172, 169);
            this.m_clb_receiver.TabIndex = 1;
            // 
            // m_txt_image
            // 
            this.m_txt_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_txt_image.Location = new System.Drawing.Point(12, 173);
            this.m_txt_image.Name = "m_txt_image";
            this.m_txt_image.Size = new System.Drawing.Size(164, 20);
            this.m_txt_image.TabIndex = 5;
            // 
            // m_cmd_choose_file
            // 
            this.m_cmd_choose_file.BackColor = System.Drawing.Color.White;
            this.m_cmd_choose_file.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_cmd_choose_file.Location = new System.Drawing.Point(193, 170);
            this.m_cmd_choose_file.Name = "m_cmd_choose_file";
            this.m_cmd_choose_file.Size = new System.Drawing.Size(75, 25);
            this.m_cmd_choose_file.TabIndex = 6;
            this.m_cmd_choose_file.Text = "Choose File";
            this.m_cmd_choose_file.UseVisualStyleBackColor = false;
            this.m_cmd_choose_file.Click += new System.EventHandler(this.m_cmd_choose_file_Click);
            // 
            // m_cmd_send_message
            // 
            this.m_cmd_send_message.BackColor = System.Drawing.Color.White;
            this.m_cmd_send_message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_cmd_send_message.Location = new System.Drawing.Point(12, 201);
            this.m_cmd_send_message.Name = "m_cmd_send_message";
            this.m_cmd_send_message.Size = new System.Drawing.Size(434, 25);
            this.m_cmd_send_message.TabIndex = 7;
            this.m_cmd_send_message.Text = "Send Message";
            this.m_cmd_send_message.UseVisualStyleBackColor = false;
            this.m_cmd_send_message.Click += new System.EventHandler(this.m_cmd_send_message_Click);
            // 
            // m_cbo_cookies
            // 
            this.m_cbo_cookies.FormattingEnabled = true;
            this.m_cbo_cookies.Location = new System.Drawing.Point(12, 13);
            this.m_cbo_cookies.Name = "m_cbo_cookies";
            this.m_cbo_cookies.Size = new System.Drawing.Size(256, 22);
            this.m_cbo_cookies.TabIndex = 8;
            // 
            // m_bgwk
            // 
            this.m_bgwk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwk_DoWork);
            this.m_bgwk.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.m_bgwk_ProgressChanged);
            this.m_bgwk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwk_RunWorkerCompleted);
            // 
            // m_txt_message
            // 
            this.m_txt_message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_txt_message.Location = new System.Drawing.Point(12, 42);
            this.m_txt_message.Multiline = true;
            this.m_txt_message.Name = "m_txt_message";
            this.m_txt_message.Size = new System.Drawing.Size(256, 121);
            this.m_txt_message.TabIndex = 9;
            // 
            // tbProgress
            // 
            this.tbProgress.AutoSize = true;
            this.tbProgress.Location = new System.Drawing.Point(13, 234);
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(54, 14);
            this.tbProgress.TabIndex = 10;
            this.tbProgress.Text = "Pending...";
            // 
            // F300_Send_message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 257);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.m_txt_message);
            this.Controls.Add(this.m_cbo_cookies);
            this.Controls.Add(this.m_cmd_send_message);
            this.Controls.Add(this.m_cmd_choose_file);
            this.Controls.Add(this.m_txt_image);
            this.Controls.Add(this.m_clb_receiver);
            this.Name = "F300_Send_message";
            this.Text = "F300_Send_message";
            this.Load += new System.EventHandler(this.F300_Send_message_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox m_clb_receiver;
        private System.Windows.Forms.TextBox m_txt_image;
        private System.Windows.Forms.Button m_cmd_choose_file;
        private System.Windows.Forms.Button m_cmd_send_message;
        private System.Windows.Forms.ComboBox m_cbo_cookies;
        private System.ComponentModel.BackgroundWorker m_bgwk;
        private System.Windows.Forms.TextBox m_txt_message;
        private System.Windows.Forms.Label tbProgress;

    }
}