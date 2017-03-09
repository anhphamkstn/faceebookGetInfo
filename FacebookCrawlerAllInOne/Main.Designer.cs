namespace FacebookCrawlerAllInOne
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.getIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu_item_get_id = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu_item_get_info = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu_item_send_message = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu_item_post_status = new System.Windows.Forms.ToolStripMenuItem();
            this.managerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu_item_cookie_manager = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pnl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getIDToolStripMenuItem,
            this.managerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // getIDToolStripMenuItem
            // 
            this.getIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menu_item_get_id,
            this.m_menu_item_get_info,
            this.m_menu_item_send_message,
            this.m_menu_item_post_status});
            this.getIDToolStripMenuItem.Name = "getIDToolStripMenuItem";
            this.getIDToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.getIDToolStripMenuItem.Text = "Action";
            // 
            // m_menu_item_get_id
            // 
            this.m_menu_item_get_id.Name = "m_menu_item_get_id";
            this.m_menu_item_get_id.Size = new System.Drawing.Size(152, 22);
            this.m_menu_item_get_id.Text = "GetID";
            this.m_menu_item_get_id.Click += new System.EventHandler(this.m_menu_item_get_id_Click);
            // 
            // m_menu_item_get_info
            // 
            this.m_menu_item_get_info.Name = "m_menu_item_get_info";
            this.m_menu_item_get_info.Size = new System.Drawing.Size(152, 22);
            this.m_menu_item_get_info.Text = "Get Info";
            this.m_menu_item_get_info.Click += new System.EventHandler(this.m_menu_item_get_info_Click);
            // 
            // m_menu_item_send_message
            // 
            this.m_menu_item_send_message.Name = "m_menu_item_send_message";
            this.m_menu_item_send_message.Size = new System.Drawing.Size(152, 22);
            this.m_menu_item_send_message.Text = "Send Message";
            this.m_menu_item_send_message.Click += new System.EventHandler(this.m_menu_item_send_message_Click);
            // 
            // m_menu_item_post_status
            // 
            this.m_menu_item_post_status.Name = "m_menu_item_post_status";
            this.m_menu_item_post_status.Size = new System.Drawing.Size(152, 22);
            this.m_menu_item_post_status.Text = "Post Status";
            // 
            // managerToolStripMenuItem
            // 
            this.managerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menu_item_cookie_manager});
            this.managerToolStripMenuItem.Name = "managerToolStripMenuItem";
            this.managerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.managerToolStripMenuItem.Text = "Manager";
            // 
            // m_menu_item_cookie_manager
            // 
            this.m_menu_item_cookie_manager.Name = "m_menu_item_cookie_manager";
            this.m_menu_item_cookie_manager.Size = new System.Drawing.Size(161, 22);
            this.m_menu_item_cookie_manager.Text = "Cookie Manager";
            // 
            // m_pnl
            // 
            this.m_pnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_pnl.BackgroundImage")));
            this.m_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnl.Location = new System.Drawing.Point(0, 24);
            this.m_pnl.Name = "m_pnl";
            this.m_pnl.Size = new System.Drawing.Size(684, 338);
            this.m_pnl.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.m_pnl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Facebook Crawler All In One";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem getIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_menu_item_get_id;
        private System.Windows.Forms.ToolStripMenuItem m_menu_item_get_info;
        private System.Windows.Forms.ToolStripMenuItem m_menu_item_send_message;
        private System.Windows.Forms.ToolStripMenuItem m_menu_item_post_status;
        private System.Windows.Forms.ToolStripMenuItem managerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_menu_item_cookie_manager;
        private System.Windows.Forms.Panel m_pnl;
    }
}

