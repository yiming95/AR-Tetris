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
using System.Collections.Generic;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class PlayerStats: ScriptableObject
{
    public int highScore = 0;
    public int totalScore = 0;
    public float timeSpent = 0;
    public int numberOfGames = 0;

    public void ClearStats()
    {
        highScore = 0;
        totalScore = 0;
        timeSpent = 0f;
        numberOfGames = 0;
    }

    #if UNITY_EDITOR
    [MenuItem("Assets/Create/PlayerStatistics")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<PlayerStats> ();
	}
	#endif

}
