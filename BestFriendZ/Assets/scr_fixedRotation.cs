using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fixedRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Fix the objects rotation so that it ignores the parents rotation
        transform.rotation = Quaternion.identity;
    }
}
