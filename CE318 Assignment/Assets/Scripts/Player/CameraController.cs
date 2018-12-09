using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate() {
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, cameraSpeed);
    }
}
