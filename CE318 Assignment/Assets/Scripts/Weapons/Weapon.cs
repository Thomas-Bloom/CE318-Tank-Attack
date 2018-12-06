using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool isPlayer;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    public AudioSource gunAudio;

    private float nextFire;

    private void Update() {
        if(isPlayer)
            ShootWeapon();
    }

    public void ShootWeapon() {
        if (isPlayer) {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire && Time.timeScale == 1f) {
                gunAudio.Play();
                nextFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawn.position, transform.rotation);
            }
        }
        else {
            if(Time.time > nextFire) {
                gunAudio.Play();
                nextFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawn.position, transform.rotation);
            }
        }
    }
}
