using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FacebookCrawlerAllInOne
{
    public partial class F300_Send_message : Form
    {
        string m_id_admin = "";
        string m_fb_dtsg = "";
        CookieCollection m_cookie_collection = new CookieCollection();

        public F300_Send_message()
        {
            InitializeComponent();
        }

        private void m_cmd_choose_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_txt_image.Text = openFileDialog1.FileName;
            }
        }

        private void F300_Send_message_Load(object sender, EventArgs e)
        {
            CGlobal.LoadData2CboDanhSachCookie(m_cbo_cookies);
        }

        private void m_bgwk_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < m_clb_receiver.CheckedItems.Count; i++)
                {
                    string v_id_user_receiver = m_clb_receiver.CheckedItems[i].ToString();
                    var v_str_message = m_txt_message.Text;
                    sendMessage(m_id_admin, v_id_user_receiver, m_txt_image.Text, v_str_message);
                }
            }
            catch (Exception)
            {

            }
        }

        private void sendMessage(string ip_id_from, string ip_id_to, string ip_str_path_image, string ip_str_message)
        {
            string v_data_post = "";
            if (ip_str_path_image.Trim() != "")
            {
                string v_id_image = PostImage(ip_str_path_image, m_cookie_collection);
                v_data_post = "message_batch[0][action_type]=ma-type%3Auser-generated-message&message_batch[0][thread_id]&message_batch[0][author]=fbid%3A"+ip_id_from+"&message_batch[0][author_email]&message_batch[0][coordinates]&message_batch[0][is_unread]=false&message_batch[0][is_forward]=false&message_batch[0][is_filtered_content]=false&message_batch[0][is_spoof_warning]=false&message_batch[0][source]=source%3Achat%3Aweb&message_batch[0][source_tags][0]=source%3Achat&message_batch[0][body]="+ ip_str_message.Trim() +"&message_batch[0][has_attachment]=true&message_batch[0][html_body]=false&message_batch[0][specific_to_list][0]=fbid%3A"+ip_id_to+"&message_batch[0][specific_to_list][1]=fbid%3A"+ip_id_from+"&message_batch[0][signatureID]=5ce5951c&message_batch[0][ui_push_phase]=V3&message_batch[0][image_ids][0]=" + v_id_image.Trim() + "&message_batch[0][status]=0&message_batch[0][message_id]=%3C"+ genString(13) +"%3A"+genString(10)+"-"+ genString(10) +"%40mail.projektitan.com%3E&message_batch[0][manual_retry_cnt]=0&message_batch[0][client_thread_id]=user%3A"+ip_id_to+"&client=mercury&__user="+ip_id_from+"&__a=1&__dyn=aJioznEyl2lm98eDgDDzbGyai8Amm74HyUgByVbmAFp4Femt9LHGFolBxiLGjAKGDh8iyqDApuqQihyd7yWCGu4udUSqU8oiUK8UyHjAGl3am8CXjG5Rw&__req=70&fb_dtsg="+m_fb_dtsg+"&ttstamp=2658170526899977311884116100&__rev=1704933";
            }
            else
            {
                v_data_post = "message_batch[0][action_type]=ma-type%3Auser-generated-message&message_batch[0][thread_id]&message_batch[0][author]=fbid%3A"+ip_id_from+"&message_batch[0][author_email]&message_batch[0][coordinates]&message_batch[0][is_unread]=false&message_batch[0][is_forward]=false&message_batch[0][is_filtered_content]=false&message_batch[0][is_spoof_warning]=false&message_batch[0][source]=source%3Achat%3Aweb&message_batch[0][source_tags][0]=source%3Achat&message_batch[0][body]="+ ip_str_message.Trim() +"&message_batch[0][has_attachment]=false&message_batch[0][html_body]=false&&message_batch[0][specific_to_list][0]=fbid%3A"+ip_id_to+"&message_batch[0][specific_to_list][1]=fbid%3A"+ip_id_from+"&message_batch[0][signatureID]=5a46ceda&message_batch[0][ui_push_phase]=V3&message_batch[0][status]=0&message_batch[0][message_id]=%3C"+genString(13)+"%3A"+genString(10)+"-"+genString(10)+"%40mail.projektitan.com%3E&message_batch[0][manual_retry_cnt]=0&&message_batch[0][client_thread_id]=user%3A"+ip_id_to+"&client=mercury&__user="+ip_id_from+"&__a=1&__dyn=aJioznEyl2lm98eDgDDzbGyki8AhUsiKbx2mbAJqiBAiAVpQC-KGBxmm5aV9eiWGt4xa9GuhBVHh968QubGqFUhUTzpLwxxbyUzVGJeiFEOBy8yQWxtpia&__req=5y&fb_dtsg="+m_fb_dtsg+"&ttstamp=265817011377119113107102695465&__rev=1715289";
            }
            var v_result = CGlobal.MakeRequest(
                "https://www.facebook.com/ajax/mercury/send_messages.php"
                , "POST"
                , v_data_post
                , m_cookie_collection);
        }

        private string genString(int p)
        {
            string str = "";
            for (int i = 0; i < p; i++)
            {
                Random rnd = new Random();
                int random = rnd.Next(1, 9);
                str += random.ToString();
            }
            return str;
        }

        private string PostImage(string ip_str_path_image, CookieCollection m_cookie_collection)
        {
            var fs = getContentImage(ip_str_path_image);
            string v_id_image = PostFiles("https://upload.facebook.com/ajax/mercury/upload.php?__user="+m_id_admin+"&__a=1&__dyn=aJioznEyl2lm98eDgDDzbGyai8Amm74HyUgByVbmAEFajBDirWWGm5pokHWAVbGEyi4ECFV6nCJ4AozhUKFGDx7zudCK264Kbye8GQVaCzam8CV9Enm&__req=8f&fb_dtsg="+m_fb_dtsg+"&ttstamp=265817111010210890100687273116&__rev=1704933&ft[tn]=p%2BJ%2BM", fs);
            return v_id_image;
        }

        /// <summary>
        /// Lấy dữ liệu dạng byte của file
        /// </summary>
        /// <param name="fileName">Đường dẫn của file</param>
        /// <returns></returns>
        private byte[] getContentImage(string fileName)
        {
            FileInfo v_fi = new FileInfo(fileName);
            return File.ReadAllBytes(fileName);
        }

        /// <summary>
        /// Request để upload file
        /// </summary>
        /// <param name="url">Đường dẫn upload</param>
        /// <param name="ip_fileInfo">Nội dung file dạng byte</param>
        /// <returns></returns>
        private string PostFiles(string url, byte[] ip_fileInfo)
        {
            CookieContainer v_c = new CookieContainer();
            v_c.Add(m_cookie_collection);
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest.CookieContainer = v_c;
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream memStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            string headerTemplate = "Content-Disposition:form-data;name=\"upload_1026\";filename=\"test.jpg\"\r\nContent-Type:image/jpeg\r\n\r\n";
            string first = "Content-Disposition: form-data; name=\"attach_id\"\r\n\r\n";
            byte[] firstBytes = System.Text.Encoding.UTF8.GetBytes(first);

            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(headerTemplate);
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            memStream.Write(firstBytes, 0, firstBytes.Length);
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);
            memStream.Write(ip_fileInfo, 0, ip_fileInfo.Length);
            memStream.Write(boundarybytes, 0, boundarybytes.Length);

            httpWebRequest.ContentLength = memStream.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();
            try
            {
                WebResponse webResponse = httpWebRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string v_result = reader.ReadToEnd();
                httpWebRequest = null;
                return getIDImage(v_result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getIDImage(string v_result)
        {
            var v_index = v_result.IndexOf('{');
            v_result = v_result.Substring(v_index, v_result.Length - v_index);
            var file_id =CGlobal.GetSubStrings(v_result, "\"image_id\":", ",").ToList().First();
            return file_id;
        }

        private void m_bgwk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void m_bgwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.tbProgress.Text = "Canceled!";
                m_cmd_send_message.Text = "Bắt đầu";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress.Text = ("Error: " + e.Error.Message);
                m_cmd_send_message.Text = "Bắt đầu";
            }

            else
            {
                this.tbProgress.Text = "Done!";
                m_cmd_send_message.Text = "Bắt đầu";
            }
        }

        private void m_cmd_send_message_Click(object sender, EventArgs e)
        {
            ReadCookieFromFile();
            this.Text = this.Text + " <----> " + m_cbo_cookies.SelectedItem.ToString();
            try
            {
                if (m_bgwk.IsBusy != true)
                {
                    m_cmd_send_message.Text = "Dừng lại";
                    m_bgwk.RunWorkerAsync();
                }
                if (m_bgwk.WorkerSupportsCancellation == true)
                {
                    m_bgwk.CancelAsync();
                }
            }
            catch (Exception v_e)
            {

                throw v_e;
            }
        }

        private void ReadCookieFromFile()
        {
            string cookieString = File.ReadAllText(Directory.GetCurrentDirectory() + "\\cookies\\" + m_cbo_cookies.SelectedItem.ToString());
            var v_lst = cookieString.Split(';');
            foreach (var item in v_lst)
            {
                var str = item.Trim();
                var name_value = str.Split('=');
                Cookie v_cookie = new Cookie(name_value[0], name_value[1]); v_cookie.Domain = ".facebook.com"; m_cookie_collection.Add(v_cookie);
                if (name_value[0].Contains("user"))
                {
                    m_id_admin = name_value[1].Trim();
                }
                if (name_value[0].Contains("dtsg"))
                {
                    m_fb_dtsg = name_value[1].Trim();
                }
            }
        }
    }
}
