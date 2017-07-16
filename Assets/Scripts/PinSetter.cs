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
    public bool IsBallOutOfPlay = false;

    private float lastChangeTime;
    private Ball ball;
    private int lastSettledCount = 10;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

    // Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsBallOutOfPlay)
        {
            StandingDisplay.color = Color.red;
            StandingDisplay.text = CountStandingPins().ToString();
            UpdateCheckStanding();
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
                pin.transform.rotation = Quaternion.Euler(0, 0, 0);
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

    void UpdateCheckStanding()
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
        int standingPinsCount = CountStandingPins();
        int pinFall = lastSettledCount - standingPinsCount;
        lastSettledCount = standingPinsCount;
        switch(actionMaster.Bowl(pinFall))
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                lastSettledCount = 10;
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Game is over, but we don't know what to do.");
        }

        LastStandingCount = -1;
        IsBallOutOfPlay = false;
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
}
