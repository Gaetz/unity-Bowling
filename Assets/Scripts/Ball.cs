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
        LaunchBall();
    }

    private void LaunchBall()
    {
        // Initial speed
        rigidBody.velocity = LaunchVelocity;
        // Sound
        ballAudioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
