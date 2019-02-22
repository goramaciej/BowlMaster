using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    

    //[SerializeField] Button resetButton;
    //[SerializeField] Button tidyButton;
    [SerializeField] float distanceToRaise = 10f;
    [SerializeField] GameObject pinSet;
    private PinCounter pinCounter;

    private Animator mAnimator;

    // Use this for initialization
    void Start () {
        pinCounter = FindObjectOfType<PinCounter>();
        mAnimator = GetComponent<Animator>();

        //resetButton.onClick.AddListener(ResetButtonClicked);
        //tidyButton.onClick.AddListener(TidyButtonClicked);
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            mAnimator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            mAnimator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            mAnimator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            Debug.Log("Don't know how to handle end game yet");
        }
    }


    // METHODS TRIGGERED BY ANIMATION EVENTS
    public void RaisePins()
    {        
        foreach (PinSpript pin in GameObject.FindObjectsOfType<PinSpript>())
        {
            // Moved to pin itself
            pin.Raise(distanceToRaise);
        }
    }
    public void LowerPins()
    {
        foreach (PinSpript pin in GameObject.FindObjectsOfType<PinSpript>())
        {
            pin.Lower();
        }
    }
    public void RenewPins()
    {
        Quaternion myStartRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        // instantiate whole pin set from Prefab
        Instantiate(pinSet, new Vector3(-3, 0, -2857), myStartRotation);
    }


    // COLLISIONS WITH BALL AND PINS
    public void OnTriggerExit(Collider collider)
    {
        //ballEnteredBox = false;
        if (collider.gameObject.GetComponent<PinSpript>())
        {
            //Debug.Log("wywaliło pina");
            Destroy(collider.gameObject);
        }
    }

    //left canvas buttons support
    private void ResetButtonClicked()
    {
        //Debug.Log("reset Button clicked");
        mAnimator.SetTrigger("resetTrigger");
    }
    private void TidyButtonClicked()
    {
        //Debug.Log("tidy Button clicked: "+str);
        mAnimator.SetTrigger("tidyTrigger");
    }
}
