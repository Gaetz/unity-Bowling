using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>
    /// Launch ball speed
    /// </summary>
    public Vector3 LaunchVelocity;

    private Rigidbody rigidBody;
    private AudioSource ballAudioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        ballAudioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;
        //LaunchBall(LaunchVelocity);
    }

    public void LaunchBall(Vector3 velocity)
    {
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
