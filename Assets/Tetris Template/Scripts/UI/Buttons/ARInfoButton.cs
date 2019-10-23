using UnityEngine;
using System.Collections;

public class ARInfoButton : MonoBehaviour
{

    public void OnClickInfoButton()
    {
        Managers.Audio.PlayUIClick();
        Managers.UI.popUps.ARInfoButtonPopUp();
        //Managers.UI.panel.SetActive(true);
    }
}