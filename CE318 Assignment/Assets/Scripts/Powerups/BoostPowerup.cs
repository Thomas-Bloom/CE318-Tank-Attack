using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : Powerup {
    public int boostAmount = 20;
    public AudioSource pickupAudio;
    private GameObject powerupLight;

    protected override void Start() {
        powerupLight = transform.GetChild(0).gameObject;
        base.Start();
    }

    protected override void AffectPlayer() {
        base.AffectPlayer();
        powerupLight.SetActive(false);
        player.ActivateBoost(boostAmount);
        pickupAudio.Play();
    }

    protected override void Expired() {
        player.DeactivateBoost();
        base.Expired();
    }
}
