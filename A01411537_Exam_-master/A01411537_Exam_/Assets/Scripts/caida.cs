using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caida : MonoBehaviour {
	public Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("diferente")){ //If this player's tag is diferente, kinematic is false
			rigidbody.isKinematic=false;
		}
		if(collision.gameObject.CompareTag("damaged")){ //to destroy the plataform
			Destroy (gameObject);
		}
			
	}

}
