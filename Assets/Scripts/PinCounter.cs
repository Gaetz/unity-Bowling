using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text StandingDisplay;
    public int LastStandingCount = -1;
    public float SettleTime;

    private GameManager gameManager;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private bool isBallOutOfPlay;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isBallOutOfPlay)
        {
            StandingDisplay.color = Color.red;
            StandingDisplay.text = CountStandingPins().ToString();
            UpdateCheckStanding();
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            isBallOutOfPlay = true;
        }
    }

    void UpdateCheckStanding()
    {
        int currentStanding = CountStandingPins();
        // Update LastStandingCount
        if (currentStanding != LastStandingCount)
        {
            lastChangeTime = Time.time;
            LastStandingCount = currentStanding;
            return;
        }
        // Call HavePinSettled() when they do;
        if (Time.time - lastChangeTime > SettleTime)
        {
            HavePinSettled();
        }
    }

    private void HavePinSettled()
    {
        int standingPinsCount = CountStandingPins();
        int pinFall = lastSettledCount - standingPinsCount;
        lastSettledCount = standingPinsCount;

        gameManager.Bowl(pinFall);

        LastStandingCount = -1;
        isBallOutOfPlay = false;
        StandingDisplay.color = new Color(0, 1, 0);
    }

    public int CountStandingPins()
    {
        int standingCount = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
                standingCount++;
        }
        return standingCount;
    }
}
