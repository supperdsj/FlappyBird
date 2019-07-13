using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayControllerScript : MonoBehaviour {
    public static GameplayControllerScript instance;

    [SerializeField] Text scoreText, endScore, bestScore, gameoverText;
    [SerializeField] Button restartGameButton, instructionsButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject[] birds;
    [SerializeField] Sprite[] medals;
    [SerializeField] Image medalImage;

    void Awake() {
        MakeSingleton();
        // Time.timeScale = 0;
    }

    void MakeSingleton() {
        // if (instance != null) {
        //     Destroy(this);
        // }
        // else {
            instance = this;
            // DontDestroyOnLoad(this);
        // }
    }

    public void PauseGameButton() {
        if (BirdScript.instance != null) {
            if (BirdScript.instance.isAlive) {
                pausePanel.SetActive(true);
                gameoverText.gameObject.SetActive(false);
                endScore.text = "" + BirdScript.instance.score;
                bestScore.text = "" + GameControllerScript.instance.GetHighscore();
                Time.timeScale = 0;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener(() => ResumeGameButton());
                endScore.gameObject.SetActive(false);
            }
        }
    }

    public void GoToMenuButton() {
        SceneFaderScript.instance.FadeIn("MainMenu");
    }

    public void ResumeGameButton() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGameButton() {
        SceneFaderScript.instance.FadeIn("Gameplay");
    }

    public void PlayGameButton() {
        print(GameControllerScript.instance.GetSelectedBird());
        birds[GameControllerScript.instance.GetSelectedBird()].SetActive(true);
        instructionsButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetScore(int score) {
        scoreText.text = "" + score;
    }

    public void PlayerDIedShowScore(int score) {
        pausePanel.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScore.gameObject.SetActive(true);
        endScore.text = "" + score;
        if (score > GameControllerScript.instance.GetHighscore()) {
            GameControllerScript.instance.SetHighscore(score);
        }

        bestScore.text = "" + GameControllerScript.instance.GetHighscore();
        if (score <= 20) {
            medalImage.sprite = medals[0];
        }
        else if (score <= 40) {
            medalImage.sprite = medals[1];
            if (GameControllerScript.instance.IsGreenBirdUnlocked() == 0) {
                GameControllerScript.instance.UnlockGreenBird();
            }
        }
        else {
            medalImage.sprite = medals[2];
            if (GameControllerScript.instance.IsGreenBirdUnlocked() == 0) {
                GameControllerScript.instance.UnlockGreenBird();
            }
            if (GameControllerScript.instance.IsRedBirdUnlocked() == 0) {
                GameControllerScript.instance.UnlockRedBird();
            }
        }
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(()=>RestartGameButton());
    }
}
