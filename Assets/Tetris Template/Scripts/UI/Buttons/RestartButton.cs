
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

    public void OnClickARRestartButton()
    {
        //GameManager.difficulty = GameManager.difficultyTemp;
        //Managers.Audio.PlayUIClick();
        //GameObject.Find("Grid");
        //Managers.Score.ResetCurrentScore();
        //Destroy(SpawnManager.next);
        //SpawnManager.isFirst = true;
        //Managers.Game.isGameActive = false;
        //Managers.Game.SetState(typeof(GamePlayState));
        //Managers.UI.inGameUI.gameOverPopUp.SetActive(false);


        //GameManager.difficulty = GameManager.difficultyTemp;
        Managers.Audio.PlayUIClick();
        Managers.Grid.ClearBoard();
        Managers.Score.ResetCurrentScore();
        Destroy(SpawnManager.next);
        SpawnManager.isFirst = true;
        Managers.Game.isGameActive = false;
        Managers.Game.SetState(typeof(GamePlayState));
        Managers.UI.inGameUI.gameOverPopUp.SetActive(false);
    }

>>>>>>> 223776d31154ec5965166130610600a68d2721ce
}
