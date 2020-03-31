using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class notecontrol : MonoBehaviour {


    public Transform sucessBurst;
    
    public Transform failBurst;

    

    // Use this for initializatio
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "failCollider")
        {

            Destroy(gameObject);
            Debug.Log("Fail");
            Instantiate(failBurst, transform.position, failBurst.rotation);
        }
        if (other.gameObject.name == "sucess")
        {

            Destroy(gameObject);
            Debug.Log("Sucess!!");
            Instantiate(sucessBurst, transform.position, sucessBurst.rotation);
            GM.winStreak += 1;
            GM.match = true;

        }
        else {

            GM.match = false;
        }

        


    }
}
