using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 startPosition;
    private float startTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart()
    {
        // Capture time and position of drag start
        startPosition = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        // Calculate velocity
        float launchDuration = Time.time - startTime;
        float launchVelocityX = (Input.mousePosition.x - startPosition.x) / launchDuration;
        float launchVelocityZ = (Input.mousePosition.y - startPosition.y) / launchDuration;

        // Launch ball
        ball.LaunchBall(new Vector3(launchVelocityX, 0, launchVelocityZ * 2));
    }
}
