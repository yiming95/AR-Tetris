using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System;

public class LeaderboardButton : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public void OnClickLeaderboardButton()
    {
        Managers.UI.popUps.DeactivatePlayerStatsPopUp();
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivateLeaderboardPopUp();


        string s = "data={\"mobile\":\"" + Managers.Game.phone + 
                    "\",\"mark\":\"" + Managers.Score.highScore +
                    "\"}";

        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri("http://122.51.41.188:8080/MobileServer/UploadServlet?" + s));
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


        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri("http://122.51.41.188:8080/MobileServer/RequestMarkServlet"));
        webReq.Method = "POST";
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
            string myPos = "My Position is: "+str.Split('@')[0];

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
}
