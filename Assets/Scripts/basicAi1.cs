using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class basicAi1 : MonoBehaviour
{
    /*
    public NavMeshAgent agent;
    
    //Add units here

    public enum State
    {
     PATROL,
     CHASE
    }

    public State state;
    private bool alive;

    //variables for patrolling
    public GameObject[] waypoints;
    private int waypointInd = 0;
    public float patrolSpeed = 0.5f;

    //VAriables for chasing 
    public float chaseSpeeed = 1f;
    public GameObject traget;

    //use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Unit here 

        agent.updatePosition = true;
        agent.updateRotation = true;

        state = basicAi1.State.PATROL;
        alive = true;
    }
    IEnumerable FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
    void Patrol()
    {
        agent.speed = patrolSpeed;
        if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2) 
        {
            agent.SetDestination(waypoints[waypointInd].transform.position);
            //character.Move (agent.desiredVelocity , false , false);
            
        }
    }
    */

    public float Speed;
    private float waitTime;
    public float startWaitTime;

    public Transform waypoints;
    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;





     void Start()
    {
       // waitTime = startWaitTime;
        waypoints.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
     
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints.position, Speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints.position) < 0.2f)
        {
                waypoints.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
          
        }
    }


}
