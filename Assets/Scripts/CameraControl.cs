using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField] public Ball ball;
    private Vector3 offset;
    private Vector3 startPosition;

    // Use this for initialization
    void Start () {
        //startPosition = transform.position;
        offset = transform.position - ball.transform.position;
        //resetCamera();
    }

    public void resetCamera()
    {
        //transform.position = startPosition;
    }

    // Update is called once per frame
    void Update() {
        if (ball.transform.position.z >= -1829f) { 
            transform.position = ball.transform.position + offset;
        }
    }
}