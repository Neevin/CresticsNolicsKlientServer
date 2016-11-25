using System;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace XO_Online
{
    public static class Connection
    {
        public static string[] signup(string login, string password)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/user");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "POST";
            string parameters = "login=" + login + "&password=" + password; ;
            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            webResponse.Close();
            dynamic jsonEncode = JObject.Parse(responseFromServer);
            if (jsonEncode.Issue != null)
            {
                string[] result = new string[1];
                result[0] = (string)jsonEncode.Issue;
                return result;
            }
            else
            {
                string[] result = new string[2];
                result[0] = (string)jsonEncode.login;
                result[1] = (string)jsonEncode.countOfWins;
                return result;
            }
        }
        public static JArray getOnlineUsers(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/get_online_users?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            if (responseFromServer.CompareTo("0") == 0) return null;
            else return JArray.Parse(responseFromServer);
        }
        public static JArray getWaitUsers()
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/get_wait_users");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            if (responseFromServer.CompareTo("0") == 0) return null;
            else return JArray.Parse(responseFromServer);
        }
        public static void playGame(int gameId, string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/play_game?game_id="+gameId+"&login="+login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void exit(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/exit?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void sendMessage(string userFrom, string userTo, string message)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/message");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "POST";
            string parameters = "user_from=" + userFrom + "&user_to=" + userTo + "&message=" + message;
            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            webResponse.Close();
        }
        public static string getMessages(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/get_messages?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            if (responseFromServer.CompareTo("0") == 0) return null;
            else return responseFromServer;
        }
        public static string setUserWait(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/set_user_wait?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            return responseFromServer;
        }
        public static void setUserWin(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/set_user_win?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/x-www-form-urlencoded";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void setUserLouse(string login)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/set_user_louse?login=" + login);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/x-www-form-urlencoded";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void step(string login, int stepId, int gameId, int x, int y)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/step?login=" + login + "&step_id=" + stepId + "&game_id=" + gameId + "&x=" + x + "&y=" + y);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static int[] getLastStep(int stepId, int gameId)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/get_last_step?&step_id=" + stepId + "&game_id=" + gameId);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            if (responseFromServer.CompareTo("AGAIN") == 0) return null;
            dynamic jobj = JObject.Parse(responseFromServer);
            int[] result = new int[2];
            result[0] = jobj.x;
            result[1] = jobj.y;
            return result;
        }
        public static void clearSteps(int gameId)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/clear_steps?game_id=" + gameId);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void deleteGame(int gameId)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/delete_game?game_id=" + gameId);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/json";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static void setLastActivity(string login, string time)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/set_last_activity?login=" + login + "&time=" + time);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/x-www-form-urlencoded";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
        }
        public static string getLastActivity(string login, string timeNow)
        {
            WebRequest webRequest = WebRequest.Create("http://xo.online/get_last_activity?login=" + login + "&time_now=" + timeNow);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)webRequest).UserAgent = ".NET Framework Example Client";
            webRequest.Method = "GET";
            ((HttpWebRequest)webRequest).Accept = "application/x-www-form-urlencoded";
            WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = reader.ReadToEnd().ToString();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            webResponse.Close();
            return responseFromServer;
        }
    }
}
