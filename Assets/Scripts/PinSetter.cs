using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StandingDisplay.text = CountStandingPins().ToString();
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
