using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateIncreaser : Powerup {

    public float newFireRate = 0.001f;
    public AudioSource pickupAudio;
    private GameObject powerupLight;

    protected override void Start() {
        powerupLight = transform.GetChild(0).gameObject;
        base.Start();
    }

    protected override void AffectPlayer() {
        base.AffectPlayer();
        powerupLight.SetActive(false);
        player.ActivateRapidFire(newFireRate);
        pickupAudio.Play();
    }

    protected override void Expired() {
        player.DeactivateRapidFire();
        base.Expired();
    }
}
