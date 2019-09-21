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

public enum Menus
{
	MAIN,
	INGAME,
	GAMEOVER
}

public class UIManager : MonoBehaviour {

	public MainMenu mainMenu;
	public InGameUI inGameUI;
    public PopUp popUps;
    public GameObject activePopUp;
    public GameObject panel;

	public void ActivateUI(Menus menutype)
	{
		if (menutype.Equals (Menus.MAIN))
		{
            StartCoroutine(ActivateMainMenu());          
		}
		else if(menutype.Equals(Menus.INGAME))
		{
            StartCoroutine(ActivateInGameUI());
		}	
	}

    IEnumerator ActivateMainMenu()
    {
        inGameUI.InGameUIEndAnimation();
        inGameUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        mainMenu.gameObject.SetActive(true);
        mainMenu.MainMenuStartAnimation();
    }

    IEnumerator ActivateInGameUI()
    {
        mainMenu.MainMenuEndAnimation();       
        yield return new WaitForSeconds(0.3f);
        mainMenu.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        inGameUI.InGameUIStartAnimation();
    }

    void Update()
    {
        if (activePopUp != null)
            HideIfClickedOutside(activePopUp);
    }

    public void MainMenuArrange()
    {
        if (Managers.Game.isGameActive)
        {
            mainMenu.layout.spacing = 20;
            mainMenu.layout.padding.left = mainMenu.layout.padding.right = 200;
            mainMenu.restartButton.SetActive(true);
        }
        else
        {
            mainMenu.layout.spacing = 50;
            mainMenu.layout.padding.left = mainMenu.layout.padding.right = 250;
            mainMenu.restartButton.SetActive(false);
        }
    }

    private void HideIfClickedOutside(GameObject outsidePanel)
    {
        if (Input.GetMouseButton(0) && outsidePanel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                outsidePanel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            outsidePanel.SetActive(false);
            outsidePanel.transform.parent.gameObject.SetActive(false);
            Managers.UI.panel.SetActive(false);
            activePopUp = null;
        }
    }

}
