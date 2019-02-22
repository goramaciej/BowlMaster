using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOld {

    /*public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> PinFalls)
    {
        ActionMaster myAm = new ActionMaster();
        Action currentAction = new Action();

        foreach(int pinFall in PinFalls) {
            currentAction = myAm.Bowl(pinFall);
        }
        return currentAction;
    }

    public Action Bowl(int pins)
    {
        bowls[bowl - 1] = pins;

        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins");
        } 

        if (bowl == 21)
        {
            Debug.Log("przechodzi tutaj 21");
            return Action.EndGame;
        }

        // handle last-frame special cases
        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20)
        {
            bowl++;
            if ((bowls[19 - 1] == 10) && (bowls[20 - 1] == 0))
            {
                return Action.Tidy;
            }

            if ((bowls[19 - 1] + bowls[20 - 1]) == 10)
            {
                // last 2 bowls sum is equal 10 or 20
                return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
                 return Action.Tidy;
            }
            else
            {
                Debug.Log("przechodzi tutaj 20");
                return Action.EndGame;
            }
        }


        
        // If first bowl of frame return Action.Tidy;
        if (bowl % 2 == 1)
        {
            if (pins == 10)
            {
                // if first bowl in frame is 10 go to next frame at sight
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl++;
                return Action.Tidy;
            }
        } else if (bowl % 2 == 0)
        {
            // End frame
            bowl++;
            return Action.EndTurn;
        }
        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded()
    {
        // if score 10 points in 19 and 20 bowl you award an extra bowl 21
        return (bowls[19 - 1] + bowls[20 - 1] >= 10); 
    }*/
}