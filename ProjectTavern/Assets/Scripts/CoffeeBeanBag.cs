using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBeanBag : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform topOfBox;

    public GameObject coffeBagObjct;

    public bool coffeeBagOver;

    public Quaternion from;
    public Quaternion to;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "CoffeeBag")
        {
            coffeBagObjct = other.gameObject;
            coffeeBagOver = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "CoffeeBag")
        {
            coffeeBagOver = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        particles.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (coffeBagObjct != null && coffeBagObjct.transform.rotation.eulerAngles.z > 90.0f && coffeeBagOver)
        {
            particles.transform.rotation = coffeBagObjct.transform.rotation;
            particles.transform.position = topOfBox.transform.position;
            particles.Play();
        }

        else
        {
            particles.Stop();
        }



        if (coffeeBagOver)
        {
            from = coffeBagObjct.transform.rotation;
            to = transform.rotation;



            if (Input.GetMouseButton(1))
            {
                to *= Quaternion.Euler(Vector3.forward * 105);
            }

            else
            {
                to *= Quaternion.Euler(Vector3.forward * 45);
            }

            coffeBagObjct.transform.rotation = Quaternion.Slerp(from, to, Time.deltaTime / 0.5f);
        }



        else if (!coffeeBagOver && coffeBagObjct != null)
        {
            from = coffeBagObjct.transform.rotation;
            to = transform.rotation;
            to *= Quaternion.Euler(Vector3.back * 0);
            coffeBagObjct.transform.rotation = Quaternion.Slerp(from, to, Time.deltaTime / 0.2f);
        }
    }


    private IEnumerator Wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }



    IEnumerator Rotation(GameObject inputObj, Vector3 axis, float angle, float duration = 1.0f)
    {
        yield return null;
    }

    IEnumerator Rotate(GameObject objToRotate, Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = objToRotate.transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;

        while (elapsed < duration)
        {


            //yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);


            objToRotate.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }


        objToRotate.transform.rotation = to;
    }
}
