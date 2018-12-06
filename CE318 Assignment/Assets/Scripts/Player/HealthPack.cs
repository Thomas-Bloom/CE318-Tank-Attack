using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    public int healthAmount;
    public AudioSource healthPackAudio;

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            healthPackAudio.Play();
            other.GetComponent<Health>().Heal(healthAmount);
            gameObject.SetActive(false);
        }
    }
}
