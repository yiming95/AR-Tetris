using UnityEngine;
using System.Collections;

public class GameOverState : _StatesBase {

	#region implemented abstract members of _StatesBase
	public override void OnActivate ()
	{
        Managers.Game.isGameActive = false;
        Managers.Game.stats.highScore = Managers.Score.currentScore;
        Managers.Game.stats.numberOfGames++;
        Managers.UI.popUps.ActivateGameOverPopUp();
        Managers.Audio.PlayLoseSound();
       
        Debug.Log ("<color=green>Game Over State</color> OnActive");	
	}

	public override void OnDeactivate ()
    {
        Managers.Adv.ShowRewardedAd();
        Debug.Log ("<color=red>Game Over State</color> OnDeactivate");
	}

	public override void OnUpdate ()
	{
		Debug.Log ("<color=yellow>Game Over State</color> OnUpdate");
	}
	#endregion

}
