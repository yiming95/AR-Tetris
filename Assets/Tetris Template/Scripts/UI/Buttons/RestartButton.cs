
using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

    public void OnClickRestartButton()
    {
        GameManager.difficulty = GameManager.difficultyTemp;
        Managers.Audio.PlayUIClick();
        Managers.Grid.ClearBoard();
        Managers.Score.ResetCurrentScore();
        Destroy(SpawnManager.next);
        SpawnManager.isFirst = true;
        Managers.Game.isGameActive = false;
        Managers.Game.SetState(typeof(GamePlayState));
        Managers.UI.inGameUI.gameOverPopUp.SetActive(false);
    }
<<<<<<< HEAD
=======

>>>>>>> c21ae3f774cb9119bed1eeefebcd7a6dd3bdf437
}
