
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameOverPopUp : MonoBehaviour {

    public Text gameOverScore;
    
    void OnEnable()
    {
        GameManager.difficultyTemp = GameManager.difficulty;
        gameOverScore.text = Managers.Score.currentScore.ToString();
        Managers.Score.ResetCurrentScore();
        Managers.UI.panel.SetActive(true);
        GameManager.difficulty = 0;
        
    }

    public void BackToMainMenu()
    {
        Managers.Grid.ClearBoard();
        Managers.Audio.PlayUIClick();
        Managers.UI.panel.SetActive(false);
        Managers.Game.SetState(typeof(MenuState));
        gameObject.SetActive(false);
    }
}
