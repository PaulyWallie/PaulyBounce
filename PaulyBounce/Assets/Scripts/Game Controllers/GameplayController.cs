using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public GameObject pausePanel;

	public Button restartGameButton;

	public Text scoreText, pauseText;

	int score;

	void Awake () {
		
	}
	void Start () {
		StartCoroutine (CountScore());
	}

	IEnumerator CountScore() {
		yield return new WaitForSeconds(0.6f);
		scoreText.text = score + "Meters";
		StartCoroutine (CountScore());
	}
		

	void OnEnable(){
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable(){
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}


	void PlayerDiedEndTheGame() {
		if (!PlayerPrefs.HasKey ("Score")){
			PlayerPrefs.SetInt("Score", 0);
		} else {
			int highscore = PlayerPrefs.GetInt("score");

			if(highscore < score) {
				PlayerPrefs.SetInt("Score", score);
			}
		}

		pauseText.text = "Game Over";
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners();
		restartGameButton.onClick.AddListener(() => RestartGame());
		Time.timeScale = 0f;
	}

	public void PauseButton() {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners();
		restartGameButton.onClick.AddListener(() => RestartGame());
	}

	public void GoToMenu() {
		Time.timeScale = 1f;
		Application.LoadLevel("MainMneu");
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}
}