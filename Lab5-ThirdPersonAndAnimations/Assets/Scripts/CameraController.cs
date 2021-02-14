using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // the target that the camera will follow
    public Transform target;

    // the distance the camera will stay from the target
    public float distanceFromTarget = 5;

    // boolean to toggle following on and off
    public bool follow = true;

    // Displacement of the camera in the y axis
    public float displacementY;

    // easing variable
    public float easing = 0.25f;

    private void Start()
    {
        displacementY = 1.5f;
    }

    /*
    Update the cameras position to follow the target
    */
    void Update()
    {
        /*
        // if allowed to follow the target
        if (follow)
        {
            // move within "distanceFromTarget" metres of the target
            // but retain the same camera rotation at all times
            transform.position = target.position - (target.forward * distanceFromTarget);

            transform.position = new Vector3(transform.position.x, displacementY, transform.position.z);
        }

        // use LookAt(...) to point towards the target
        transform.LookAt(target);
        */

        // if allowed to follow the target
        if (follow)
        {
            // move within "distanceFromTarget" metres of the target
            // but retain the same camera rotation at all times
            Vector3 newPos = target.position - (Vector3.forward * distanceFromTarget);
            // apply the vertical displacement
            newPos.y = target.position.y + displacementY;
            transform.position += (newPos - transform.position) * easing;
            transform.LookAt(target);
        }
        else // otherwise just look at the target
        {
            // use LookAt(...) to point towards the target
            transform.LookAt(target);
        }
    }
}
