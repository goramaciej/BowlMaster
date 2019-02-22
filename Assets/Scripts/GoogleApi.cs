using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour {

    public RawImage img;

    private string url;
    public float lat;
    public float lon;

    LocationInfo li;

    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satelite, hybrid, terrain };
    public mapType mapSelected;
    public int scale;

    private IEnumerator coroutine;


	// Use this for initialization
	void Start () {
        img = gameObject.GetComponent<RawImage>();
        
        //StartCoroutine(Map());
        //StartCoroutine(WaitAndPrint());
    }
    //IEnumerator Map()
    //{
        /*url = "\"https://maps.googleapis.com/maps/api/staticmap?center=\" + lat + \",\" + lon +\n" +
            \"&zoom=\" + zoom + \"&size=\";*/

        /*url = "https://www.onet.pl/";
        using (WWW www = new WWW(url))
        {

        }*/
        
        /*WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();*/

        /*while (true)
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log("WaitAndPrint " + Time.time);
        }*/
    //}


    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("WaitAndPrint " + Time.time);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
