using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System;

using System.Collections;

public class LeaderboardButton : MonoBehaviour
{
    public static string servletUri = "http://10.13.144.219:8080";
    private static readonly HttpClient client = new HttpClient();
    string GetGps;

    public void OnClickLeaderboardButton()
    {

        Managers.UI.popUps.DeactivatePlayerStatsPopUp();
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivateLeaderboardPopUp();


        string s = "data={\"mobile\":\"" + Managers.Game.phone +
                    "\",\"mark\":\"" + Managers.Score.highScore + "\",\"gps_x\":" + "\"" + GetGPS.x + "\"" + ",\"gps_y\":" + "\"" + GetGPS.y +
                    "\"}";

        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri(servletUri + "/MobileServer/UploadServlet?" + s));
        updateHS.Method = "GET";
        updateHS.ContentType = "application/x-www-form-urlencoded;charset=UTF8";

        //Stream stream = updateHS.GetRequestStream();   
        //stream.Write(Encoding.UTF8.GetBytes(s),0,s.Length);

        Debug.Log(s);
        using (WebResponse res = updateHS.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(str);
            responseStream.Close();
        }
        //stream.Close();


        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(servletUri + "/MobileServer/RequestMarkServlet?" + s));
        webReq.Method = "GET";
        webReq.ContentType = "application/x-www-form-urlencoded;charset=UTF8";
        using (WebResponse res = webReq.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(str);
            string[] infos = str.Split('}');
            string myPos = "My Rank is: " + str.Split('@')[0];

            string userTxt = "Name\n";
            string scoreTxt = "Score\n";
            GameObject.Find("MyPosition").GetComponent<Text>().text = myPos;

            foreach (string info in infos)
            {
                if (info.Length > 1)
                {
                    userTxt = String.Concat(userTxt, info.Substring(info.IndexOf("username") + 11, info.LastIndexOf("\"") - info.IndexOf("username") - 11) + "\n");
                }
            }
            GameObject.Find("Usernames").GetComponent<Text>().text = userTxt;

            foreach (string info in infos)
            {
                if (info.Length > 1)
                {
                    scoreTxt = String.Concat(scoreTxt, info.Substring(info.IndexOf("mark") + 6, info.LastIndexOf(",\"") - info.IndexOf("mark") - 6) + "\n");
                }
            }
            GameObject.Find("Scores").GetComponent<Text>().text = scoreTxt;

            streamReader.Close();
            responseStream.Close();

        }
        //Managers.UI.panel.SetActive(true);
    }

    public void OnClickLocalButton()
    {
        Managers.UI.popUps.DeactivatePlayerStatsPopUp();
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivateLocalPopUp();


        string s = "data={\"mobile\":\"" + Managers.Game.phone +
                    "\",\"mark\":\"" + Managers.Score.highScore + "\",\"gps_x\":" + "\"" + GetGPS.x + "\"" + ",\"gps_y\":" + "\"" + GetGPS.y +
                    "\"}";
        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri(servletUri + "/MobileServer/UploadServlet?" + s));
        updateHS.Method = "GET";
        updateHS.ContentType = "application/x-www-form-urlencoded;charset=UTF8";

        //Stream stream = updateHS.GetRequestStream();   
        //stream.Write(Encoding.UTF8.GetBytes(s),0,s.Length);

        Debug.Log(s);
        using (WebResponse res = updateHS.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(str);
            responseStream.Close();
        }
        //stream.Close();


        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(servletUri + "/MobileServer/RequestLocalServlet?" + s));
        webReq.Method = "GET";
        webReq.ContentType = "application/x-www-form-urlencoded;charset=UTF8";
        using (WebResponse res = webReq.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(str);
            string[] infos = str.Split('}');
            string myPos = "My Rank is: " + str.Split('@')[0];

            string userTxt = "Name\n";
            string scoreTxt = "Score\n";
            GameObject.Find("MyPosition2").GetComponent<Text>().text = myPos;

            foreach (string info in infos)
            {
                if (info.Length > 1)
                {
                    userTxt = String.Concat(userTxt, info.Substring(info.IndexOf("username") + 11, info.LastIndexOf("\"") - info.IndexOf("username") - 11) + "\n");
                }
            }
            GameObject.Find("Usernames2").GetComponent<Text>().text = userTxt;

            foreach (string info in infos)
            {
                if (info.Length > 1)
                {
                    scoreTxt = String.Concat(scoreTxt, info.Substring(info.IndexOf("mark") + 6, info.LastIndexOf(",\"") - info.IndexOf("mark") - 6) + "\n");
                }
            }
            GameObject.Find("Scores2").GetComponent<Text>().text = scoreTxt;

            streamReader.Close();
            responseStream.Close();

        }

    }
}
