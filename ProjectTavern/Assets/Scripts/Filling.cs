using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    public GameObject pivot;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particles Detected");
        part = other.gameObject.GetComponent<ParticleSystem>();


        if(part.gameObject.name == "Test")
        {
            pivot.transform.localScale += new Vector3(0, +1.0f * Time.deltaTime, 0);
        }





        //int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //int i = 0;

        //while (i < numCollisionEvents)
        //{
        //    if (rb)
        //    {
        //        Vector3 pos = collisionEvents[i].intersection;
        //        Vector3 force = collisionEvents[i].velocity * 10;
        //        rb.AddForce(force);
        //    }
        //    i++;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
