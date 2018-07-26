using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour {

    public GameObject[] portals;

	// Use this for initialization
	void Start () {
		
	}

    public void startPortals()
    {
        print("portalstart");
        portals = GameObject.FindGameObjectsWithTag("Random");
        StartCoroutine("swapPortals");
    }

    IEnumerator swapPortals()
    {
        yield return new WaitForSeconds(20);
        generateRandomNumbers();
        portals[ranNum1].GetComponent<portalScript>().showPortal();
        portals[ranNum2].GetComponent<portalScript>().showPortal();
        StartCoroutine("swapPortals");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    int ranNum1;
    int ranNum2;

    public void generateRandomNumbers()
    {
        ranNum1 = Random.Range(0, portals.Length);
        ranNum2 = Random.Range(0, portals.Length);
        while (ranNum2 == ranNum1)
        {
            ranNum2=Random.Range(0, portals.Length);
        }
    }


    private int[] intArray;

    private void RandomUnique()
    {
        intArray = new int[portals.Length];
        for (int i = 0; i < portals.Length; i++)
        {
            intArray[i] = i;
        }
        Shuffle(intArray);
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }
}
