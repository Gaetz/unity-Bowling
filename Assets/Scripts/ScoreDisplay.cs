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
        string output = FormatRolls(rolls);
        for (int i = 0; i < output.Length; i++)
        {
            rollTexts[i].text = output[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        return output;
    }
}
