    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackRunTest : MonoBehaviour {

    /**
     * Uses the PathManager to run a lap continuously using waypoint based system.
     * Also keeps track of distance travelled across the laps to convert between metres and miles.
     */

    public Transform[] destination;
    public int destPoint;

    public float lapStartTime;
    public float lapEndTime;
    float distance = 0;
    int lapCounter;
    //public TMPro.TextMeshProUGUI lapText;

    bool lapPast;

    // Use this for initialization
    void Start () {
        GetComponent<PathManager>().NavigateTo(destination[destPoint].position);
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position,destination[destPoint].position)<0.2)
        {
            destPoint = (destPoint + 1) % destination.Length;
            transform.LookAt(destination[destPoint].position);
            GetComponent<PathManager>().NavigateTo(destination[destPoint].position);
        }

        if (destPoint == 0)
        {
            lapStartTime = Time.time;
            lapPast = false;
            //print(lapEndTime);
        }
        else if (destPoint == 3)
        {
            if (lapPast == false)
            {
                lapCounter++;
                lapPast = true;
            }
            lapEndTime = Time.time;
            
        }
        //speed * time
        distance += (400 / 16.1f) * Time.deltaTime;
        distance = Mathf.Round(distance*100);
        distance /= 100;
        print("distance in miles" + (((distance / 1000) * 5) / 8).ToString("n1"));
        //lapText.text="Lap " + lapCounter + "\n Miles Ran: " + ((((distance)*(5))/8)/1000).ToString("n2");
    }
}
