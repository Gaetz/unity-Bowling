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
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;
            // Spare
            if ((box % 2 == 0 || box == 21) && rolls[i-1] + rolls[i] == 10)
            {
                output += "/";
            }
            // Strike in frame 10
            else if (box >= 19 && rolls[i] == 10)
            {
                output += "X";
            }
            // Strike elsewhere
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            // Zeros
            else if (rolls[i] == 0)
            {
                output += "-";
            }
            // Normal shot
            else
            {
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}
