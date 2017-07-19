using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts;
    public Text[] frameTexts;

    // Use this for initialization
    void Start () {
        foreach (Text display in rollTexts)
            display.text = "";
        foreach (Text display in frameTexts)
            display.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillRollCard(List<int> rolls)
    {
        rolls[-1] = 1;
    }
}
