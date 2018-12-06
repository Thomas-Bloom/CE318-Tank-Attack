using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float chaseRadius, shootRadius, stopCloseToPlayerRadius;
    public bool shootingPlayer;

    [HideInInspector]
    public Transform target;

    private NavMeshAgent agent;

    private Weapon weapon;

    private void Start() {
        weapon = GetComponent<Weapon>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update() {
        float distanceToPlayer = Vector3.Distance(target.position, transform.position);

        // If in chase range then chase the player
        if(distanceToPlayer <= chaseRadius) {
            agent.SetDestination(target.position);

            // If in shoot radius shoot the player
            if(distanceToPlayer <= shootRadius) {
                shootingPlayer = true;
            }
            else {
                shootingPlayer = false;
            }
        }
        else if(distanceToPlayer <= stopCloseToPlayerRadius) {
            agent.isStopped = true;
        }

        else {
            shootingPlayer = false;
        }

        if (shootingPlayer) {
            weapon.ShootWeapon();

        }
    }

    /*
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
    */

}
