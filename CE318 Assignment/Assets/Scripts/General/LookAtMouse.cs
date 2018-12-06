using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    public float turnSpeed;
    public Camera mainCam;

    private float hitDistance;


    private void FixedUpdate() {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        hitDistance = 0f;

        if (playerPlane.Raycast(ray, out hitDistance)) {
            Vector3 targetPos = ray.GetPoint(hitDistance);

            Quaternion targetRot = Quaternion.LookRotation(targetPos - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }
}
