using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    public UIManager uiManager;
    public HUDManager HUDManager;

    public Animator pauseMenuAnim;

	public void ResumeGame() {
        uiManager.paused = false;
        HUDManager.EnableHUD();
        Time.timeScale = 1f;
        pauseMenuAnim.SetBool("Paused", false);
    }

    public void ShowSettings() {
        pauseMenuAnim.SetBool("Settings", true);

    }

    public void QuitToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame() {
        uiManager.paused = true;
        HUDManager.DisableHUD();
        Time.timeScale = 0f;
        pauseMenuAnim.SetBool("Paused", true);
    }

    public void BackButton() {
        pauseMenuAnim.SetBool("Settings", false);

    }

    public void SaveButton() {
        SaveLoadManager.saveLoad.SaveLevelNum();
    }
}
