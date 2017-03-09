using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace FacebookCrawlerAllInOne
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void m_menu_item_get_id_Click(object sender, EventArgs e)
        {
            try
            {    
                F100_GetID v_f = new F100_GetID();
                v_f.TopLevel = false;
                v_f.Parent = m_pnl;
                v_f.Show();
            }
            catch (Exception v_e)
            {
                MessageBox.Show(v_e.Message);
            }
        }

        private void m_menu_item_get_info_Click(object sender, EventArgs e)
        {
            try
            {    
                F200_Get_Info v_f = new F200_Get_Info();
                v_f.TopLevel = false;
                v_f.Parent = m_pnl;
                v_f.Show();
            }
            catch (Exception v_e)
            {
                MessageBox.Show(v_e.Message);
            }
        }

        private void m_menu_item_send_message_Click(object sender, EventArgs e)
        {
            try
            {
                F300_Send_message v_f = new F300_Send_message();
                v_f.TopLevel = false;
                v_f.Parent = m_pnl;
                v_f.Show();
            }
            catch (Exception v_e)
            {
                MessageBox.Show(v_e.Message);
            }
        }
    }
}
