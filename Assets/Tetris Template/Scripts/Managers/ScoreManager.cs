//  /*********************************************************************************
//   *********************************************************************************
//   *********************************************************************************
//   * Produced by Skard Games										                  *
//   * Facebook: https://goo.gl/5YSrKw											      *
//   * Contact me: https://goo.gl/y5awt4								              *											
//   * Developed by Cavit Baturalp Gürdin: https://tr.linkedin.com/in/baturalpgurdin *
//   *********************************************************************************
//   *********************************************************************************
//   *********************************************************************************/

using UnityEngine;
using System.Collections;



public class ScoreManager : MonoBehaviour {

	public int currentScore=0;
	public int highScore;

    void Awake()
    {
        if (Managers.Game.stats.highScore != 0)
        {
            highScore = Managers.Game.stats.highScore;
            Managers.UI.inGameUI.UpdateScoreUI();
        }
        else
        {
            highScore = 0;
            Managers.UI.inGameUI.UpdateScoreUI();
        }
    }

	public void OnScore(int scoreIncreaseAmount)
	{	
		currentScore += scoreIncreaseAmount;
        CheckHighScore();
        Managers.UI.inGameUI.UpdateScoreUI();
        Managers.Game.stats.totalScore += scoreIncreaseAmount;
    }

    public void CheckHighScore()
    {
        if (highScore < currentScore)
        {
            highScore = currentScore;
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        highScore = Managers.Game.stats.highScore;
        Managers.UI.inGameUI.UpdateScoreUI();
    }

}
