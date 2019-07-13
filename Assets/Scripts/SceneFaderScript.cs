using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderScript : MonoBehaviour {
    [SerializeField] GameObject fadeCanvas;
    [SerializeField] Animator fadeAnim;
    public static SceneFaderScript instance;

    void Awake() {
        MakeSingleton();
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

    public void FadeOut() {
        StartCoroutine(FadeOutAnimation());
    }

    public void FadeIn(string levelName) {
        StartCoroutine(FadeInAnimation(levelName));
    }

    IEnumerator FadeInAnimation(string levelName) {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(levelName);
        FadeOut();
    }

    IEnumerator FadeOutAnimation() {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.7f);
        fadeCanvas.SetActive(false);
    }
}
