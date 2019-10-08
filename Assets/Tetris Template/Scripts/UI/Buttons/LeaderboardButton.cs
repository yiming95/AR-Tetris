using UnityEngine;
using System.Collections;
using System.Net.Http;

public class LeaderboardButton : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public void OnClickLeaderboardButton()
    {
        Managers.UI.popUps.DeactivatePlayerStatsPopUp();
        Managers.Audio.PlayUIClick();
        var responseString = client.GetStringAsync("http://10.13.134.173:8080/MobileServer/RequestMarkServlet");
        var test = "[{ mobile:345678,mark:500,username:SON}]";
        Debug.Log("test");
        Debug.Log(responseString);
        Managers.UI.popUps.ActivateLeaderboardPopUp();
        Managers.UI.panel.SetActive(true);
    }
}
