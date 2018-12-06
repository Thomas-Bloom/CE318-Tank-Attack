using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    public float timeToDestroy;

    private void Update() {
        timeToDestroy -= Time.deltaTime;

        if(timeToDestroy <= 0) {
            Destroy(gameObject);
        }
    }
}
