using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using System;

public class LoginButton : MonoBehaviour
{
    public void OnClickSignInButton()
    {
        string info = GetUserInfo("SignIn");
        Debug.Log(info);

        // result from server 
        string nameFromServer = "";

        // POST info to server
        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri(LeaderboardButton.servletUri + "/MobileServer/LoginServlet?" + info));
        updateHS.Method = "GET";
        updateHS.ContentType = "application/x-www-form-urlencoded;charset=UTF8";

        Debug.Log(info);
        using (WebResponse res = updateHS.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            nameFromServer = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(nameFromServer);
            responseStream.Close();
        }
        //stream.Close();   

        if (nameFromServer == "") // failed
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.username = "";
            GameObject.Find("Username").GetComponent<InputField>().text = "";

            Managers.Game.password = "";
            GameObject.Find("Password").GetComponent<InputField>().text = "";
            GameObject.Find("Error").GetComponent<CanvasGroup>().alpha = 1;
        } else
        {
            Managers.Game.phone = GameObject.Find("PhoneNumber").GetComponent<InputField>().text;
            Managers.Game.password = GameObject.Find("Password").GetComponent<InputField>().text;
            Managers.Game.username = nameFromServer.Split(',')[0];
            Managers.Score.highScore = Int32.Parse(nameFromServer.Split(',')[1]);
            Managers.Game.stats.highScore = Int32.Parse(nameFromServer.Split(',')[1]);
            Debug.Log(Managers.Score.highScore);
            Managers.UI.inGameUI.UpdateScoreUI();
            Managers.Audio.PlayLineClearSound();//login successfully audio
            Managers.UI.popUps.DeactivateLoginPopUp();
        }
    }

    public void OnClickSignUpButton()
    {
        
        string info = GetUserInfo("SignUp");
        Debug.Log(info);

        // POST info to server

        // GET result from server 
        string result = "";

        // POST info to server
        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri(LeaderboardButton.servletUri + "/MobileServer/RegisterServlet?" + info));
        updateHS.Method = "GET";
        updateHS.ContentType = "application/x-www-form-urlencoded;charset=UTF8";

        Debug.Log(info);
        using (WebResponse res = updateHS.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            result = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(result);
            responseStream.Close();
        }
        //stream.Close();


        if (result.Equals("false"))
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.username = "";
            GameObject.Find("Username").GetComponent<InputField>().text = "";

            Managers.Game.password = "";
            GameObject.Find("Password").GetComponent<InputField>().text = "";

        } else
        {
            GameObject.Find("Login").SetActive(false);
            Managers.Audio.PlayLineClearSound();//sign up successfully audio
            Managers.UI.popUps.ActivateVerifyPopUp();
            //Managers.UI.panel.SetActive(true);
        }
    }

    public void OnClickVerifyButton()
    {

        string token = GameObject.Find("Verification").GetComponent<InputField>().text;
        string info = "data={\"action\":\"verify\",\"mobile\":\"" + Managers.Game.phone + 
            "\",\"token\":\"" + token + "\"}";
        Debug.Log(info);

        // POST info to server
        HttpWebRequest updateHS = (HttpWebRequest)WebRequest.Create(new Uri(LeaderboardButton.servletUri + "/MobileServer/VerifyServlet?" + info));
        updateHS.Method = "GET";
        updateHS.ContentType = "application/x-www-form-urlencoded;charset=UTF8";
        string result = "";
        Debug.Log(info);
        using (WebResponse res = updateHS.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            result = streamReader.ReadToEnd();
            //返回：服务器响应流 
            Debug.LogError(result);
            responseStream.Close();
        }
        //stream.Close();




        if (result.Equals("Verification Success"))
        {
            Debug.Log("Sign up OK");
            GameObject.Find("SignUpOK").GetComponent<CanvasGroup>().alpha = 1;
        } else
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.username = "";
            GameObject.Find("Username").GetComponent<InputField>().text = "";

            Managers.Game.password = "";
            GameObject.Find("Password").GetComponent<InputField>().text = "";
        }
    }

    public string GetUserInfo(string type)
    {
        Managers.Game.phone = GameObject.Find("PhoneNumber").GetComponent<InputField>().text;
        Debug.Log(Managers.Game.phone);

        if (type.Equals("SignUp"))
        {
            Managers.Game.username = GameObject.Find("Username").GetComponent<InputField>().text;
            Debug.Log(Managers.Game.username);
        }

        Managers.Game.password = GameObject.Find("Password").GetComponent<InputField>().text;
        Debug.Log(Managers.Game.password);

        if (type.Equals("SignUp"))
        {
            return "data={\"mobile\":\"" + Managers.Game.phone +
                "\", \"username\":\"" + Managers.Game.username +
                "\",\"password\":\"" + Managers.Game.password +
                "\"}";
        } else if (type.Equals("SignIn"))
        {
            return "data={\"mobile\":\"" + Managers.Game.phone +
                "\",\"password\":\"" + Managers.Game.password +
                "\"}";
        } else return "";
    }
}
