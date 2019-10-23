
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
    public void OnClickARRestartButton()
    {
        GameManager.difficulty = GameManager.difficultyTemp;
        Managers.Audio.PlayUIClick();
        GameObject.Find("Grid");
=======
    public void AROnClickRestartButton()
    {
        //GameManager.difficulty = GameManager.difficultyTemp;
        Managers.Audio.PlayUIClick();
        Managers.Grid.ClearBoard();
>>>>>>> e9b5278c3f8e44598af73fca4aec9a6938381080
        Managers.Score.ResetCurrentScore();
        Destroy(SpawnManager.next);
        SpawnManager.isFirst = true;
        Managers.Game.isGameActive = false;
        Managers.Game.SetState(typeof(GamePlayState));
        Managers.UI.inGameUI.gameOverPopUp.SetActive(false);
    }
<<<<<<< HEAD

=======
>>>>>>> e9b5278c3f8e44598af73fca4aec9a6938381080
}
