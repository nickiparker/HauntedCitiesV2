using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
