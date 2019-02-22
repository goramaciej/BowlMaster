using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerM : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    private void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        try
        {
            bowls.Add(pinFall);

            ball.ResetPosition();

            pinSetter.PerformAction(ActionMaster.NextAction(bowls));
        }catch
        {
            Debug.LogWarning("Something went wrong in GameManager Bowl()");
        }

        try
        {
            scoreDisplay.FillRolls(bowls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(bowls));
        }
        catch
        {
            Debug.LogWarning("GameMaster failed bowls to scoreDisplay");
        }
    }
}
