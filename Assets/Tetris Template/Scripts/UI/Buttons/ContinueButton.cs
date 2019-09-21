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

public class ContinueButton : MonoBehaviour {


    public ARController AR;
    public void OnClickContinueButton()
    {
        if (AR.ARObject != null)
        {
            Managers.Audio.PlayUIClick();
            Managers.Game.SetState(typeof(GamePlayState));
        }
        else
        {
            AR.OnClick_PlaceObject();
        }
    }
}
