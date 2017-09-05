using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Captura.Models
{
    class UrlParse
    {
        private static void ParseUrl(string url, out string baseUrl, out NameValueCollection nvc)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            nvc = new NameValueCollection();
            baseUrl = "";

            if (url == "")
                return;

            int questionMarkIndex = url.IndexOf('?');

            if (questionMarkIndex == -1)
            {
                baseUrl = url;
                return;
            }
            baseUrl = url.Substring(0, questionMarkIndex);
            if (questionMarkIndex == url.Length - 1)
                return;
            string ps = url.Substring(questionMarkIndex + 1);

            // 开始分析参数对    
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(ps);

            foreach (Match m in mc)
            {
                nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
            }
        }

        public static void validate(string meetingParams, string validateName, string validateId)
        {
            string protocol;
            NameValueCollection collection;
            ParseUrl(meetingParams, out protocol, out collection);
            string meeting_id = collection.Get("meeting_id");
            string meeting_name = collection.Get("meeting_name");
            string hoster_id = collection.Get("hoster_id");
            string hoster_name = collection.Get("hoster_name");
            string sign = collection.Get("sign");
            string timestramp = collection.Get("timestramp");
            string meeting_push_uri = collection.Get("meeting_push_uri");
            string local_sign = MD5Encrypt(meeting_id + meeting_name + hoster_id +
                                           hoster_name + timestramp + validateName + validateId);
            if (!local_sign.Equals(sign))
            {
                throw new Exception("validate");
            }
            Settings.Instance.MeetingId = meeting_id;
            Settings.Instance.MeetingName = meeting_name;
            Settings.Instance.HosterId = hoster_id;
            Settings.Instance.HosterName = hoster_name;
            Settings.Instance.MeetingPushUrl =
                DecodeBase64(Encoding.UTF8, meeting_push_uri);
            Console.WriteLine(Settings.Instance.MeetingPushUrl);
        }

        private static string MD5Encrypt(string strText)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string a = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText)));
            a = a.Replace("-", "");
            return a.ToLower();
        }


        private static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }
    }
}