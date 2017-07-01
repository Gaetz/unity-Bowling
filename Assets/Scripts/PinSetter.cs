using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingDisplay;

    bool hasBallEntered = false;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hasBallEntered)
        {
            StandingDisplay.text = CountStandingPins().ToString();
        }
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
