using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour {

    public EnemyController controller;
    public float turnSpeed;

    private void Update() {
        if (controller.shootingPlayer) {
            Quaternion targetRot = Quaternion.LookRotation(controller.target.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }
}
