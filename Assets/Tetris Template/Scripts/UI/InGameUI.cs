
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class InGameUI : MonoBehaviour {

	public Text score;
    public Text highScore;
    public Text scoreLabel;
    public Text highScoreLabel;
    public Text nextLabel;
    
    public GameObject gameOverPopUp;

    public void UpdateScoreUI()
	{
        score.text = Managers.Score.currentScore.ToString();
        highScore.text = Managers.Score.highScore.ToString();
    }

    public void InGameUIStartAnimation()
    {
        scoreLabel.rectTransform.DOAnchorPosY(-334, 1, true);
        highScoreLabel.rectTransform.DOAnchorPosY(-334, 1, true);
        score.rectTransform.DOAnchorPosY(-375, 1, true);
        highScore.rectTransform.DOAnchorPosY(-375, 1, true);
        nextLabel.rectTransform.DOAnchorPosY(150, 1, true);
    }

    public void InGameUIEndAnimation()
    {
        scoreLabel.rectTransform.DOAnchorPosY(-334+650, 0.3f, true);
        highScoreLabel.rectTransform.DOAnchorPosY(-334 + 650, 0.3f, true);
        score.rectTransform.DOAnchorPosY(-375 + 650, 0.3f, true);
        highScore.rectTransform.DOAnchorPosY(-375 + 650, 0.3f, true);
    }


}
