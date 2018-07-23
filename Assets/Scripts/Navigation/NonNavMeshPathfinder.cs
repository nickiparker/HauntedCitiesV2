using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonNavMeshPathfinder : MonoBehaviour
{

    /**
     * Uses the PathManager to run a lap continuously using waypoint based system.
     * Also keeps track of distance travelled across the laps to convert between metres and miles.
     */

    public Transform[] destination;
    public int destPoint;
    public bool randomMove;



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

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination[destPoint].position) < 0.1)
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
}
