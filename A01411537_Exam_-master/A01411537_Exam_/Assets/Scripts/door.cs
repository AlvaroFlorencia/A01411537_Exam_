﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" load next level
			
			 levelManager.LoadNextLevel();
		}
		if (collision.gameObject.tag == "diferente") {  //If the tag is "diferente" ,load next level
			
		 levelManager.LoadNextLevel();


		}


	}
}
