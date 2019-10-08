
using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

    public void OnClickPlayButton()
    {
        Managers.Audio.PlayUIClick();

        if (Managers.Game.username == "")
        {
            Managers.UI.popUps.ActivateLoginPopUp();
            Managers.UI.panel.SetActive(true);
        }
        else
        {

            if (Managers.Game.blockHolder.childCount == 0)
            {
                Managers.UI.popUps.ActivateDifficultyPopUp();
                Managers.UI.panel.SetActive(true);
            }
            else
            {
                Managers.Game.SetState(typeof(GamePlayState));
            }
        }
    }

    public void OnClickContinueButton()
    {
        Managers.Audio.PlayUIClick();
        Managers.Game.SetState(typeof(GamePlayState));
        SpawnManager.next.SetActive(true);
    }

    public void OnClickContinueHardButton()
    {
        Managers.Audio.PlayUIClick();
        GameManager.difficulty = 1;
        Managers.Game.SetState(typeof(GamePlayState));
        SpawnManager.next.SetActive(true);
    }
}
