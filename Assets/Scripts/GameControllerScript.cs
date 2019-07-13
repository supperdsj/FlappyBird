using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {
    public static GameControllerScript instance;
    const string HIGH_SCORE = "High Score";
    const string SELECTED_BIRD = "Selected Bird";
    const string GREEN_BIRD = "Green Bird";
    const string RED_BIRD = "Red Bird";

    void Awake() {
        MakeSingleton();
        IsTheGameStartedForTheFirstTime();
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void IsTheGameStartedForTheFirstTime() {
        if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime")) {
            PlayerPrefs.SetInt(HIGH_SCORE,0);
            PlayerPrefs.SetInt(SELECTED_BIRD,0);
            PlayerPrefs.SetInt(GREEN_BIRD,1);
            PlayerPrefs.SetInt(RED_BIRD,0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 1);
        }
    }

    public void SetHighscore(int score) {
        PlayerPrefs.SetInt(HIGH_SCORE,score);
    }

    public int GetHighscore() {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
    public void SetSelectedBird(int selectedBird) {
        PlayerPrefs.SetInt (SELECTED_BIRD, selectedBird);
    }

    public int GetSelectedBird() {
        return PlayerPrefs.GetInt (SELECTED_BIRD);
    }

    public void UnlockGreenBird() {
        PlayerPrefs.SetInt (GREEN_BIRD, 1);
    }

    public int IsGreenBirdUnlocked() {
        return PlayerPrefs.GetInt(GREEN_BIRD);
    }

    public void UnlockRedBird() {
        PlayerPrefs.SetInt (RED_BIRD, 1);
    }

    public int IsRedBirdUnlocked() {
        return PlayerPrefs.GetInt(RED_BIRD);
    }
}
