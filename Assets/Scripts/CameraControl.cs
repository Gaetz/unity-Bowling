using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    /// <summary>
    /// Targeted ball
    /// </summary>
    public Ball ball;

    /// <summary>
    /// Distance between camera and ball
    /// </summary>
    private Vector3 ballOffset;

	// Use this for initialization
	void Start () {
        ballOffset = transform.position - ball.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.z <= 1500) // In front of pins
        {
            transform.position = ballOffset + ball.transform.position;
        }
    }
}
