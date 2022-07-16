using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [Header("Turret Components:")]
    [Space(10f)]
    public GameObject shellPrefab; 
    public GameObject shellSpawnPos; 
    public GameObject target; 
    public GameObject parent; 

    [Header("Turret Properties")]
    [Space(10f)]
    [SerializeField] [Range(10f, 50f)] private float speed = 30;
    [SerializeField] [Range(1f, 10f)] private float turnSpeed = 2;
    
    private bool canShoot = true;
    

    void Update() {        
        DrawDebugRays();        
        Vector3 direction = (target.transform.position - parent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        float? angle = RotateTurret();

        // When the angle is less than 50 degrees
        if(angle != null && Vector3.Angle(direction, parent.transform.forward) < 50) 
            Fire(); // Start Firing
    }

    void DrawDebugRays() {
        // Ray to target player
        Vector3 direction = target.transform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);
        // Forward vector ray
        Vector3 forward = new Vector3(direction.x, 0f, direction.z).normalized;
        Debug.DrawRay(transform.position, forward * 4f, Color.red);        
    }
    
    void CanShootAgain() {
        canShoot = true;
    }

    void Fire() {
        if (canShoot) {
            GameObject shell = Instantiate(shellPrefab, shellSpawnPos.transform.position, shellSpawnPos.transform.rotation);
            shell.GetComponent<Rigidbody>().velocity = speed * this.transform.forward; 
            canShoot = false;
            Invoke("CanShootAgain", 0.15f); 
        }
    }

    float? RotateTurret() {
        float? angle = CalculateAngle(true);    // false = upper range. true = lower range
        // If angle exists
        if (angle != null) {
            this.transform.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
        return angle;
    }

    float? CalculateAngle(bool low) {
        // Calculate Projectile Physics
        Vector3 targetDir = target.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.magnitude;
        float gravity = 9.81f;
        float sSqr = speed * speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0f) {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;
            if (low)
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        return null;
    }
}
