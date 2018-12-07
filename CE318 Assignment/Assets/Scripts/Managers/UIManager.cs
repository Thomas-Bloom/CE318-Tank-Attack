using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {
    #region Singleton
    public static UIManager instance;

    private void Awake() {
        instance = this;
    }

    [HideInInspector]
    public UIManager uiManager;
    #endregion

    public GameManager gameManager;
    public Text playerHealthText;
    public TextMeshProUGUI enemiesLeft;
    public TextMeshProUGUI beaconsLeftText;
    public GameObject youWinPanel;
    public GameObject allEnemiesDestroyedText;
    public GameObject noDamageTakenText;
    public GameObject pausePanel;
    public HUDManager HUDManager;
    public PauseMenuManager pauseMenuManager;

    public Health player;

    public bool paused;

    private void Start() {
        Time.timeScale = 1f;
        youWinPanel.SetActive(false);
        allEnemiesDestroyedText.SetActive(false);
        noDamageTakenText.SetActive(false);
    }

    private void Update() {
        playerHealthText.text = "Player Health: " + player.currentHealth;
        enemiesLeft.text = gameManager.enemiesLeftList.Count.ToString();
        beaconsLeftText.text = gameManager.beaconsLeftList.Count.ToString();

        if (gameManager.levelWon) {
            youWinPanel.SetActive(true);

            if(gameManager.enemiesLeftList.Count == 0) {
                allEnemiesDestroyedText.SetActive(true);
            }

            if (gameManager.noDamageTaken) {
                noDamageTakenText.SetActive(true);
            }
        }

        if (Input.GetButtonDown("Pause")) {
            if (paused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Resume() {
        HUDManager.EnableHUD();
        Time.timeScale = 1f;
        pauseMenuManager.ResumeGame();
        paused = false;
    }

    private void Pause() {
        HUDManager.DisableHUD();
        Time.timeScale = 0f;
        pauseMenuManager.PauseGame();
        paused = true;
    }


}
