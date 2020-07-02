using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHolder : MonoBehaviour
{
    private Glass glassScript;
    public DrinkDispenser dispenserScript;
    private void OnTriggerEnter(Collider objectThatCollided)
    {
        if(objectThatCollided.tag == "Glass")
        {
            glassScript = objectThatCollided.GetComponent<Glass>();

            //if red drink
            if(dispenserScript.RedDispenser)
            {
                glassScript.underRedDispenser = true;
            }

            //if yellow drink
            if (dispenserScript.YellowDispenser)
            {
                glassScript.underYellowDispenser = true;
            }


            dispenserScript.GlassObjScript = objectThatCollided.GetComponent<Glass>();
        }
    }


    private void OnTriggerExit(Collider objectThatCollided)
    {
        if (objectThatCollided.tag == "Glass")
        {
            glassScript.underRedDispenser = false;
            glassScript.underYellowDispenser = false;
            glassScript.fillingDrink = false;
            dispenserScript.GlassObjScript = null;
            glassScript.currentlyFilling = false;
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
