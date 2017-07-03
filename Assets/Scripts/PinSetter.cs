using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingDisplay;
    public int LastStandingCount = -1;
    public float SettleTime;
    public float DistanceToRaise = 0.1f;
    public GameObject PinSet;

    private bool hasBallEntered = false;
    private float lastChangeTime;
    private Ball ball;

    // Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hasBallEntered)
        {
            StandingDisplay.text = CountStandingPins().ToString();
            CheckStanding();
        }
    }

    public void RaiseStandingPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.GetComponent<Rigidbody>().isKinematic = true;
                pin.transform.Translate(new Vector3(0, DistanceToRaise, 0), Space.World);
            }
        }
    }


    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.transform.Translate(new Vector3(0, -DistanceToRaise, 0), Space.World);
            pin.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(PinSet);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.GetComponent<Rigidbody>().isKinematic = true;
        }
        newPins.transform.position += new Vector3(0, DistanceToRaise, 0);
    }

    void CheckStanding()
    {
        int currentStanding = CountStandingPins();
        // Update LastStandingCount
        if(currentStanding != LastStandingCount)
        {
            lastChangeTime = Time.time;
            LastStandingCount = currentStanding;
            return;
        }
        // Call HavePinSettled() when they do;
        if(Time.time - lastChangeTime > SettleTime)
        {
            HavePinSettled();
        }
    }

    private void HavePinSettled()
    {
        LastStandingCount = -1;
        hasBallEntered = false;
        StandingDisplay.color = new Color(0, 1, 0);
        ball.Reset();
    }

    public int CountStandingPins()
    {
        int standingCount = 0;
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
                standingCount++;
        }
        return standingCount;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Ball>())
        {
            hasBallEntered = true;
            StandingDisplay.color = new Color(1, 0, 0);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponentInParent<Pin>())
        {
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
