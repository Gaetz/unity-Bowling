using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>
    /// Launch ball speed
    /// </summary>
    public Vector3 LaunchVelocity;

    /// <summary>
    /// True when ball is launch
    /// </summary>
    public bool IsBallLaunch
    {
        get
        {
            return isBallLaunch;
        }
    }
    private bool isBallLaunch;

    private Vector3 startPosition;

    private Rigidbody rigidBody;
    private AudioSource ballAudioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        ballAudioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;
        isBallLaunch = false;
        startPosition = transform.position;
    }

    public void LaunchBall(Vector3 velocity)
    {
        isBallLaunch = true;
        // Activate gravity
        rigidBody.useGravity = true;
        // Initial speed
        rigidBody.velocity = velocity;
        // Sound
        ballAudioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        isBallLaunch = false;
        transform.position = startPosition;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}
