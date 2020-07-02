using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Glass : MonoBehaviour
{
    public float totalGlassNum = 2;
    public float redDrinkPercent;
    public float yellowDrinkPercent;

    //fluid objects
    public GameObject redDrinkFluid;
    public GameObject yellowDrinkFluid;
    public GameObject bottomGlassPos;

    //is under yellow dispenser
    public bool underYellowDispenser = false;

    //is under red dispenser
    public bool underRedDispenser = false;

    //is filling drink
    public bool fillingDrink = false;

    //percentage of glass filled
    public float glassPercentage = 0;

    //foam particles
    public ParticleSystem foam;

    //top of drink
    private float topDrinkYpos;

    private GameObject drinkToFill;

    public bool currentlyFilling = false;

    void SpawnNewFluid()
    {
        GameObject drinkTopping;

        if (underRedDispenser)
        {
            drinkTopping = Instantiate(redDrinkFluid, (bottomGlassPos.transform.position), bottomGlassPos.transform.rotation);
        }

        else
        {
            drinkTopping = Instantiate(yellowDrinkFluid, (bottomGlassPos.transform.position), bottomGlassPos.transform.rotation);
        }



        drinkTopping.transform.parent = this.gameObject.transform;
        drinkTopping.transform.localScale = redDrinkFluid.transform.localScale;
        drinkToFill = drinkTopping;
    }

    // Start is called before the first frame update
    void Start()
    {
        foam.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //fill glass
        if (fillingDrink && glassPercentage < totalGlassNum)
        {
            foam.Play();
            foam.transform.localPosition += new Vector3(0, +0.5f * Time.deltaTime, 0);
            bottomGlassPos.transform.localPosition += new Vector3(0, +0.5f * Time.deltaTime, 0);

            if (!currentlyFilling)
            {
                SpawnNewFluid();
            }

            //red drink
            if (underRedDispenser)
            {
                redDrinkPercent += Time.deltaTime;
            }

            //red drink
            else if (underYellowDispenser)
            {
                yellowDrinkPercent += Time.deltaTime;
            }

            currentlyFilling = true;
            topDrinkYpos += 0.5f;
            drinkToFill.transform.localScale += new Vector3(0, +0.5f * Time.deltaTime, 0);

            //update glass percentage
            glassPercentage += Time.deltaTime;
        }
    }
}
