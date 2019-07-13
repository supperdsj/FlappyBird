using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerScript : MonoBehaviour {
    public static MenuControllerScript instance;
    [SerializeField] GameObject[] birds;
    bool isGreenBirdUnlocked, isRedBirdUnlocked;

    void Awake() {
        MakeSingleton();
    }

    void Start() {
        birds[GameControllerScript.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();
    }

    public void PlayGame() {
        SceneFaderScript.instance.FadeIn("Gameplay");
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

    void CheckIfBirdsAreUnlocked() {
        isRedBirdUnlocked = GameControllerScript.instance.IsRedBirdUnlocked() == 1;
        isGreenBirdUnlocked = GameControllerScript.instance.IsGreenBirdUnlocked() == 1;
    }

    public void ChangeBird() {
        switch (GameControllerScript.instance.GetSelectedBird()) {
            case 0:
                if (isGreenBirdUnlocked) {
                    birds[GameControllerScript.instance.GetSelectedBird()].SetActive(false);
                    GameControllerScript.instance.SetSelectedBird(1);
                }

                break;
            case 1:
                if (isRedBirdUnlocked) {
                    birds[GameControllerScript.instance.GetSelectedBird()].SetActive(false);
                    GameControllerScript.instance.SetSelectedBird(2);
                }
                else {
                    birds[GameControllerScript.instance.GetSelectedBird()].SetActive(false);
                    GameControllerScript.instance.SetSelectedBird(0);
                }

                break;
            default:
                birds[GameControllerScript.instance.GetSelectedBird()].SetActive(false);
                GameControllerScript.instance.SetSelectedBird(0);
                break;
        }

        birds[GameControllerScript.instance.GetSelectedBird()].SetActive(true);
    }
}
