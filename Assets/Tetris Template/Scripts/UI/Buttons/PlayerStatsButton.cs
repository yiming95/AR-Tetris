
using UnityEngine;
using System.Collections;

public class PlayerStatsButton : MonoBehaviour
{
    public void OnClickPlayerStatsButton()
    {
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivatePlayerStatsPopUp();
        //Managers.UI.panel.SetActive(true);
    }
}
