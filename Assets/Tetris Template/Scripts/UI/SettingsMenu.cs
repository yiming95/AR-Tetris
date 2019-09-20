
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject soundCross;
    public GameObject soundOnText;
    public GameObject soundOffText;

    public void TurnUpDownSound()
    {
        if (AudioListener.volume == 0)
        {
            soundCross.SetActive(false);
            soundOffText.SetActive(false);
            soundOnText.SetActive(true);
            AudioListener.volume = 1.0f;
            Managers.Audio.PlayUIClick();
        }
        else if (AudioListener.volume == 1.0f)
        {
            soundCross.SetActive(true);
            soundOffText.SetActive(true);
            soundOnText.SetActive(false);
            AudioListener.volume = 0f;
        }
    }

    public void OpenFacebookPage()
    {
        Application.OpenURL(Constants.FACEBOOK_URL);
    }

    public void OpenTwitterPage()
    {
        Application.OpenURL(Constants.TWITTER_URL);
    }

    public void OpenContact()
    {
        Application.OpenURL(Constants.CONTACT_URL);
    }

    public void RateAsset()
    {
        Application.OpenURL(Constants.ASSETSTORE_URL);
    }
}
