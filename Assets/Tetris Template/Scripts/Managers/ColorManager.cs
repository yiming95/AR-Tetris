using UnityEngine;
using System.Collections;

public enum ColorTheme
{
	PASTEL,
    GRAM
}

public class ColorManager : MonoBehaviour {

	public ColorTheme activeTheme;

    public Color[] themePack_Pastel;
    public Color[] themePack_Gram;	

	public Color TurnRandomColorFromTheme()
	{
		int rand = Random.Range(0,6); 
		Color temp; 
		switch (activeTheme)
		{
			case ColorTheme.PASTEL:
				temp = themePack_Pastel[rand];
				break;
            case ColorTheme.GRAM:
                temp = themePack_Gram[rand];
                break;
            default:
				temp = Color.black;
				break;
		}

		return temp;
	}

}
