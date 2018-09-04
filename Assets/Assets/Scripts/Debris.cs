using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard {

    public Vector3 rotacion;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotacion * Time.deltaTime);
	}
}
