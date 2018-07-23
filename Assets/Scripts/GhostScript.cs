using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    public Transform target;
    [SerializeField] float speed;
    public Transform wrldMap;

	// Use this for initialization
	void Start () {
        wrldMap = transform.parent;
        //StartCoroutine("checkDistance");
    }

    public GameObject cameraAttach;
    


    public void debugCamera()
    {
        
        cameraAttach.transform.parent = this.transform;
        cameraAttach.transform.localPosition = new Vector3(0, 40, 0);
        cameraAttach.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
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
                    else
                    {
                        //print(Vector3.Distance(transform.position, target.position));
                        transform.parent = target;
                        transform.localPosition = Vector3.zero;
                        //GetComponent<MeshRenderer>().enabled = false;
                        //target.GetComponent<personScript>().changeColour();
                        target = null;
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
