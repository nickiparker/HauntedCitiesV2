using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonNavMeshPathfinder : MonoBehaviour
{

    public Transform[] destination;
    public int destPoint;
    public bool randomMove;

    void OnEnable()
    {
        NewEventManager.StartListening("Shuffle", moveToNewDestination);

    }

    void OnDisable()
    {
        NewEventManager.StopListening("Shuffle", moveToNewDestination);

    }

    // Use this for initialization
    void Start()
    {
        GameObject[] waypointObj = GameObject.FindGameObjectsWithTag("Waypoint");
        destination = new Transform[waypointObj.Length];
        int num = 0;
        foreach(GameObject obj in waypointObj)
        {
            destination[num] = obj.transform;
            num++;
        }
        destPoint = Random.Range(0, destination.Length);
        GetComponent<PathManager>().NavigateTo(destination[destPoint].position);
    }

    public void moveToRandomPlace()
    {
        //transform.position=destination[Random.Range(0, destination.Length)].position;
        //moveToNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination[destPoint].position) < 0.04f)
        {
            moveToNewDestination();
        }
    }

    void moveToNewDestination()
    {
        if (!randomMove)
        {
            destPoint = (destPoint + 1) % destination.Length;
        }
        else
        {
            //print(destination.Length);
            destPoint = Random.Range(0, destination.Length);
        }
        transform.LookAt(destination[destPoint].position);
        GetComponent<PathManager>().NavigateTo(destination[destPoint].position);
    }
}
