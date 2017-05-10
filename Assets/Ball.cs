using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>
    /// Launch ball speed
    /// </summary>
    public float LaunchSpeed;

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
        rigidBody.velocity = new Vector3(0, 0, LaunchSpeed);
        // Sound
        ballAudioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
