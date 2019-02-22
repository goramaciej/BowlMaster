using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreDisplay : MonoBehaviour {
    public List<Text> rollTexts = new List<Text>();
    public List<Text> frameTexts = new List<Text>();

    // Use this for initialization
    void Start()
    {
        setTextComponentLists();
    }

    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for (var i=0; i < scoresString.Length; i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }
    public void FillFrames(List<int> frames)
    {
        for(int i=0; i<frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";
        for (int i=0; i<rolls.Count; i++) {
            int box = output.Length + 1;

            if (rolls[i] == 0) {
                output += "-";
            } else if ((box % 2 == 0 || box == 21) && rolls[i-1] + rolls[i] == 10){
                output += "/";
            } else if(box >= 19 && rolls[i] == 10) { 
                output += "X";
            } else if(rolls[i] == 10){
                output += "X ";
            } else {
                output += rolls[i].ToString();
            }
        }        
        return output;
    }

    private void setTextComponentLists()
    {
        foreach (Transform child in transform)
        {
            GameObject myChild = child.gameObject;

            Text[] textArray = myChild.GetComponentsInChildren<Text>();
            // get all children of type Text as an array
            if (textArray.Length > 0)
            {
                for (int i = 0; i < textArray.Length; i++)
                {
                    textArray[i].fontSize = 12;
                    if (textArray[i].name == "frame")
                    {                        
                        textArray[i].text = "";
                        frameTexts.Add(textArray[i]);
                    }
                    else
                    {
                        textArray[i].text = "";
                        rollTexts.Add(textArray[i]);
                    }
                }
            }
        }
        frameTexts[0].text = "0";
        rollTexts[0].text = "X";
        Debug.Log("frameTexts: " + frameTexts.Count);
        Debug.Log("rollTexts: " + rollTexts.Count);
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
