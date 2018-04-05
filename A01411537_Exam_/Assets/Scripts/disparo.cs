using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour {

	public GameObject projectile;

	public float Speed;

	public float x;
	public float y;
	public float shotsPerSeconds = 0.5f;
	public float projectileSpeed = 10f;
	public AudioClip fireSound;                

	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		
		rigidbody = GetComponent<Rigidbody2D> ();	

	}


	void Fire () {

		GameObject missile = Instantiate (projectile, transform.position *x+Vector3.left*y, Quaternion.identity) as GameObject; //Insantiate the missile
		rigidbody = missile.gameObject.GetComponent<Rigidbody2D> (); //Detect the rigidbody
		rigidbody.velocity = new Vector2 (1, -projectileSpeed); //initialize the velocity
		AudioSource.PlayClipAtPoint (fireSound, transform.position);//Play the audioclip
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the enemy is destroyed
			
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "diferente") { //If the tag is "diferente" the function "Enemya" is called to remove life of the player
			print("tocandome");
			collision.SendMessage ("Enemya");

		}
	}

	// Update is called once per frame
	void Update () {

		float probability = shotsPerSeconds * Time.deltaTime; //Initialize the probability


		if (Random.value <= probability) { //If the random value is less than the probability,then fire
			Fire ();
		}

	}

}
