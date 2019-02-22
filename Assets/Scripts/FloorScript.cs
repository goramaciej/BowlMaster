using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

    private Ball myBall;

	// Use this for initialization
	void Start () {
        myBall = GameObject.FindObjectOfType<Ball>();
        Debug.Log(myBall);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}