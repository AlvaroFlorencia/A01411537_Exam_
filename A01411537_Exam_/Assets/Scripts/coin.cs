using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the enemy is destroyed
			collision.SendMessage ("Scoreplayer");
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "diferente") {  //If the tag is "diferente" the function "Enemya" is called to remove life of the player
			Destroy (gameObject);
			collision.SendMessage ("Scoreplayer");


		}


	}
}
