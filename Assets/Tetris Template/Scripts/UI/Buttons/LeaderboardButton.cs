using UnityEngine;
using System.Collections;

public class LeaderboardButton : MonoBehaviour
{
    public void OnClickLeaderboardButton()
    {
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivateLeaderboardPopUp();
        Managers.UI.panel.SetActive(true);
    }
}
