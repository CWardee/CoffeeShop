using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if (x > Screen.width - 155)
        {
            gameObject.transform.position += new Vector3(6 * Time.deltaTime, 0, 0);
        }

        else if (x < 155)
        {
            gameObject.transform.position += new Vector3(6 * -Time.deltaTime, 0, 0);
        }
    }
}
