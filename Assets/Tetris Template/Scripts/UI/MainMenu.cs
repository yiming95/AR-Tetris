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
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Text tetrisLogoText;
    public GameObject menuButtons;
    public GameObject restartButton;

    public HorizontalLayoutGroup layout;

    void Awake()
    {
        layout = GetComponent<HorizontalLayoutGroup>();
    }

    void OnEnable()
	{
        tetrisLogoText.enabled = true;
        menuButtons.SetActive (true);   
    }

	void OnDisable()
	{
		tetrisLogoText.enabled = false;
		menuButtons.SetActive (false); 
    }

    public void DisableMenuButtons ()
	{
		menuButtons.SetActive (false);
	}

    public void MainMenuStartAnimation()
    {
        menuButtons.GetComponent<RectTransform>().DOAnchorPosY(-850, 1, true);
        tetrisLogoText.GetComponent<RectTransform>().DOAnchorPosY(600, 1, true);
    }

    public void MainMenuEndAnimation()
    {
        menuButtons.GetComponent<RectTransform>().DOAnchorPosY(-1450, 0.3f, true);
        tetrisLogoText.GetComponent<RectTransform>().DOAnchorPosY(1200, 0.3f, true);
    }


}

