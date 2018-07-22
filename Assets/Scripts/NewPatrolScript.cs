using UnityEngine;
using System.Collections;

public class NewPatrolScript : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool randomPatrol;
    public bool chasingPlayer;
    public GameObject player;
    public Transform[] heals;
    public bool healing=false;
    public float distanceToChange;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GameObject[] pointsObj = GameObject.FindGameObjectsWithTag("Waypoint");
        points = new Transform[pointsObj.Length];
        int j = 0;
        foreach (GameObject point in pointsObj)
        {
            points[j] = point.transform;
            j++;
        }
        GotoNextPoint();
    }

    public void chasePlayer()
    {
        
    }

    public void goToHeal()
    {
        healing = true;
        chasingPlayer = false;
        Transform closestHeal;
        // Returns if no points have been set up
        if (heals.Length == 0)
            return;

        closestHeal = heals[0].transform;
        // Set the agent to go to the currently selected destination.
        for (int i = 1; i < heals.Length;i++ )
        {
            if((Vector3.Distance(this.transform.position, heals[i].transform.position))
                <(Vector3.Distance(this.transform.position, closestHeal.position)))
            {
                closestHeal = heals[i].transform; 
            }
        }
            agent.destination = closestHeal.position;
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if (randomPatrol)
        {
            agent.destination = points[Random.Range(0,points.Length)].position;
        }
        else
        {
            agent.destination = points[destPoint].position;
        }
            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < distanceToChange && !chasingPlayer&&!healing)
        {
            GotoNextPoint();
        }

        else if(chasingPlayer)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (healing && agent.remainingDistance < 0.2f)
        {
            healing = false;
            GotoNextPoint();
        }
    }
}

