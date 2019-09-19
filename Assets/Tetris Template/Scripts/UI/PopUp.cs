
using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour
{
    public GameObject gameOverPopUp;
    public GameObject settingsPopUp;
    public GameObject playerStatsPopUp;
    public GameObject leaderboardPopUp;
    public GameObject difficultyPopUp;

    public void ActivateGameOverPopUp()
    {
        difficultyPopUp.SetActive(false);
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
