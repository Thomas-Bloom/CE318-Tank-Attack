using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

    public GameObject healthHUD;
    public GameObject beaconsLeftHUD;
    public GameObject enemiesLeftHUD;

    public void DisableHUD() {
        healthHUD.gameObject.SetActive(false);
        beaconsLeftHUD.gameObject.SetActive(false);
        enemiesLeftHUD.gameObject.SetActive(false);
    }

    public void EnableHUD() {
        healthHUD.gameObject.SetActive(true);
        beaconsLeftHUD.gameObject.SetActive(true);
        enemiesLeftHUD.gameObject.SetActive(true);
    }
}
