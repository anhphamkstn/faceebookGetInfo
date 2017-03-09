using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FacebookCrawlerAllInOne
{
    public partial class F200_Get_Info : Form
    {
        public F200_Get_Info()
        {
            InitializeComponent();
            m_bgwk.WorkerSupportsCancellation = true;
            m_bgwk.WorkerReportsProgress = true;
        }

        private void m_cmd_start_Click(object sender, EventArgs e)
        {
            try
            {
                ReadCookieFromFile();
                this.Text = this.Text + " <----> " + m_cbo_cookies.SelectedItem.ToString();

                if (m_bgwk.IsBusy != true)
                {
                    m_cmd_start.Text = "Dừng lại";
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

        private void m_bgwk_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            lay_danh_sach_user(worker);
        }

        private void m_bgwk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_lbl_so_luong.Text = (int.Parse(m_lbl_so_luong.Text) + e.ProgressPercentage).ToString();
        }

        private void m_bgwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.tbProgress.Text = "Canceled!";
                m_cmd_start.Text = "Bắt đầu";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress.Text = ("Error: " + e.Error.Message);
                m_cmd_start.Text = "Bắt đầu";
            }

            else
            {
                this.tbProgress.Text = "Done!";
                m_cmd_start.Text = "Bắt đầu";
            }
        }

        string m_id_admin = "";
        string m_fb_dtsg = "";
        CookieCollection m_cookie_collection = new CookieCollection();

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

        private void lay_danh_sach_user(BackgroundWorker ip_wk)
        {
            do
            {
                FBCrawlerV2Entities v_model = new FBCrawlerV2Entities();
                var v_lst_user = v_model.FACEBOOK_USER.Where(x => x.CHECKED == false).Take(100).ToList();
                if (v_lst_user.Count == 0)
                {
                    break;
                }
                foreach (var item in v_lst_user)
                {
                    item.CHECKED = true;
                }
                v_model.SaveChanges();
                foreach (var item in v_lst_user)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    //===========
                    lay_thong_tin_user(item, ip_wk);
                    //===========
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    //===========
                    //sleep();
                    Thread.Sleep(30 * 1000);
                }
            } while (true);
        }

        private void lay_thong_tin_user(FACEBOOK_USER ip_user, BackgroundWorker ip_wk)
        {
            try
            {
                FBCrawlerV2Entities v_model = new FBCrawlerV2Entities();
                INFO v_info = new INFO();
                //=========
                v_info.ID = ip_user.ID;
                v_info.LIVING = get_living(ip_user.ID.Trim());
                v_info.CONTACT_INFO = get_contact_info(ip_user.ID.Trim());
                v_info.EDUCATION = get_education(ip_user.ID.Trim());
                //=========
                v_model.INFOes.Add(v_info);
                v_model.SaveChanges();
                ip_wk.ReportProgress(1);
            }
            catch (Exception)
            {
                
            }
        }

        private string get_education(string ip_id_user)
        {
            var v_result = "";
            v_result = makeRequestWithDataPost("https://www.facebook.com/profile/async/infopage/nav/?dom_section_id=u_jsonp_2_0&profile_id=" + ip_id_user + "&section=edu_work&viewer_id=" + m_id_admin.Trim());
            var v_index = v_result.IndexOf('{');
            v_result = v_result.Substring(v_index, v_result.Length - v_index);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> routes_list = (Dictionary<string, object>)json_serializer.DeserializeObject(v_result);
            dynamic z = routes_list["domops"];
            routes_list = z[0][3];
            v_result = routes_list["__html"].ToString();
            //==============
            HtmlAgilityPack.HtmlDocument v_doc = new HtmlAgilityPack.HtmlDocument();
            v_doc.LoadHtml(v_result);
            v_result = "";
            var v_lst_li = v_doc.DocumentNode.Descendants("li").ToList();
            foreach (var item in v_lst_li)
            {
                v_result += item.InnerText + ";";
            }
            //==============
            return v_result;
        }

        private string get_contact_info(string ip_id_user)
        {
            var v_result = "";
            v_result = makeRequestWithDataPost("https://www.facebook.com/profile/async/infopage/nav/?dom_section_id=u_jsonp_2_0&profile_id=" + ip_id_user + "&section=contact_basic&viewer_id=" + m_id_admin.Trim());
            var v_index = v_result.IndexOf('{');
            v_result = v_result.Substring(v_index, v_result.Length - v_index);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> routes_list = (Dictionary<string, object>)json_serializer.DeserializeObject(v_result);
            dynamic z = routes_list["domops"];
            routes_list = z[0][3];
            v_result = routes_list["__html"].ToString();
            //==============
            HtmlAgilityPack.HtmlDocument v_doc = new HtmlAgilityPack.HtmlDocument();
            v_doc.LoadHtml(v_result);
            v_result = "";
            var v_lst_li = v_doc.DocumentNode.Descendants("li").ToList();
            foreach (var item in v_lst_li)
            {
                v_result += item.InnerText + ";";
            }
            //==============
            return v_result;
        }

        private string get_living(string ip_id_user)
        {
            var v_result = "";
            v_result = makeRequestWithDataPost("https://www.facebook.com/profile/async/infopage/nav/?dom_section_id=u_jsonp_2_0&profile_id=" + ip_id_user + "&section=places&viewer_id=" + m_id_admin.Trim());
            var v_index = v_result.IndexOf('{');
            v_result = v_result.Substring(v_index, v_result.Length - v_index);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Dictionary<string, object> routes_list = (Dictionary<string, object>)json_serializer.DeserializeObject(v_result);
            dynamic z = routes_list["domops"];
            routes_list = z[0][3];
            v_result = routes_list["__html"].ToString();
            //==============
            HtmlAgilityPack.HtmlDocument v_doc = new HtmlAgilityPack.HtmlDocument();
            v_doc.LoadHtml(v_result);
            v_result = "";
            var v_lst_li = v_doc.DocumentNode.Descendants("li").ToList();
            foreach (var item in v_lst_li)
            {
                v_result += item.InnerText + ";";
            }
            //==============
            return v_result;
        }

        private string makeRequestWithDataPost(string ip_url)
        {
            CookieContainer v_c = new CookieContainer();
            v_c.Add(m_cookie_collection);
            var request = (HttpWebRequest)WebRequest.Create(ip_url);
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.159 CoRom/33.0.1750.159 Safari/537.36";
            request.CookieContainer = v_c;
            string postData = dataPost();
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream newStream = request.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            newStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        private string dataPost()
        {
            return "__user=" + m_id_admin.Trim() + "&__a=1&__dyn=7nmajEyl2lm9o-t2u5bGyk4BBxSq78hACF298yut9LFwxBxCbzES2N6xybxu3fzoy2e4K5ebAxacGEyrKiHw&__req=e&fb_dtsg=" + m_fb_dtsg.Trim() + "&ttstamp=2658172527456718685485180&__rev=1699252";
        }

        private void F200_Get_Info_Load(object sender, EventArgs e)
        {
            CGlobal.LoadData2CboDanhSachCookie(m_cbo_cookies);
        }
    }
}
