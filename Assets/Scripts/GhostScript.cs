using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour {

    public Transform target;
    [SerializeField] float speed;
    public Transform wrldMap;
    public Transform[] locations;
    public Transform heavenPortal;
    Vector3 heavenPortalPos;
    public Text proxText;

	// Use this for initialization
	void Start () {
        wrldMap = transform.parent;
        //StartCoroutine("checkDistance");
    }

    public void setupProximity()
    {
        heavenPortal = GameObject.FindGameObjectWithTag("Finish").transform;
        heavenPortalPos = heavenPortal.position;
        proxText.text = Vector3.Distance(transform.position, heavenPortalPos).ToString();
    }
    

    public GameObject cameraAttach;

    /**
     *  Used purely for debugging camera view
     */
    public void debugCamera()
    {
        
        cameraAttach.transform.parent = this.transform;
        cameraAttach.transform.localPosition = new Vector3(0, 40, 0);
        cameraAttach.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        proxText.text = (Vector3.Distance(transform.position, heavenPortalPos)*50).ToString("n2");
        if (target)
        {
           
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                if (Vector3.Distance(transform.position, target.position) < 0.006f)
                {
                    if (target.tag == "Finish")
                    {
                        
                        Destroy(target);
                        Destroy(gameObject);
                    }
                    else if(target.tag=="Random")
                    {
                        if(locations.Length<1)
                        {
                           
                            GameObject[] locObjs= GameObject.FindGameObjectsWithTag("Waypoint");
                            locations = new Transform[locObjs.Length];
                           
                            for (int i = 0; i < locObjs.Length; i++)
                            {
                                locations[i] = locObjs[i].transform;
                            }
                        }
                        transform.parent = wrldMap;
                        StopCoroutine("countDownToDrop");
                        transform.position = locations[Random.Range(0, locations.Length)].position;
                       
                    }
                    else
                    {
                     

                        transform.parent = target;
                        GetComponentInParent<personScript>().ChangeColour();
                        transform.localPosition = Vector3.zero;
                        //GetComponent<MeshRenderer>().enabled = false;
                        //target.GetComponent<personScript>().changeColour();
                        
                        target = null;
                        StopCoroutine("countDownToDrop");
                        StartCoroutine("countDownToDrop");
                    }
                }
            }
        }
    }

    IEnumerator countDownToDrop()
    {
        yield return new WaitForSeconds(5);
        transform.parent = wrldMap;
    }

    IEnumerator checkDistance()
    {
        yield return new WaitForSeconds(0.5f);
        if (target)
        {
            //if the distance between the target and the ghost is less than 0.5 (may need to look at this distance) move towards
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                //when the distance gets close enough, either finish or merge with the target
                if (Vector3.Distance(transform.position, target.position) < 0.006f)
                {
                    if (target.tag == "Finish")
                    {
                        Destroy(target);
                        Destroy(gameObject);
                    }
                    else
                    {
                        //print(Vector3.Distance(transform.position, target.position));
                        transform.parent = target;
                        transform.localPosition = Vector3.zero;
                        //GetComponent<MeshRenderer>().enabled = false;
                        //target.GetComponent<personScript>().changeColour();
                    }
                }
            }
        }
        StartCoroutine("checkDistance");
    }


}
