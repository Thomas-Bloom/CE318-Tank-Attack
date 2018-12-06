using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int startHealth;
    [HideInInspector]
    public int currentHealth;
    public MeshRenderer[] meshRenderers;

    private Color originalColor;
    private float flashTime;
    public AudioSource explosionAudio;

    private void Start() {
        flashTime = 0.08f;
        originalColor = meshRenderers[0].material.color;
    }

    private void OnEnable() {
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        FlashRed();

        if(currentHealth < 0) {
            currentHealth = 0;
        }

        if(currentHealth <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        currentHealth += amount;

        if(currentHealth > startHealth) {
            currentHealth = startHealth;
        }
    }

    public void Die() {
        explosionAudio.Play();

        if (gameObject.tag.Equals("EnemyTank")) {
            GameManager.instance.enemiesLeftList.Remove(this);
        }
        if (gameObject.tag.Equals("Beacon")) {
            GameManager.instance.beaconsLeftList.Remove(this);
        }

        gameObject.SetActive(false);
    }

    private void FlashRed() {
        foreach(MeshRenderer mesh in meshRenderers) {
            mesh.material.color = Color.red;
        }

        Invoke("ResetColor", flashTime);
    }

    private void ResetColor() {
        foreach (MeshRenderer mesh in meshRenderers) {
            mesh.material.color = originalColor;
        }
    }

}
