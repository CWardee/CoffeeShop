using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //cash
    public CashRegister cashRegister;
    public Text moneyText;

    //time
    public Text timeText;
    private int DelayAmount = 1;
    protected float Timer;
    public int hour = 00;
    public int minute = 00;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update money
        moneyText.text = cashRegister.moneyToDisplay.ToString();
        //update time
        timeText.text = hour.ToString() + " : " + minute.ToString();
        //delay every second
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            minute+=6;
            
            if (minute % 60 == 0)
            {
                hour+=01;
                minute = 0;
                if(hour == 24)
                {
                    hour = 0;
                }
            }
        }
    }
}
