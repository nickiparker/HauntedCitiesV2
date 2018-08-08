﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Modified version of script provided by trickyfast studios to manage navigation between a set path using waypoint system
 * */

public class PathManager : MonoBehaviour
{
	public float walkSpeed = 5.0f;

    public Stack<Vector3> currentPath;
	public Vector3 currentWaypointPosition;
    public float moveTimeTotal;
    public float moveTimeCurrent;

	public void NavigateTo(Vector3 destination)
	{
		currentPath = new Stack<Vector3> ();
		var currentNode = FindClosestWaypoint (transform.position);
		var endNode = FindClosestWaypoint (destination);
		if (currentNode == null || endNode == null || currentNode == endNode)
			return;
		var openList = new SortedList<float, Waypoint> ();
		var closedList = new List<Waypoint> ();
		openList.Add (0, currentNode);
		currentNode.previous = null;
		currentNode.distance = 0f;
		while (openList.Count > 0)
		{
			currentNode = openList.Values[0];
			openList.RemoveAt (0);
			var dist = currentNode.distance;
			closedList.Add (currentNode);
			if (currentNode == endNode)
			{
				break;
			}
			foreach (var neighbor in currentNode.neighbors)
			{
				if (closedList.Contains (neighbor) || openList.ContainsValue (neighbor))
					continue;
				neighbor.previous = currentNode;
				neighbor.distance = dist + (neighbor.transform.position - currentNode.transform.position).magnitude;
				var distanceToTarget = (neighbor.transform.position - endNode.transform.position).magnitude;
				openList.Add (neighbor.distance + distanceToTarget, neighbor);
			}
		}
		if (currentNode == endNode)
		{
			while (currentNode.previous != null)
			{
				currentPath.Push (currentNode.transform.position);
				currentNode = currentNode.previous;
			}
			currentPath.Push (transform.position);
		}
	}

	public void Stop()
	{
		currentPath = null;
		moveTimeTotal = 0;
		moveTimeCurrent = 0;
	}

	void Update()
	{
		if (currentPath != null && currentPath.Count > 0)
		{
			if (moveTimeCurrent < moveTimeTotal)
			{
				moveTimeCurrent += Time.deltaTime;
				if (moveTimeCurrent > moveTimeTotal)
					moveTimeCurrent = moveTimeTotal;
				transform.position = Vector3.Lerp (currentWaypointPosition, currentPath.Peek (), moveTimeCurrent / moveTimeTotal);
			} else
			{
				currentWaypointPosition = currentPath.Pop ();
				if (currentPath.Count == 0)
					Stop ();
				else
				{
					moveTimeCurrent = 0;
					moveTimeTotal = (currentWaypointPosition - currentPath.Peek ()).magnitude / walkSpeed;
				}
			}
		}
	}

	private Waypoint FindClosestWaypoint(Vector3 target)
	{
		GameObject closest = null;
		float closestDist = Mathf.Infinity;
		foreach (var waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
		{
			var dist = (waypoint.transform.position - target).magnitude;
			if (dist < closestDist)
			{
				closest = waypoint;
				closestDist = dist;
			}
		}
		if (closest != null)
		{
			return closest.GetComponent<Waypoint> ();
		}
		return null;
	}


    void OnEnable()
    {
        NewEventManager.StartListening("speedUp", speedUp);
    }

    void OnDisable()
    {
        NewEventManager.StopListening("speedUp", speedUp);
    }

    /**
     * Called when speed up power up is triggered
     */

    public void speedUp()
    {
        walkSpeed *= 1.2f;
    }

}
