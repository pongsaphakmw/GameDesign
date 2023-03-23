using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;
    public float smoothSpeed = 0.125f;
    void Start()
    {
        cameraOffset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothSpeed);
    }
}
