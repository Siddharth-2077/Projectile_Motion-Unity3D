using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroy : MonoBehaviour {
    private float destroyAfter = 3f;
    
    private void Start() {
        Destroy(gameObject, destroyAfter);
    }      
}
