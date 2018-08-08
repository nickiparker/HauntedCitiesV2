using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    public Animator startButton;
    public Animator missionButton;
    public Animator settingsButton;
    public Animator dialog;

    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        missionButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        Screen.SetResolution(1334, 750, true);
        SceneManager.LoadScene("SelectCity");
    }

    public void OpenMission()
    {
        SceneManager.LoadScene("Mission");
    }

    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        missionButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    public Animator startButton;
    public Animator settingsButton;
    public Animator dialog;

    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        Screen.SetResolution(1334, 750, true);
        SceneManager.LoadScene("SelectCity");
    }

    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }
}
