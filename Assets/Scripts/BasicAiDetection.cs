using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicAiDetection : MonoBehaviour
{
   // public NavMeshAgent agent;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Testing the distance between units

        //If the direction is less than 10 units look at each other
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            //Calculating the distance between the units 
            Vector3 direction = player.position - this.transform.position;
            direction.y = 2.75f;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation
                                                    , Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude >5)
            {
                this.transform.Translate(0, 0, 0.5f);
            }
        }
    }
}
