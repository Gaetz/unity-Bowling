﻿using System.Collections;
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

    public void MoveStart(float amount)
    {
        if (!ball.IsBallLaunch && Mathf.Abs(transform.position.x + amount) <= 50)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
    }

    public void DragStart()
    {
        if (!ball.IsBallLaunch)
        { 
            // Capture time and position of drag start
            startPosition = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!ball.IsBallLaunch)
        {
            // Calculate velocity
            float launchDuration = Time.time - startTime;
            float launchVelocityX = (Input.mousePosition.x - startPosition.x) / launchDuration;
            float launchVelocityZ = (Input.mousePosition.y - startPosition.y) / launchDuration;

            // Launch ball
            ball.LaunchBall(new Vector3(launchVelocityX, 0, launchVelocityZ));
        }
    }
}
