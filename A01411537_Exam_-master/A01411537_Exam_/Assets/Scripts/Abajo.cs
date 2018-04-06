using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abajo : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the player reset his initial position

			collision.SendMessage ("position");
		}
		if (collision.gameObject.tag == "diferente") {   //If the tag is "diferente" the player reset his initial position

			collision.SendMessage ("position");

		}
		}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "eliminate") { //If the tag is "eliminate" the projectiles are eliminated
			Destroy(collision.gameObject);
		}

	}


	}

