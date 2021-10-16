using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

namespace GameManagerRelated { 

	public enum CurrentState
	{
		HomeUI,
		InGameUI,
		EndGameUI,
		GameOverUI,
		TutorialUI,
		Celebrate,
		Paused
	}
	public class GameManager : MonoBehaviour
	{
		private PoolClass pool;
		public GameObject[] objects;
		private float lastCreated;
		public TextMesh lostFoodLabel;
		private int lostFood;
		public TextMesh scoreLabel;
		public static int score;
		public static event Action<CurrentState> OnGameStateChange;
		private float speed;
		private CurrentState gameState;

		public CurrentState GetState()
        {
			return gameState;
        }

		public int Score
		{
			set
			{
				score = value;
				scoreLabel.text = Score.ToString();
			}
			get
			{
				return score;
			}
		}

        [Obsolete]
        public int LostFood
		{
			set
			{
				lostFood = value;
				lostFoodLabel.text = lostFood.ToString();

				if (LostFood >= 4)
					UpdateGameState(CurrentState.EndGameUI);
			}
			get
			{
				return lostFood;
			}
		}

        [Obsolete]
        void Start()
		{
			pool = GetComponentInChildren<PoolClass>();
			UpdateGameState(CurrentState.InGameUI);

			score = 0;
			lastCreated = 0;
			lastCreated = Time.time;
			speed = 2.5f;
			
			PlayerPrefs.SetInt("Win", 0);
		

			//Debug.Log("GM Level " + PlayerPrefs.GetInt("Level"));
		}

		//State machine to control UI
        [Obsolete]
        public void UpdateGameState(CurrentState state)
		{
			gameState = state;

			switch (gameState)
			{
				case CurrentState.HomeUI:

					break;

				case CurrentState.InGameUI:

					break;

				case CurrentState.EndGameUI:
					PlayerPrefs.SetInt("Win", 2);
					Application.LoadLevel(Consts.MainMenu);
					break;

				case CurrentState.Celebrate:
					PlayerPrefs.SetInt(Consts.Win, 1);
					PlayerPrefs.SetInt(Consts.Level, PlayerPrefs.GetInt(Consts.Level)+1);
				//	pool.ResetToEditorDefaultsRequest();
					Application.LoadLevel(Consts.MainMenu);
					break;
			}
			OnGameStateChange?.Invoke(gameState);
		}
	}
}
