using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action
    {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    }

    public int[] bowls = new int[21];
    public int bowlIndex = 1;

    public Action Bowl(int pins)
    {
        // Guard
        if(pins < 0 || pins > 10)
        {
            throw new Exception("Pin number should be between 0 and 10, both include.");
        }
        // Behaviour
        bowls[bowlIndex - 1] = pins;

        if(bowlIndex == 21)
        {
            return Action.EndGame;
        }

        if(bowlIndex >= 19 && IsBowl21Awarded())
        {
            bowlIndex += 1;
            return Action.Reset;
        }
        else if (bowlIndex == 20 && !IsBowl21Awarded())
        {
            return Action.EndGame;
        }

        if (pins == 10)
        {
            bowlIndex += 2;
            return Action.EndTurn;
        }
        else
        {
            // End frame
            if(bowlIndex % 2 == 0)
            {
                bowlIndex += 1;
                return Action.EndTurn;
            }
            // Mid frame or last frame
            else
            {
                bowlIndex += 1;
                return Action.Tidy;
            }
        }
        // Other Behaviour
        throw new Exception("Should return an action, but don't know which.");
    }

    private bool IsBowl21Awarded()
    {
        return bowls[19 - 1] + bowls[20 - 1] >= 10;
    }
}
