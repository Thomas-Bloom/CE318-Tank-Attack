using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public string name;
    public bool noDuration;
    public float powerupTimer;

    protected MeshRenderer renderer;
    protected PlayerController player;

    private float timeLeft;
    private bool collected;

    protected enum State {
        Stationary,
        Collected,
        Expiring
    }

    protected State state;

    protected virtual void Awake() {
        renderer = GetComponent<MeshRenderer>();
    }

    protected virtual void Start() {
        state = State.Stationary;
        timeLeft = powerupTimer;
    }

    protected virtual void Update() {
        if (collected) {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0) {
                Expired();
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            print("Collided with player");
            player = other.GetComponent<PlayerController>();
            Collected();
        }
    }

    protected virtual void Collected() {
        if(state == State.Collected || state == State.Expiring) {
            return;
        }

        AffectPlayer();
        state = State.Collected;
        collected = true;
    }

    protected virtual void AffectPlayer() {
        print("Collected: " + name);
        DisableWhenCollected();


        if (noDuration) {
            Expired();
        }
    }

    protected virtual void Expired() {
        if(state == State.Expiring) {
            return;
        }
        state = State.Expiring;

        print(name + " has expired");
    }

    protected virtual void DisableWhenCollected() {
        renderer.enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
}
