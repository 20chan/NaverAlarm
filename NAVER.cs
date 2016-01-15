using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinHttp;

namespace NaverAlarm
{
    public class Naver
    {
        public static bool Login(string id, string pw)
        {
            WinHttpRequest winhttp = new WinHttpRequest();
            winhttp.Open("POST", "https://nid.naver.com/nidlogin.login");
            winhttp.SetRequestHeader("Referer", "https://nid.naver.com/nidlogin.login?svctype=262144&url=http://m.naver.com/aside/");
            winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            winhttp.Send("id=" + id + "&pw=" + pw + "&saveID=0&enctp=2&smart_level=-1&svctype=0");
            if (winhttp.ResponseText.Contains("https://nid.naver.com/login/sso/finalize.nhn?url"))
            {
                return true;
            }
            return false;
        }

        public static int GET_NOTI_COUNT(string id, string pw)
        {
            try
            {
                WinHttpRequest winhttp = new WinHttpRequest();
                winhttp.Open("POST", "https://nid.naver.com/nidlogin.login");
                winhttp.SetRequestHeader("Referer", "https://nid.naver.com/nidlogin.login?svctype=262144&url=http://m.naver.com/aside/");
                winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                winhttp.Send("id=" + id + "&pw=" + pw + "&saveID=0&enctp=2&smart_level=-1&svctype=0");
                if (winhttp.ResponseText.Contains("https://nid.naver.com/login/sso/finalize.nhn?url"))
                {
                    winhttp.Open("GET", "http://my.naver.com/");
                    winhttp.Send();
                    string[] result = winhttp.ResponseText.Split(new string[] { "\"noti\":" }, StringSplitOptions.None);
                    int NOTI_COUNT = Convert.ToInt32(result[1].Split(',')[0]);
                    return NOTI_COUNT;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
