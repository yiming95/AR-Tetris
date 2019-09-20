
using UnityEngine;
using System.Collections;

public class AdButtons : MonoBehaviour {

	public void OnClickRewarded()
	{
		Managers.Adv.ShowRewardedAd ();
	}

	public void OnClickDefault()
	{
		Managers.Adv.ShowDefaultAd ();
	}

}
