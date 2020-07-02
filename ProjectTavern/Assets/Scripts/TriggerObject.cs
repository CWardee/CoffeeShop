using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    //tag to of object to enable trigger
    public string tagToTriggerUpon;
    //trigger bool
    public bool objectTriggered = false;
    //object that triggered
    public GameObject objThatTriggered;

    //on trigger enter
    public void OnTriggerEnter(Collider objCollided)
    {
        //check is object has specific tag
        if (objCollided.tag == tagToTriggerUpon)
        {
            objThatTriggered = objCollided.gameObject;
            objectTriggered = true;
        }
    }

    //on trigger exit
    public void OnTriggerExit(Collider objCollided)
    {
        //check is object has specific tag
        if (objCollided.tag == tagToTriggerUpon)
        {
            objThatTriggered = null;
            objectTriggered = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
