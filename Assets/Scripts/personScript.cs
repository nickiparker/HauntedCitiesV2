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
        print("name "+gameObject.name+Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < 1 && selected == false)
        {
            player.GetComponent<GhostScript>().target = transform;
            selected = true;
        }
        //Application.LoadLevel(0);
    }

    public void changeColour()
    {
        Renderer[] rens = GetComponentsInChildren<Renderer>();
        Material[] mats = new Material[rens.Length];

        int i = 0;

        foreach(Renderer ren in rens)
        {
            mats[i] = ren.material;
        }

        foreach (Material mat in mats)
        {
            if (mat.color == Color.white)
            {
                mat.color = Color.red;
            }
            else
            {
                mat.color = Color.white;
            }
        }
    }
}
