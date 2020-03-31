using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class string1 : MonoBehaviour {

    public KeyCode activateString;
    public float xPos;
   
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().position = new Vector3(xPos, -0.42f, -7.863f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(activateString))
        {
            GetComponent<Rigidbody>().position = new Vector3(xPos, -0.42f, -7.563f);
                         
        }
        if (Input.GetKeyUp(activateString))
        {
            
            StartCoroutine(retractCollider());
        }


    }

    IEnumerator retractCollider()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



    }
}
