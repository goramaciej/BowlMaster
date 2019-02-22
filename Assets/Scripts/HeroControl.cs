using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour {

    Rigidbody rb;
    Animator an;
    Collider col;

    [SerializeField] Camera cam;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

        // click?
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider == col)
                {
                    Debug.Log("You hit me");
                }
            }
        }


        if (Input.GetKeyDown("a"))
        {
            an.SetTrigger("HeadTrigger");
            //rb.velocity = new Vector3(100f, 0f, 0f);// to nie działa nie wiem dlaczego
            Debug.Log(rb.velocity);
            //transform.position = new Vector3(0.2f, 0.3f);
        }
        if (Input.GetKeyDown("s"))
        {
            an.SetTrigger("KickTrigger");
            Debug.Log(rb.velocity);
            //rb.velocity = new Vector3(-100f, 0f, 0f);// to nie działa nie wiem dlaczego
            //transform.position = new Vector3(-0.2f, -0.3f);
        }
	}
}
