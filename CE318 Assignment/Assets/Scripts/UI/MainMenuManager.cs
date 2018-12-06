using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour {
    public Animator animator;
    private Fader fader;

    private void Start() {
        fader = GetComponent<Fader>();
    }

    // Shows the tutorial question
    public void NewGameAction() {
        animator.SetBool("NewGameMenu", true);
    }

    public void LoadTutorial() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadFirstLevel() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadGameAction() {
        // This will be changed to the index of the current level
        StartCoroutine(LoadLevel(1));
    }

    private IEnumerator LoadLevel(int levelIndex) {
        float fadeTime = fader.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void OpenSettingsAction() {
        animator.SetBool("SettingsMenu", true);
    }

    public void BackToMainAction() {
        animator.SetBool("SettingsMenu", false);
        animator.SetBool("NewGameMenu", false);

    }

    public void QuitGameAction() {
        Application.Quit();
    }
}
