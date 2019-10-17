using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public void OnClickSignInButton()
    {
        string info = GetUserInfo("SignIn");
        Debug.Log(info);

        // POST info to server

        // GET result from server 
        string nameFromServer = "";

        if (nameFromServer == "") // failed
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.name = "";
            GameObject.Find("Username").GetComponent<InputField>().text = "";

            Managers.Game.password = "";
            GameObject.Find("Password").GetComponent<InputField>().text = "";
        } else
        {
            Managers.Game.name = nameFromServer;
            Debug.Log("Sign in OK");
        }
    }

    public void OnClickSignUpButton()
    {
        
        string info = GetUserInfo("SignUp");
        Debug.Log(info);

        // POST info to server

        // GET result from server 
        string result = "";

        if (result.Equals("false"))
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.name = "";
            GameObject.Find("Username").GetComponent<InputField>().text = "";

            Managers.Game.password = "";
            GameObject.Find("Password").GetComponent<InputField>().text = "";

        } else
        {
            GameObject.Find("Login").SetActive(false);
            Managers.UI.popUps.ActivateVerifyPopUp();
            Managers.UI.panel.SetActive(true);
        }
    }

    public void OnClickVerifyButton()
    {

        string token = GameObject.Find("Verification").GetComponent<InputField>().text;
        string info = "{\"action\":\"verify\",\"mobile\":\"" + Managers.Game.phone + 
            "\",\"token\":\"" + token + "\"}";
        Debug.Log(info);

        if (true)
        {
            Debug.Log("Sign up OK");
            GameObject.Find("SignUpOK").GetComponent<CanvasGroup>().alpha = 1;
        } else
        {
            Managers.Game.phone = "";
            GameObject.Find("PhoneNumber").GetComponent<InputField>().text = "";

            Managers.Game.name = "";
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
            return "{\"mobile\":\"" + Managers.Game.phone +
                "\", \"username\":\"" + Managers.Game.username +
                "\",\"password\":\"" + Managers.Game.password +
                "\"}";
        } else if (type.Equals("SignIn"))
        {
            return "{\"mobile\":\"" + Managers.Game.phone +
                "\",\"password\":\"" + Managers.Game.password +
                "\"}";
        } else return "";
    }
}
