using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo2 : MonoBehaviour {

	public GameObject projectile;

	public float Speed;



	public AudioClip fireSound;                

	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody2D> ();	

	}



	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the enemy is destroyed
			print("yaplease");
			collision.SendMessage ("Enemya2");

		}
		if (collision.gameObject.tag == "diferente") { //If the tag is "diferente" the function "Enemya" is called to remove life of the player
			print("yaplease");
			collision.SendMessage ("Enemya2");

		}
	}


}
