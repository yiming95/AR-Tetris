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
using System;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class AnalyticsManager : MonoBehaviour {

	/// <summary>
	/// Custom Events
	/// </summary>
	public void SendScoreAnalytic()
	{
//		Analytics.CustomEvent("Score", new Dictionary<string, object>
//			{
//				{ "playerScore", Managers.Score.currentScore}
//			});
	}

	/// <summary>
	/// Sets the user birth year.
	/// </summary>
	/// <param name="birthYear">Birth year.</param>
	public void SendUserAgeAnalytic(int birthYear)
	{
		Analytics.SetUserBirthYear(birthYear);
	}

	/// <summary>
	/// Gender the specified gender.
	/// </summary>
	/// <param name="gender">Gender.</param>
	public void SendGenderAnalytic(Gender gender)
	{
		Analytics.SetUserGender(gender);
	}

	/// <summary>
	/// Users the I.
	/// </summary>
	/// <param name="id">İdentifier.</param>
	public void SendUserIDAnalytic(string id)
	{
		Analytics.SetUserId(id);
	}

	/// <summary>
	/// Transaction the specified productId, amount, currency, receiptPurchaseData and signature.
	/// </summary>
	/// <param name="productId">Product ıd.</param>
	/// <param name="amount">Amount.</param>
	/// <param name="currency">Currency.</param>
	/// <param name="receiptPurchaseData">Receipt purchase data.</param>
	/// <param name="signature">Signature.</param>
	public void SendTransactionAnalytic(string productId, Decimal amount, string currency, string receiptPurchaseData, string signature)
	{
		Analytics.Transaction(productId, amount, currency, receiptPurchaseData, signature); 
	}

}
