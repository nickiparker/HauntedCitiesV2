using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{

    public GameObject player;
    bool selected;
    static int numActive;

    MeshRenderer rend;
    BoxCollider coll;

    // Use this for initialization
    void Start()
    {
        rend= gameObject.GetComponent<MeshRenderer>();
        coll= gameObject.GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (gameObject.tag!="Finish")
        {
            rend.enabled = false;
            coll.enabled = false;
            //StartCoroutine("PortalHide");
        }
    }

    IEnumerator PortalHide()
    {
            yield return new WaitForSeconds(Random.Range(15, 25));
            rend.enabled = false;
            coll.enabled = false;       
    }

    public void showPortal()
    {
        StopCoroutine("PortalHide");
        rend.enabled = true;
        coll.enabled = true;
        StartCoroutine("PortalHide");
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //print("name "+gameObject.name+Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 0.15f)
        {
            player.GetComponent<GhostScript>().target = transform;
            
        }
        //Application.LoadLevel(0);
    }

  

}
