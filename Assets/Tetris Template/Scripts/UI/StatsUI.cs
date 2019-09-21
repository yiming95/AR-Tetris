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
using System.Collections;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    public Text highScore;
    public Text totalScore;
    public Text timeSpent;
    public Text numberOfGames;

    public void ClearStats()
    {
        Managers.Game.stats.ClearStats();
        RefreshText();
    }

    void OnEnable()
    {
        RefreshText();
    }

    void RefreshText()
    {
        highScore.text = Managers.Game.stats.highScore.ToString();
        totalScore.text = Managers.Game.stats.totalScore.ToString();
        timeSpent.text = TimeUtil.SecondsToHMS(Managers.Game.stats.timeSpent);
        numberOfGames.text = Managers.Game.stats.numberOfGames.ToString();
    }

}
