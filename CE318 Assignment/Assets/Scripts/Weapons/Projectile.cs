using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float moveSpeed;

    private Rigidbody rb;
    private bool hit;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        // Stop bullets colliding
        if (!other.gameObject.GetComponent<Projectile>()) {
            // If other game object has a health component
            if (other.gameObject.GetComponent<Health>() && !hit) {
                Health otherHealth = other.gameObject.GetComponent<Health>();
                otherHealth.TakeDamage(damage);
                hit = true;
            }
            Destroy(gameObject);
        }
    }
}
