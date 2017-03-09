using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookCrawlerAllInOne
{
    public static class CGlobal
    {
        internal static void LoadData2CboDanhSachCookie(ComboBox m_cbo_cookies)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles( currentDirectory +"\\cookies\\");
            for (int i = 0; i < filePaths.Count(); i++)
            {
                FileInfo v_file = new FileInfo(filePaths[i]);
                filePaths[i] = v_file.Name;
            }
            m_cbo_cookies.DataSource = filePaths;
        }

        internal static HttpWebResponse MakeRequest(string ip_url, string ip_method, string ip_data, CookieCollection ip_cookie_collection)
        {
            CookieContainer v_cookie_container = new CookieContainer();
            v_cookie_container.Add(ip_cookie_collection);
            var request = (HttpWebRequest)WebRequest.Create(ip_url);
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = ip_method;
            request.ProtocolVersion = HttpVersion.Version11;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.159 CoRom/33.0.1750.159 Safari/537.36";
            request.CookieContainer = v_cookie_container;
            //======== Nếu method là POST và data khác rỗng thì send data
            if (ip_method == "POST" && ip_data.Trim() != "")
            {
                string postData = ip_data;
                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }
            //========
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }

        internal static IEnumerable<string> GetSubStrings(string input, string start, string end)
        {
            Regex r = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
            MatchCollection matches = r.Matches(input);
            foreach (Match match in matches)
                yield return match.Groups[1].Value;
        }
    }

    public static class stringConstant
    {
        public static string profileLinkStart = "<a class=\"_8_2\" href=\"https://www.facebook.com/";
        public static string profileLinkEnd = "\"";
        public static string nameStart = "<span id=\"fb-timeline-cover-name\">";
        public static string nameEnd = "</span>";
        public static string facebook = "https://facebook.com/";

    }
}
