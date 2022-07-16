using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [Header("Camera Properties:")]
    [Tooltip("The target to follow")]
    public Transform playerTransform = null;
    [Tooltip("Offset vector from the target")]
    public Vector3 followOffset = Vector3.zero;
    [Tooltip("Affects target follow damping")]
    public float dampingFactor = 10f;

    private Vector3 playerPos = Vector3.zero;
    private Vector3 desiredPos = Vector3.zero;

    void LateUpdate() {
        playerPos = playerTransform.position;
        desiredPos = playerPos + followOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * dampingFactor);
    }

}
