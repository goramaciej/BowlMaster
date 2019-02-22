using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpript : MonoBehaviour {

    private float standingThreshold = 3f;

    private Vector3 startPosition,
                    startRotationEuler, lerpEndPosition;
    private float lerp = 0, duration = 1;
    private Rigidbody rb;
    private Collider cl;
    private bool isRised = false;
    

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        startRotationEuler = transform.rotation.eulerAngles;
        //Debug.Log(startRotationEuler);

        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () { 
        //if ()
        //Debug.Log(name + " : " + IsStanding());
        //Debug.Log(name + " : " + transform.position.y);
        if (isRised)
        {
            lerp += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(startPosition, lerpEndPosition, lerp);
        }
    }


    // public methods called by PinSetter
    public void Raise(float distanceToRaise = 10f)
    {
        if (IsStanding())
        {
            
            //Debug.Log("pin is raising");
            rb.useGravity = false;
            cl.enabled = false;

            //isRised = true;
            //lerpEndPosition = new Vector3(startPosition.x, startPosition.y + distanceToRaise, startPosition.z);
            //transform.position = new Vector3(startPosition.x, startPosition.y + distanceToRaise, startPosition.z);
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }
    public void Lower()
    {
        transform.position = startPosition;
        // turn back gravity on rigidbody and collider on
        rb.useGravity = true;
        cl.enabled = true;
        //lerpEndPosition = new Vector3(startPosition.x, startPosition.y + distanceToRaise, startPosition.z);
    }




    public bool IsStanding()
    {
        //if (transform.rotation);
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(rotationInEuler.x);
        float tiltZ = Mathf.Abs(rotationInEuler.z);

        bool posY = (Mathf.Floor(transform.position.y) != 4);

        return !(tiltX > standingThreshold && tiltZ > standingThreshold && posY);
    }
}