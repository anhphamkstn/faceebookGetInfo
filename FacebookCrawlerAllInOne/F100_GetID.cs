using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace FacebookCrawlerAllInOne
{
    public partial class F100_GetID : Form
    {
        CookieCollection m_cookie_collection = new CookieCollection();
        Stack<string> m_stk = new Stack<string>();
        string m_id_admin = "";

        public F100_GetID()
        {
            InitializeComponent();
            m_bgwk.WorkerSupportsCancellation = true;
            m_bgwk.WorkerReportsProgress = true;
        }

        private void F100_GetID_Load(object sender, EventArgs e)
        {
            CGlobal.LoadData2CboDanhSachCookie(m_cbo_cookies);
        }

        private void m_cmd_start_Click(object sender, EventArgs e)
        {
            ReadCookieFromFile();
            m_txt_id.Text = m_txt_id.Text.Trim();
            this.Text = this.Text +" <----> "+ m_cbo_cookies.SelectedItem.ToString();
            try
            {
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
            }
        }

        private void m_bgwk_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            layDanhSachBanBe(worker, m_txt_id.Text.Trim());
        }

        private void layDanhSachBanBe(BackgroundWorker worker, string ip_id_user)
        {
            int v_start = 0;
            do
            {
                var result = CGlobal.MakeRequest(
                "https://www.facebook.com/ajax/browser/list/allfriends/?uid=" + ip_id_user + "&__user=" + m_id_admin + "&__a=1&start=" + v_start.ToString()
                , "GET"
                , ""
                , m_cookie_collection);
                var v_count_user = getAllUser(result);
                if (v_count_user == 0)
                {
                    if (stackRong())
                    {
                        break;    
                    }
                    else
                    {
                        ip_id_user = m_stk.Pop();
                        v_start = 0;
                    }
                }
                else
                {
                    worker.ReportProgress(v_count_user);
                    v_start += 24;
                }                
            } while (true);            
        }

        private int getAllUser(HttpWebResponse ip_http_response) {
            string v_str_json = getJsonFromWebResponse(ip_http_response);
            string v_str_html = getHTMLFromJson(v_str_json);
            HtmlAgilityPack.HtmlDocument v_doc = new HtmlAgilityPack.HtmlDocument();
            v_doc.LoadHtml(v_str_html);
            var findclasses = v_doc.DocumentNode.Descendants("li").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("fbProfileBrowserListItem")).ToList();
            int v_count = 0;
            foreach (var item in findclasses)
            {
                try
                {
                    FBCrawlerV2Entities v_model = new FBCrawlerV2Entities();
                    FACEBOOK_USER v_fb_user = new FACEBOOK_USER();
                    v_fb_user.NAME = item.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("fsl fwb fcb")).First().InnerText;
                    var v_user = item.Descendants("a").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("_8o _8t lfloat _ohe")).First();
                    v_fb_user.PROFILE_LINK = v_user.Attributes["href"].Value.ToString().Split('?')[0];
                    var v_str_contain_id = v_user.Attributes["data-hovercard"].Value.ToString();
                    v_fb_user.ID = GetSubStrings(v_str_contain_id, "id=", "&").First();
                    v_fb_user.GET_BY = m_id_admin;
                    v_fb_user.GET_TIME = DateTime.Now;
                    v_fb_user.LANGUAGE = detectLanguage(v_fb_user.NAME);
                    v_fb_user.CHECKED = false;
                    v_model.FACEBOOK_USER.Add(v_fb_user);
                    v_model.SaveChanges();
                    v_count += 1;
                    if (v_fb_user.LANGUAGE.Contains("vi"))
                    {
                        m_stk.Push(v_fb_user.ID);
                    }
                }
                catch (Exception)
                {

                }                
            }
            return v_count;
        }

        private string detectLanguage(string ip_str_name)
        {
            var ip_http_response = CGlobal.MakeRequest(
                "https://translate.google.com/translate_a/single?client=t&sl=auto&tl=vi&hl=vi&dt=bd&dt=ex&dt=ld&dt=md&dt=qc&dt=rw&dt=rm&dt=ss&dt=t&dt=at&ie=UTF-8&oe=UTF-8&srcrom=0&ssel=3&tsel=0&kc=0&tk=520787|764024&q="+ip_str_name
                , "GET"
                , ""
                , new CookieCollection());
            Stream stream = ip_http_response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var v_str_json = reader.ReadToEnd();
            if (v_str_json.Contains("\"vi\""))
            {
                return "vi";
            }
            else
            {
                return "";
            }
        }

        private string getHTMLFromJson(string v_str_json)
        {
            try
            {
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                Dictionary<string, object> routes_list = (Dictionary<string, object>)json_serializer.DeserializeObject(v_str_json);
                dynamic z = routes_list["domops"];
                routes_list = z[0][3];
                return routes_list["__html"].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string getJsonFromWebResponse(HttpWebResponse ip_http_response)
        {
            try
            {
                Stream stream = ip_http_response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var v_str_json = reader.ReadToEnd();
                var v_index = v_str_json.IndexOf('{');
                v_str_json = v_str_json.Substring(v_index, v_str_json.Length - v_index);
                return v_str_json;
            }
            catch (Exception)
            {
                return "";
            }            
        }

        private bool stackRong()
        {
            if (m_stk.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerable<string> GetSubStrings(string input, string start, string end)
        {
            Regex r = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
            MatchCollection matches = r.Matches(input);
            foreach (Match match in matches)
                yield return match.Groups[1].Value;
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
    }
}
