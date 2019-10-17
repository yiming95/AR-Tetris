
using UnityEngine;
using System.Collections;
using System;

public class PopUp : MonoBehaviour
{
    public GameObject LoginPopUp;
    public GameObject VerifyPopUp;
    public GameObject gameOverPopUp;
    public GameObject settingsPopUp;
    public GameObject playerStatsPopUp;
    public GameObject leaderboardPopUp;
    public GameObject difficultyPopUp;

    internal void ActivateLoginPopUp()
    {
        LoginPopUp.transform.parent.gameObject.SetActive(true);
        LoginPopUp.SetActive(true);
        Managers.UI.activePopUp = LoginPopUp;
    }

    internal void ActivateVerifyPopUp()
    {
        VerifyPopUp.transform.parent.gameObject.SetActive(true);
        VerifyPopUp.SetActive(true);
        Managers.UI.activePopUp = VerifyPopUp;
    }

    public void ActivateGameOverPopUp()
    {
        gameOverPopUp.transform.parent.gameObject.SetActive(true);
        gameOverPopUp.SetActive(true);
        Managers.UI.activePopUp = gameOverPopUp;
    }

    public void ActivateSettingsPopUp()
    {
        settingsPopUp.transform.parent.gameObject.SetActive(true);
        settingsPopUp.SetActive(true);
        Managers.UI.activePopUp = settingsPopUp;
    }

    public void ActivatePlayerStatsPopUp()
    {
        playerStatsPopUp.transform.parent.gameObject.SetActive(true);
        playerStatsPopUp.SetActive(true);
        Managers.UI.activePopUp = playerStatsPopUp;
    }

    public void DeactivatePlayerStatsPopUp()
    {
        playerStatsPopUp.transform.parent.gameObject.SetActive(false);
        playerStatsPopUp.SetActive(false);
    }

    public void DeactivateLoginPopUp()
    {
        LoginPopUp.transform.parent.gameObject.SetActive(false);
        LoginPopUp.SetActive(false);
    }

    public void DeactivateDifficultyPopUp()
    {
        difficultyPopUp.transform.parent.gameObject.SetActive(false);
        difficultyPopUp.SetActive(false);
    }

    public void ActivateLeaderboardPopUp()
    {
        leaderboardPopUp.transform.parent.gameObject.SetActive(true);
        leaderboardPopUp.SetActive(true);
        Managers.UI.activePopUp = leaderboardPopUp;
    }

    public void ActivateDifficultyPopUp()
    {
        difficultyPopUp.transform.parent.gameObject.SetActive(true);
        difficultyPopUp.SetActive(true);
        Managers.UI.activePopUp = difficultyPopUp;
    }

}
