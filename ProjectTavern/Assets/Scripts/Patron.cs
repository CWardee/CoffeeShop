using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Patron : MonoBehaviour
{
    public QueueSpot queueSpotScript;
    //queue script
    public Queue queueScript;
    //speech bubble
    public GameObject speechBubble;
    //current happiness
    public float happiness;
    //max happiness
    private int maxHapiness = 100;
    //has been served?
    public bool hasBeenServed = false;
    //is customer being served?
    public bool beingServed = false;
    //patron trigger
    public TriggerObject patronTrigger;
    //patron hand position
    public GameObject handPos;
    //glass in hand
    private GameObject glass;
    //glass script
    private Glass glassScript;
    //cash note object
    public GameObject cashNote;
    //cash note object
    public Transform cashDeskLocation;
    //goal red/yellow
    public float goalRed;
    public float goalYellow;

    public float redPerc;
    public float yellowPerc;


    public enum sampleEnum
    {
        FirstSample,
        SecondSample,
        ThirdSample,
    }

    public sampleEnum state;









    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform middleMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;
    // Time when the movement started.
    private float startTime;
    // Total distance between the markers.
    private float journeyLength;

    private void OnMouseDown()
    {
        this.state = sampleEnum.FirstSample;

        if(state == sampleEnum.SecondSample)
        {
            //touch me


        }

        if(!beingServed)
        {
            beingServed = true;
        }
    }

    //generate drink
    void genDrink()
    {
        goalRed = Random.Range(10.0f, 90.0f);

       
        goalYellow = 100 - goalRed;
    }

    //restart
    void restart()
    {
        Destroy(glass);
        happiness = maxHapiness;
        hasBeenServed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        speechBubble.transform.localScale = new Vector3(0, 0, 0);
        happiness = maxHapiness;
        genDrink();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.MoveTowards(startMarker.position, middleMarker.position, 2);


        float step = 3 * Time.deltaTime;

        //if patron has not been served
        if (!hasBeenServed && happiness > 0)
        {

            //find free space


            if (!beingServed)
            {
                //move into scene
                transform.position = Vector3.MoveTowards(transform.position, middleMarker.position, step);


                if (transform.position == middleMarker.position)
                {
                    LeanTween.scale(speechBubble, new Vector3(8, 8, 8), 1.0f);
                }
            }

            else if (beingServed)
            {
                //move into scene
                transform.position = Vector3.MoveTowards(transform.position, endMarker.position, step);
                LeanTween.scale(speechBubble, new Vector3(0, 0, 0), 1.0f);
            }

            //decrease hapiness
            happiness -= Time.deltaTime;

            if (patronTrigger != null && patronTrigger.objectTriggered && Input.GetMouseButtonUp(0))
            {

                //assign glass
                glass = patronTrigger.objThatTriggered;

                glassScript = glass.GetComponent<Glass>();

                //get 1% of total
                float onePerc = glassScript.totalGlassNum / 100;

                redPerc = glassScript.redDrinkPercent / glassScript.totalGlassNum * 100;
                yellowPerc = glassScript.yellowDrinkPercent / glassScript.totalGlassNum * 100;

                //check drink
                if (redPerc > goalRed - 100 && redPerc < goalRed + 100 &&
                    yellowPerc > goalYellow - 100 && yellowPerc < goalYellow + 100)
                {
                    //get rigid body of glass
                    Rigidbody objRig = glass.GetComponent<Rigidbody>();
                    //set kinematic
                    objRig.isKinematic = true;
                    //disable collision
                    objRig.detectCollisions = false;
                    //disable gravity
                    objRig.useGravity = false;
                    //set the glass to the hand
                    glass.transform.localPosition = handPos.transform.position;
                    //set the rotation of glass to hand
                    glass.transform.rotation = handPos.transform.rotation;
                    //parent glass to hand
                    glass.transform.SetParent(handPos.transform);
                    //pay
                    Instantiate(cashNote, (cashDeskLocation.transform.position), Quaternion.Euler(0.0f, Random.Range(0f, 180f), 0.0f));
                    //disable bool
                    hasBeenServed = true;
                }
               
            }
        }

        //if customer has been served or happiness reaches zero
        else if(hasBeenServed || happiness < 0)
        {
            //move into scene
            transform.position = Vector3.MoveTowards(transform.position, endMarker.position, step);
            genDrink();
            if (transform.position == endMarker.position)
            {
                restart();
                beingServed = false;

                //move into scene
                transform.position = startMarker.position;
            }
        }
    }
}
