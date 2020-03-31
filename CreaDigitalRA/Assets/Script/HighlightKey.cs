using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HighlightKey : MonoBehaviour
{

    // Use this for initialization

    public GameObject highlight1;




    void Start()
    {

        highlight1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        StartCoroutine(highlight());


    }


    IEnumerator highlight()
    {
        highlight1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Debug.Log("hit");
        yield return new WaitForSeconds(0.2f);
        highlight1.SetActive(false);

    }


}
