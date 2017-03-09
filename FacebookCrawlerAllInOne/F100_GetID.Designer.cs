namespace FacebookCrawlerAllInOne
{
    partial class F100_GetID
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
            this.m_cbo_cookies = new System.Windows.Forms.ComboBox();
            this.m_cmd_start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lbl_so_luong = new System.Windows.Forms.Label();
            this.m_txt_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_bgwk = new System.ComponentModel.BackgroundWorker();
            this.tbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Cookie";
            // 
            // m_cbo_cookies
            // 
            this.m_cbo_cookies.FormattingEnabled = true;
            this.m_cbo_cookies.Location = new System.Drawing.Point(86, 15);
            this.m_cbo_cookies.Name = "m_cbo_cookies";
            this.m_cbo_cookies.Size = new System.Drawing.Size(186, 21);
            this.m_cbo_cookies.TabIndex = 1;
            // 
            // m_cmd_start
            // 
            this.m_cmd_start.Location = new System.Drawing.Point(101, 105);
            this.m_cmd_start.Name = "m_cmd_start";
            this.m_cmd_start.Size = new System.Drawing.Size(75, 23);
            this.m_cmd_start.TabIndex = 2;
            this.m_cmd_start.Text = "Bắt đầu";
            this.m_cmd_start.UseVisualStyleBackColor = true;
            this.m_cmd_start.Click += new System.EventHandler(this.m_cmd_start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số lượng";
            // 
            // m_lbl_so_luong
            // 
            this.m_lbl_so_luong.AutoSize = true;
            this.m_lbl_so_luong.Location = new System.Drawing.Point(83, 80);
            this.m_lbl_so_luong.Name = "m_lbl_so_luong";
            this.m_lbl_so_luong.Size = new System.Drawing.Size(13, 13);
            this.m_lbl_so_luong.TabIndex = 4;
            this.m_lbl_so_luong.Text = "0";
            // 
            // m_txt_id
            // 
            this.m_txt_id.Location = new System.Drawing.Point(86, 48);
            this.m_txt_id.Name = "m_txt_id";
            this.m_txt_id.Size = new System.Drawing.Size(186, 20);
            this.m_txt_id.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // m_bgwk
            // 
            this.m_bgwk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwk_DoWork);
            this.m_bgwk.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.m_bgwk_ProgressChanged);
            this.m_bgwk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwk_RunWorkerCompleted);
            // 
            // tbProgress
            // 
            this.tbProgress.AutoSize = true;
            this.tbProgress.Location = new System.Drawing.Point(12, 140);
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(46, 13);
            this.tbProgress.TabIndex = 7;
            this.tbProgress.Text = "Pending";
            // 
            // F100_GetID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.tbProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txt_id);
            this.Controls.Add(this.m_lbl_so_luong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cmd_start);
            this.Controls.Add(this.m_cbo_cookies);
            this.Controls.Add(this.label1);
            this.Name = "F100_GetID";
            this.Text = "Get ID";
            this.Load += new System.EventHandler(this.F100_GetID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbo_cookies;
        private System.Windows.Forms.Button m_cmd_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lbl_so_luong;
        private System.Windows.Forms.TextBox m_txt_id;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker m_bgwk;
        private System.Windows.Forms.Label tbProgress;
    }
}