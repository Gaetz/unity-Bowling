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


    private Rigidbody rigidBody;
    private AudioSource ballAudioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        ballAudioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;
        isBallLaunch = false;
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
}
