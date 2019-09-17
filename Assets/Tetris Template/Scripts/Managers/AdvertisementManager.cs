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
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
using System.Collections;

public class AdvertisementManager : MonoBehaviour
{
	public void ShowDefaultAd()
	{
		#if UNITY_ADS
		if (!Advertisement.IsReady())
		{
			Debug.Log("Ads not ready for default zone");
			return;
		}

		Advertisement.Show();
		#endif
	}

	public void ShowRewardedAd()
    {
        const string RewardedZoneId = "rewardedVideo";
        #if UNITY_ADS
        if (!Advertisement.IsReady(RewardedZoneId))
		{
			Debug.Log(string.Format("Ads not ready for zone '{0}'", RewardedZoneId));
			return;
		}

		var options = new ShowOptions { resultCallback = HandleShowResult };
		Advertisement.Show(RewardedZoneId, options);
		#endif
	}

	#if UNITY_ADS
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
	#endif
}