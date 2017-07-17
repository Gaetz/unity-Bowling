using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster : MonoBehaviour {

    /// <summary>
    /// Return a list of cumulative scores, like in normal score card
    /// </summary>
    /// <param name="rolls"></param>
    /// <returns></returns>
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;
    }

    /// <summary>
    /// Return a list of individual frame scores, not cumulative
    /// </summary>
    /// <param name="rolls"></param>
    /// <returns></returns>
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        for(int i = 1; i < rolls.Count; i+=2) {
            // Prevents eleventh frame
            if (frames.Count == 10)
                break;

            // Normal "open" frame
            if (rolls[i - 1] + rolls[i] < 10)
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }
            // Protection if there is no more score
            if (rolls.Count - i <= 1)
                break;
            // Strike
            if(rolls[i-1] == 10)
            {
                i--; // To take strike into account (one ball only)
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            // Spare
            else if (rolls[i - 1] + rolls[i] == 10)
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }
}
