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
using DG.Tweening;

public class CameraManager : MonoBehaviour {

	public Camera main;

    private float _mainMenuSize = 13.5f;
    private float _inGameSize = 11f;

    [HideInInspector]
	public CameraShake shaker;

	void Awake()
	{
		shaker = main.gameObject.GetComponent<CameraShake> ();
	}

    public void ZoomIn()
    {
        if (main.orthographicSize != _inGameSize)
        {
            main.DOOrthoSize(_inGameSize, 1f).SetEase(Ease.OutCubic).OnComplete(() =>
             {
                 StartCoroutine(StartGamePlay());
             });
        }
        else
        {
            Managers.Spawner.Spawn();
            Managers.Game.isGameActive = true;
        }
    }

    public void ZoomOut()
    {
        if (main.orthographicSize != _mainMenuSize)
            main.DOOrthoSize(_mainMenuSize, 1f).SetEase(Ease.OutCubic); ;
    }

    IEnumerator StartGamePlay()
    {
        yield return new WaitForEndOfFrame();

        if (!Managers.Game.isGameActive)
        {
            Managers.Spawner.Spawn();
            Managers.Game.isGameActive = true;
        }
        yield break;
    }



}
