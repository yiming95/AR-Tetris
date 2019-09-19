
using UnityEngine;
using System.Collections;

public class GameBackButton : MonoBehaviour {

	public void OnClickBackButton()
	{
        Managers.Audio.PlayUIClick();
        Managers.Game.SetState(typeof(MenuState));
    }
}
