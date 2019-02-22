using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody myRigidbody;
    // int launchSpeed = -500;

    private bool inPlay = false;

    private AudioSource ballSound;

    [SerializeField] public Vector3 launchVelocity;

    private Vector3 startPosition;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        ballSound = GetComponent<AudioSource>();
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;

        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
	}
    public void BallMoveStart(float amount)
    {
        if (inPlay)
        {
            return;
        }

        Vector3 myPos = transform.position;

        float myX = Mathf.Clamp(myPos.x - (amount / 6), -37f, 37f);

        transform.position = new Vector3(myX, myPos.y, myPos.z);
        //if (myX <= 37 && myX >= -37)
        //{
        //    transform.position = new Vector3(myX, myPos.y, myPos.z);
        //}
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        myRigidbody.useGravity = true;
        myRigidbody.velocity = velocity;

        ballSound.Play();
    }


    public void ResetPosition()
    {
        //Debug.Log("ResetPosition");
        inPlay = false;
        myRigidbody.useGravity = false;
        transform.position = startPosition;
        //transform.rotation = startRotation;
        transform.rotation = Quaternion.identity;

        myRigidbody.velocity = Vector3.zero;//new Vector3(0, 0, 0);

        //CameraControl mainCamera = FindObjectOfType<CameraControl>();
        //mainCamera.resetCamera();
        //AddStartVelocity();
    }

    /* COLLISIONS 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("jest kolizja: " + collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    */

    // Update is called once per frame
    void Update () {
		
	}
}
