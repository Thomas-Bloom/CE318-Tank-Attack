using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool isPlayer;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    public AudioSource gunAudio;
    public GameObject shootParticle;

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
                GameObject currentParticle = Instantiate(shootParticle, bulletSpawn.position, transform.rotation);
                Destroy(currentParticle, 0.5f);
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
