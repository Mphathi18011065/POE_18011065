using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public enum State
    {
        PATROL,
        CHASE   
    }
    public State state;
    private bool alive;

    //Variables for patrolling
    public GameObject[] waypoints;
    private int waypointInd;
    public float patrolSpeed = 0.5f;

    //Variables for chasing 
    public float chaseSpeed = 1f;
    public GameObject target;

    //Initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updatePosition = true;
        agent.updateRotation = false;

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        waypointInd = Random.Range(0, waypoints.Length);

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        waypointInd = Random.Range(0, waypoints.Length);

        state = rAi.State.PATROL;

        alive = true;

        StartCoroutine("FSM");
        
    }
    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
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
        }
        else if ((Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2))
        {
            //find a random number between 0 and they array 
            // happens when you egt to the waypoint

            waypointInd = Random.Range(0, waypoints.Length);
        }
        else
        {

        }
    }

    void Chase()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            state = rAi.State.CHASE;
            target = coll.gameObject;
        }

    }


}
