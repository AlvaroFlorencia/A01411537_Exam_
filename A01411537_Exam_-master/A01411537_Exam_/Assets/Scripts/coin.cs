using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
	score points;
	public int plus=1;
	// Use this for initialization
	void start(){

	}
	void OnTriggerEnter2D(Collider2D collision){



		if (collision.gameObject.tag == "Player") { //If the tag is "Player"  the function of the collission(Player) is called to increase the score 
			 collision.gameObject.GetComponent<player>().subirScore();
				Destroy(gameObject);
				
			}
		if (collision.gameObject.tag == "diferente") {  //If the tag is "diferente"  the function of the collission(Player) is called to increase the score 
			collision.gameObject.GetComponent<player>().subirScore();
				Destroy(gameObject);
				

			}




		}



}
