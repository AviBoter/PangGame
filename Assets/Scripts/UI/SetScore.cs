using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour 
{
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;

	void Start () 
	{
		scoreLabel.text = "Score: " + GameManagerRelated.GameManager.score.ToString();

		if (GameManagerRelated.GameManager.score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManagerRelated.GameManager.score)
			{
				PlayerPrefs.SetInt("Score", GameManagerRelated.GameManager.score);
				PlayerPrefs.Save();
			}
		}

		bestScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManagerRelated.GameManager.score = 0;
	}
}