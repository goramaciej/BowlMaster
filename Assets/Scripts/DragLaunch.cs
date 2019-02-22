using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime;

    private GameObject rightArrow;
    private GameObject leftArrow;
    private string moving = "";

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();

        rightArrow = GameObject.Find("RightArrow");
        leftArrow = GameObject.Find("LeftArrow");

        AddMouseDown(rightArrow, "right");
        AddMouseDown(leftArrow, "left");

        /*EventTrigger trigger = rightArrow.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => mouseDown());
        trigger.triggers.Add(pointerDown);*/

        //EventTrigger trigger = leftArrow.AddComponent<EventTrigger>();
        //var pointerDown = new EventTrigger.Entry();
        //pointerDown.eventID = EventTriggerType.PointerDown;
        //pointerDown.callback.AddListener((e) => mouseDown());
        //trigger.triggers.Add(pointerDown);
    }
    private void AddMouseDown(GameObject target, string downAction) {
        EventTrigger trigger = target.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => mouseDown(downAction));
        trigger.triggers.Add(pointerDown);

        EventTrigger upTrigger = target.AddComponent<EventTrigger>();
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => mouseUp());
        upTrigger.triggers.Add(pointerUp);
    }

    private void mouseDown(string action) {
        if(action == "left") {
            moving = "left";
            //ball.BallMoveStart(6f);
        } else {
            moving = "right";
            //ball.BallMoveStart(-6f);
        }
    }
    private void mouseUp() {
        moving = "";
        Debug.Log("MouseUp");
    }

    private void Update() {
        if (moving == "left") {
            ball.BallMoveStart(6f);
        }else if (moving == "right") {
            ball.BallMoveStart(-6f);
        }
    }

    public void MoveStart (float amount)
    {
        //Debug.Log("Ball moved: " + amount);
        //ball.transform.position.x += (amount / 30);
        //Debug.Log("i'm here");
        //ball.BallMoveStart(amount);

        /*ball.transform.Translate(new Vector3(-(amount / 6), 0, 0));
        Debug.Log(ball.transform.position.x);*/
    }

    public void DragStart()
    {
        // Capture time & position of drag start
        //Debug.Log("DragStart");
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }
    public void DragEnd()
    {
        // Launch the ball;
        Debug.Log("dragEnd"); 
        //ball.Launch(new Vector3(7,0,-600));
        dragEnd = Input.mousePosition;
        float dragDuration = Time.time - startTime;
        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        //Debug.Log(launchSpeedX + " : " + launchSpeedZ);

        ball.Launch(new Vector3(-launchSpeedX/5, 0, -launchSpeedZ/2));
    }
}
