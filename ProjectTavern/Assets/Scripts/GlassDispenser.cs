using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDispenser : MonoBehaviour
{
    //glass object
    public GameObject glassObject;
    //mouse over bool
    private bool mouseOver = false;

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if mouse is clicked
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            Instantiate(glassObject, gameObject.transform.position, Quaternion.identity);

        }
    }
}
