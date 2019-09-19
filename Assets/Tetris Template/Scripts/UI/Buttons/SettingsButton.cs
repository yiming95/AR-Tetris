
using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

    public void OnClickSettingsButton()
    {
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ActivateSettingsPopUp();
        Managers.UI.panel.SetActive(true);
    }
}
