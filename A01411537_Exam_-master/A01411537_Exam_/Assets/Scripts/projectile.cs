using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectile : MonoBehaviour {

	// Use this for initialization
	float damage=200f;
	public float x;
	public float y;

		void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (x, y, 0);//initialize a speed in y

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -30f) {
			Destroy (gameObject);
		}

	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") {
			
		
			Destroy (gameObject);

		}
		if (collision.gameObject.tag == "diferente") {   //The projectile is destroyed and the "Enemya" function is called to remove the player's life
	
			collision.SendMessage ("Enemya");

			Destroy (gameObject);



		}
		if (collision.gameObject.tag == "damaged") {//Destroy the projectile with this tag
	
		
			Destroy (gameObject);


		}
		if (collision.gameObject.tag == "plataforma") {//Destroy the projectile  with this tag

		
			Destroy (gameObject);
		

		}


	}




}
