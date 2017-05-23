using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followTarget;
    public float modeSpeed;

    void LateUpdate()
    {
        if (!followTarget)
            return;

        transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, Time.deltaTime * modeSpeed);
    }
}
