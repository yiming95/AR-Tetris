using UnityEngine;
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
        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri("http://10.13.140.6:8080/MobileServer/RequestMarkServlet"));
        webReq.Method = "POST";
        webReq.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
        using (WebResponse res = webReq.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            //返回：服务器响应流 
            Debug.LogError(str);
        }
        Managers.UI.popUps.ActivateLeaderboardPopUp();
        Managers.UI.panel.SetActive(true);
    }
}
