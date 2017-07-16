using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public float DistanceToRaise = 0.1f;
    public GameObject PinSet;
    public bool IsBallOutOfPlay = false;

    private Animator animator;
    private PinCounter pinCounter;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	
	// Update is called once per frame
	void Update () {

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

    public void PerformAction(ActionMaster.Action action)
    {
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Game is over, but we don't know what to do.");
        }
    }
}
