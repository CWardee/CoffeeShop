using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    //money ui
    public int moneyToDisplay;
    //money
    private int totalMoney;
    //mouse over
    private bool mouseOver = false;
    //open/close bool
    private bool openRegister = false;
    //cash register trigger
    private TriggerObject registerTrigger;
    //patron hand position
    public GameObject cashObj;

    //mouse over register
    void OnMouseEnter()
    {
        //mouse over
        mouseOver = true;
    }

    //mouse not over register
    void OnMouseExit()
    {
        //mouse exit
        mouseOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //set trigger register
        registerTrigger = this.gameObject.GetComponent<TriggerObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            //close reigster 
            if (openRegister)
            {
                gameObject.transform.position += new Vector3(0, 0, 1);
                moneyToDisplay = totalMoney;
                openRegister = false;
            }

            //open reigster 
            else if (!openRegister)
            {
                gameObject.transform.position += new Vector3(0, 0, -1);
                openRegister = true;
            }
        }


        if (registerTrigger.objectTriggered)
        {
            cashObj = registerTrigger.objThatTriggered;
            totalMoney += 5;
            registerTrigger.objectTriggered = false;
            Destroy(cashObj);
        }
    }
}
