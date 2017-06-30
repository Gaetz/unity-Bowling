using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float StandingThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsStanding()
    {
        return Mathf.Abs(transform.rotation.eulerAngles.x) < StandingThreshold
            && Mathf.Abs(transform.rotation.eulerAngles.z) < StandingThreshold;
    }
}
