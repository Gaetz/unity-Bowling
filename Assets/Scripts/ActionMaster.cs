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

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach(int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    private Action Bowl(int pins)
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

        if(bowlIndex == 19 && pins == 10)
        {
            bowlIndex += 1;
            return Action.Reset;
        }
        else if (bowlIndex == 20)
        {
            bowlIndex += 1;
            if(bowls[19 - 1] == 10 && bowls[20 - 1] != 10)
            {
                return Action.Tidy;
            }
            else if (AreAllPinsKnockedDown())
            {
                return Action.Reset;
            }
            else if (IsBowl21Awarded())
            {
                return Action.Tidy;
            }
            else return Action.EndGame;
        }


        // First bowl in each frame
        if(bowlIndex % 2 != 0)
        {
            if (pins == 10)
            {
                bowlIndex += 2;
                return Action.EndTurn;
            }
            else
            {
                bowlIndex += 1;
                return Action.Tidy;
            }
        }
        // Second bowl in each frame
        else
        {
            bowlIndex += 1;
            return Action.EndTurn;
        }
    }

    private bool AreAllPinsKnockedDown()
    {
        return (bowls[19 - 1] + bowls[20 - 1]) == 20 || (bowls[19 - 1] + bowls[20 - 1]) == 10;
    }

    private bool IsBowl21Awarded()
    {
        return bowls[19 - 1] + bowls[20 - 1] > 10;
    }
}
