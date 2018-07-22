using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawnBreadcrumbs : MonoBehaviour {

    public GameObject thingToSpawn;

	// Use this for initialization
	void Start () {
        Vector3 point1 = RandompointsAroundWaypoint(250);
        Vector3 point2 = RandompointsAroundWaypoint(500);
        Vector3 point3 = RandompointsAroundWaypoint(150);

        GameObject sphere1 = (GameObject.CreatePrimitive(PrimitiveType.Sphere));
        GameObject sphere2 = (GameObject.CreatePrimitive(PrimitiveType.Sphere));
        GameObject sphere3 = (GameObject.CreatePrimitive(PrimitiveType.Sphere));

        sphere1.transform.position = point1;
        sphere2.transform.position = point2;
        sphere3.transform.position = point3;

        sphere1.name = "1";
        sphere2.name = "2";
        sphere3.name = "3";

        sphere1.GetComponent<Renderer>().material.color = Color.red;
        sphere2.GetComponent<Renderer>().material.color = Color.blue;
        sphere3.GetComponent<Renderer>().material.color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 RandompointsAroundWaypoint(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
