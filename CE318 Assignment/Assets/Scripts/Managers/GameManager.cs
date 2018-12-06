using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager instance;

    private void Awake() {
        instance = this;
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

    private void Start() {
        noDamageTaken = true;

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyTank")) {

            enemiesLeftList.Add(enemy.GetComponent<Health>());
        }
        foreach (GameObject beacon in GameObject.FindGameObjectsWithTag("Beacon")) {

            beaconsLeftList.Add(beacon.GetComponent<Health>());
        }

        camStartTimer = camStartAnimTimer;
        player.enabled = false;
    }

    private void Update() {
        // Freeze game for certain amount of time (while camera animation plays)
        camStartTimer -= Time.deltaTime;

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
