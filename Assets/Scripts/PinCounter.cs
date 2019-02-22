using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    [SerializeField] private Text standingDisplay;

    private GameManagerM gameManager;

    [HideInInspector] public int lastStandingCount = -1;
    [HideInInspector] public bool ballOutOfPlay = false;

    private int lastSettledCount = 10;
    private float lastChangeTime;

    // Use this for initialization
    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerM>();
    }


    public void Reset()
    {
        lastSettledCount = 10;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballOutOfPlay)
        {
            UpdateStandingCoundAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    // Ball entered into collider area
    private void UpdateStandingCoundAndSettle()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }


    // its been 3 seconds since ball left collider area
    private void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }


    private int CountStanding()
    {
        int standing = 0;
        foreach (PinSpript pin in GameObject.FindObjectsOfType<PinSpript>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
}
