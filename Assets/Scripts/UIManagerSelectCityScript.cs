using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerSelectCityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Replaced direct reference with integer reference meaning code can be reused across buttons by changing number in UI
     */

    public void StartGame(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
