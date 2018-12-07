using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager instance;

    private void Awake() {
        instance = this;
        camStartTimer = camStartAnimTimer;
    }

    [HideInInspector]
    public GameManager gameManager;
    #endregion

    public bool levelWon;
    public bool noDamageTaken;
    public Health playerHealth;
    public List<Health> enemiesLeftList;
    public List<Health> beaconsLeftList;
    public float camStartAnimTimer;
    public PlayerController player;

    private float camStartTimer;
    private SaveLoadManager saveLoad;


    private void Start() {
        saveLoad = FindObjectOfType<SaveLoadManager>();

        //print(saveLoad.difficultyNum);

        noDamageTaken = true;

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyTank")) {

            enemiesLeftList.Add(enemy.GetComponent<Health>());

            Health enemyHealth = enemy.GetComponent<Health>();

            // Easy
            if(saveLoad.difficultyNum == 0) {
                playerHealth.startHealth = 100;
                enemyHealth.startHealth = 10;
            }
            // Normal
            else if (saveLoad.difficultyNum == 1) {
                playerHealth.startHealth = 80;
                enemyHealth.startHealth = 20;
            }

            // Hard
            else if (saveLoad.difficultyNum == 2) {
                playerHealth.startHealth = 50;
                enemyHealth.startHealth = 30;
            }

            else {

            }
        }
        foreach (GameObject beacon in GameObject.FindGameObjectsWithTag("Beacon")) {

            beaconsLeftList.Add(beacon.GetComponent<Health>());
        }

        player.enabled = false;
    }

    private void Update() {
        // Freeze game for certain amount of time (while camera animation plays)

        if(camStartTimer >= 0) {
            camStartTimer -= Time.time;
        }

        if (camStartTimer < 0) {
            player.enabled = true;
        }

        if (beaconsLeftList.Count <= 0) {
            levelWon = true;
            Time.timeScale = 0f;
        }

        if(playerHealth.currentHealth < playerHealth.startHealth) {
            noDamageTaken = false;
        }
    }
}
