﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private LevelManager levelManagerScript;                       //Store a reference to our LevelManager which will set up the level.
    private int level = 1;                                  //Current level number
    public GameObject playerPrefab;


	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}
		//If instance already exists and it's not this:
		else if (instance != this)
		{            
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		//Get a component reference to the attached LevelManager script
		levelManagerScript = GetComponent<LevelManager>();        
        //Call the InitGame function to initialize the first level 
        InitGame();

	}

	//Initializes the game for each level.S
	void InitGame()
	{
		//Call the SetupScene function of the LevelManager script, pass it current level number.
		levelManagerScript.SetupScene(level);

        //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current position cast it to GameObject.
        Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity);

	}

	//Update is called every frame.
	void Update()
	{
        // check player movement
        // check if game won
        // check if player killed
        // check to see if we need to end the level
        // check to see if we need to begin the next level
        // check to see if we need to end the game
    }

}
