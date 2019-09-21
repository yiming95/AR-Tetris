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
using System.Collections.Generic;

public class CameraShake : MonoBehaviour{

	private Vector3 originPosition;
	private Quaternion originRotation;

	public float shakeDecay = 0.002f;
	public float shakeIntensity;
	private float _initShakeIntensity;
	private System.Random Random = new System.Random();

	void Awake()
	{
		_initShakeIntensity = shakeIntensity;
	}

	public IEnumerator Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;

		while (shakeIntensity > 0) {
			transform.position = originPosition +  UnityEngine.Random.insideUnitSphere * shakeIntensity;
			transform.rotation = new Quaternion (
				originRotation.x + RandomRange (-shakeIntensity, shakeIntensity) * .2f,
				originRotation.y + RandomRange (-shakeIntensity, shakeIntensity) * .2f,
				originRotation.z + RandomRange (-shakeIntensity, shakeIntensity) * .2f,
				originRotation.w + RandomRange (-shakeIntensity, shakeIntensity) * .2f);
			shakeIntensity -= shakeDecay;
			yield return false;
		}
		shakeIntensity = _initShakeIntensity;
		yield break;
	}

	public float RandomRange(float min, float max)
	{
		return min + ((float)Random.NextDouble() * (max - min));
	}

	public int RandomRange(int min, int max)
	{
		return Random.Next(min, max);
	}
}