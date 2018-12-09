using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    public Weapon playerWeapon;


    private Rigidbody rb;
    private float movementInput;
    private float turnInput;

    // Powerup...
    public float baseMoveSpeed;
    public float baseFireRate;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        baseMoveSpeed = moveSpeed;
        baseFireRate = playerWeapon.fireRate;

    }

    private void OnEnable() {
        rb.isKinematic = false;
        movementInput = 0;
        turnInput = 0;
    }

    private void OnDisable() {
        rb.isKinematic = true;
    }

    private void Update() {
        movementInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        Move();
        Turn();
    }

    private void Move() {
        Vector3 movement = transform.forward * movementInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn() {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRot = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRot);
    }

    public void ActivateBoost(float amount) {
        moveSpeed += amount;
    }

    public void DeactivateBoost() {
        moveSpeed = baseMoveSpeed;
    }

    public void ActivateRapidFire(float amount) {
        playerWeapon.fireRate = amount;
    }

    public void DeactivateRapidFire() {
        playerWeapon.fireRate = baseFireRate;
    }
}
