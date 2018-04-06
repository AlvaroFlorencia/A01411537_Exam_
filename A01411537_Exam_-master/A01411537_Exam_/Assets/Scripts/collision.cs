using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	private player colissionplayer;
	// Use this for initialization
	void Start () {
		colissionplayer = GetComponentInParent<player> ();
	}
	void OnCollisionStay2D(Collision2D collision){
		//To elimnate the bug when the in theory the player is falling,make a relationship
		colissionplayer.tocandoPiso = true;
		colissionplayer.transform.parent = collision.transform.parent
			;
		if (collision.gameObject.tag == "plataforma") {
			print ("tocando");
			colissionplayer.transform.parent = collision.transform.parent
				;  //Process of tranform the collision in parent
		}
	}	
	void OnCollisionExit2D(Collision2D collision){ //Eliminate the relationship
		colissionplayer.tocandoPiso = false;
		if (collision.gameObject.tag == "plataforma") {
			colissionplayer.transform.parent = null;
		}
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
