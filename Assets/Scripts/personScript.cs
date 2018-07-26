using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personScript : MonoBehaviour {

    public GameObject player;
    bool selected;

	// Use this for initialization
	void Start () {
        player= GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        //print("name "+gameObject.name+Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 0.1f && selected == false)
        {
            player.GetComponent<GhostScript>().target = transform;
            selected = true;
        }
        //Application.LoadLevel(0);
    }
    public Renderer ren;
    public void newChangeColour()
    {
        //print("Colour change");
        //Renderer 
            ren = GetComponentInChildren<Renderer>();
        ren.material.color = Color.red;
    }

    public void ChangeColour()
    {
        Renderer[] rens = GetComponentsInChildren<Renderer>();
       

        foreach(Renderer ren in rens)
        {
            ren.material.color = Color.red;
        }

    }
}
