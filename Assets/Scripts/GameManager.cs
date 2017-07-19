using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);
        ActionMasterOld.Action nextAction = ActionMasterOld.NextAction(bowls);
        pinSetter.PerformAction(nextAction);
        ball.Reset();

        try {
            scoreDisplay.FillRollCard(bowls);
        }
        catch
        {
            Debug.LogWarning("Error while filling scoreboard.");
        }

    }
}
