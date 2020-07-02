using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DrinkDispenser : MonoBehaviour
{
    //dispenser handle
    public GameObject DispenserHandleHover;
    //dispenser handle
    public GameObject DispenserHandlePivot;
    //dispenser fluid pivot object
    public GameObject DispenserContentsPivot;
    //dispenser fluid particle systme
    public ParticleSystem RedDispenserParticles;
    public ParticleSystem YellowDispenserParticles;
    //enable or disable dispensing of content
    private bool DispenseContents = false;
    //glass object script
    public Glass GlassObjScript;
    //drink types
    public bool YellowDispenser = false;
    public bool RedDispenser = false;
    public GameObject DrinkYellow;
    public GameObject DrinkRed;


    //reset bools
    void ResetBools()
    {
        YellowDispenser = false;
        RedDispenser = false;
    }

    //sets all drinks to false
    void ResetDrinks()
    {
        DrinkYellow.SetActive(false);
        DrinkRed.SetActive(false);
    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over Handle.");
        DispenserHandleHover.SetActive(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer over Handle.");
        DispenserHandleHover.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        DispenserHandleHover.SetActive(false);

        RedDispenserParticles.Stop();
        YellowDispenserParticles.Stop();

        if (YellowDispenser)
        {
            ResetDrinks();
            DrinkYellow.SetActive(true);
        }

        else if (RedDispenser)
        {
            ResetDrinks();
            DrinkRed.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if(DispenserHandleHover.activeSelf == true)
            {
                Debug.Log("Pressed primary button.");

                //toggle dispenseer
                if (!DispenseContents)
                {
                    //handle
                    DispenserHandlePivot.transform.eulerAngles = new Vector3(-45, 0, 0);

                    //bool
                    DispenseContents = true;

                    //particle
                    if(YellowDispenser)
                    {
                        YellowDispenserParticles.Play();
                    }

                    else if(RedDispenser)
                    {
                        RedDispenserParticles.Play();
                    }
                }

                else
                {
                    //handle
                    DispenserHandlePivot.transform.eulerAngles = new Vector3(0, 0, 0);

                    //bool
                    DispenseContents = false;

                    //particle
                    RedDispenserParticles.Stop();
                    YellowDispenserParticles.Stop();
                }
            }
        }

        //fill up
        if(DispenserContentsPivot.transform.localScale.y > 0)
        {
            //dispense fluid if bool is enabled
            if (DispenseContents)
            {
                DispenserContentsPivot.transform.localScale += new Vector3(0, -0.05f * Time.deltaTime, 0);

                //check if there is a glass below
                if (GlassObjScript != null)
                {
                    GlassObjScript.fillingDrink = true;
                }
            }


            else
            {
                if (GlassObjScript != null)
                {
                    GlassObjScript.fillingDrink = false;
                }
            }
        }

        //if empty
        else
        {
            DispenserHandlePivot.transform.eulerAngles = new Vector3(0, 0, 0);
            DispenseContents = false;
            RedDispenserParticles.Stop();
            YellowDispenserParticles.Stop();

            if (GlassObjScript != null)
            {
                GlassObjScript.fillingDrink = false;
            }
        }
    }
}
