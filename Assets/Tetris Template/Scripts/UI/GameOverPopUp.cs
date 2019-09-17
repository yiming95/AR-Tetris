//  /*********************************************************************************
//   *********************************************************************************
//   *********************************************************************************
//   * Produced by Skard Games										                 *
//   * Facebook: https://goo.gl/5YSrKw											     *
//   * Contact me: https://goo.gl/y5awt4								             *
//   * Developed by Cavit Baturalp Gürdin: https://tr.linkedin.com/in/baturalpgurdin *
//   *********************************************************************************
//   *********************************************************************************
//   *********************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameOverPopUp : MonoBehaviour {

    public Text gameOverScore;
    
    void OnEnable()
    {
        gameOverScore.text = Managers.Score.currentScore.ToString();
        Managers.UI.panel.SetActive(true);
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
