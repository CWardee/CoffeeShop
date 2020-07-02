using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public int maxCustomers;


    public GameObject emptyObj;
    public GameObject[] spaceArray;


    public GameObject customerObj;
    public GameObject[] customArray;

    // Start is called before the first frame update
    void Start()
    {
        Transform startPos = emptyObj.transform;
        Transform CuststartPos = customerObj.transform;
        spaceArray = new GameObject[maxCustomers];
        customArray = new GameObject[maxCustomers];

        for (int x = 0; x < maxCustomers; x++)
        {
            GameObject empObj = Instantiate(emptyObj, (startPos.position), Quaternion.identity);
            empObj.name = "QueuePosition " + x;
            emptyObj.transform.position += new Vector3(1.2f, 0, 0);
            spaceArray[x] = empObj;
        }


        for (int x = 0; x < maxCustomers; x++)
        {
            GameObject custObj = Instantiate(customerObj, (CuststartPos.position), Quaternion.identity);
            custObj.name = "Customer " + x;
            customerObj.transform.position += new Vector3(1.2f, 0, 0);
            customArray[x] = custObj;
        }


    }

    // Update is called once per frame
    void Update()
    {
        float step = 3 * Time.deltaTime;
        for (int x = 0; x < maxCustomers; x++)
        {
            //customArray[x].transform.position = Vector3.MoveTowards(transform.position, spaceArray[x].transform.position, 1);
        }


            Random.Range(0, maxCustomers);

    }

}
