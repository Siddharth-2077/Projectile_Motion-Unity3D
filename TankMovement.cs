using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    private Transform tank = null;
    private float vertical = 0f;
    private float horizontal = 0f;

    [Header("Tank Movement Properties:")]
    [Space(10f)]    
    [SerializeField] [Range(1f, 10f)] private float speed = 7f;
    [SerializeField] [Range(1f, 360f)] private float rotateSpeed = 100f;

    void Start() {
        tank = GetComponent<Transform>();
    }

    void Update() {
        GetInputs();
    }

    void LateUpdate() {
        Move();
    }

    void GetInputs() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    void Move() {
        tank.Translate(Vector3.forward * (Time.deltaTime * vertical * speed));
        tank.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * horizontal, Space.World);
    }

}
