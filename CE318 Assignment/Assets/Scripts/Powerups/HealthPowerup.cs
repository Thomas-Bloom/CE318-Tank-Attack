using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : Powerup {
    public int healthToAdd = 20;
    public AudioSource pickupAudio;
    private GameObject powerupLight;

    protected override void Start() {
        powerupLight = transform.GetChild(0).gameObject;
        base.Start();
    }

    protected override void AffectPlayer() {
        base.AffectPlayer();
        powerupLight.SetActive(false);
        player.GetComponent<Health>().Heal(healthToAdd);
        pickupAudio.Play();
    }
}
