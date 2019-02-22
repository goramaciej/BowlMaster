using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {
    
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        // Index i points to 2nd bowl in frame
        for (int i = 1; i < rolls.Count; i += 2)
        {
            if (frames.Count == 10) { break; }

            int frameScore = rolls[i - 1] + rolls[i];  // calculating frame score (this and previous bowl)

            if (frameScore < 10)
            {
                frames.Add(frameScore);
            }
            if (rolls.Count - i <= 1)
            {
                // if there is no at least 1 look-ahead roll to count on it
                break;
            }

            if (rolls[i - 1] == 10)
            {
                // strike
                i--; // strike frame has one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (frameScore == 10)
            {
                // spare
                frames.Add(10 + rolls[i + 1]);
            }
        }
        return frames;
    }


    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;
    }
}
