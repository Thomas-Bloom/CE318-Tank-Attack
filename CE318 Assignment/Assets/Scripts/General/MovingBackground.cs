using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

    public float speed;

    private float pos = 0;
    private Renderer renderer;

    private void Start() {
        renderer = GetComponent<Renderer>();
    }

    private void Update() {
        pos += speed;

        if(pos > 1f) {
            pos -= 1f;
        }
        renderer.material.mainTextureOffset = new Vector2(0, pos);
    }
}
