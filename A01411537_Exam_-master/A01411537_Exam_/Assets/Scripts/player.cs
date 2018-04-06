using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public float speed = 2.0f;   //to set the speed
	public float maxSpeed=5.0f;
	private Rigidbody2D rigidbody; 
	public bool tocandoPiso;
	public bool agache;  //bools to start the animations
	public bool ataque;
	public score sc; //score
	private SpriteRenderer sprite; //To modify the sprite
	public int vida=6;  //set the life
	private LevelManager levelManager;
	public Animator animator;  
	public float brinco =7.0f; //To set the impulse
	public Text vidas;


	// Use this for initialization
	void Start () {  //Get the components
		rigidbody = GetComponent<Rigidbody2D> ();
		sprite =GetComponent<SpriteRenderer> ();
		levelManager = FindObjectOfType<LevelManager>(); 
		sc = FindObjectOfType<score> ();
	}

	// Update is called once per frame
	void Update () {
		if (vida <= 0) {  // Difference text,  of the life's player ,to represent the life
			levelManager.LoadLevel("Lose");
		}
		else if(vida == 1){
			vidas.text="♥";
		}
		else if(vida == 2){
			vidas.text="♥♥";
		}
		else if(vida == 3){
			vidas.text="♥♥♥";
		}
		else if(vida == 4){
			vidas.text="♥♥♥♥";
		}
		else if(vida ==5){
			vidas.text="♥♥♥♥♥";
		}
		else if(vida ==6){
			vidas.text="♥♥♥♥♥♥";
		}
		else if(vida ==7){
			vidas.text="♥♥♥♥♥♥♥";
		}
		//the animations are related to a variables
		animator=GetComponent<Animator>();
		animator.SetFloat ("Speed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetBool ("piso", tocandoPiso);
		animator.SetBool ("Disparando", ataque);
		animator.SetBool ("agachando", agache);

	

	}

	void FixedUpdate(){

		float a= Input.GetAxis("Horizontal");//Saved 1 to -1 in the vertical moves
		float b= Input.GetAxis("Vertical");//Saved 1 to -1 in the horizontal moves
		rigidbody.AddForce(Vector2.right*speed*a);
		if (rigidbody.velocity.x > maxSpeed) {
			rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y); //level the speed
		} 
		if (rigidbody.velocity.x < -maxSpeed) {
			rigidbody.velocity = new Vector2 (-maxSpeed, rigidbody.velocity.y);
		} 

		if (b > 0f && tocandoPiso==true) { //to start the animation jump
			tocandoPiso = false;
			rigidbody.AddForce (Vector2.up * brinco, ForceMode2D.Impulse);

		}
		if (b < 0f && tocandoPiso==true) { //to start the animation "duck move"
			agache = true;

		}
		if (b == 0) {
			agache = false;
		}

		if (b <0f) {
			tocandoPiso = true;


		}
		if (Input.GetKey (KeyCode.Space)) { //to start the animation "attack"

			ataque = true;
			rigidbody.tag="Player";

		} else {
			ataque = false;
			rigidbody.tag="diferente";
		}
		if (a > 0f) {
			transform.localScale = new Vector3 (1f,1f, 1f);  //transmform the local scale
		}
		if (a <0f) {
			print ("cambiando");
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}



	}
	public void Enemya2(){ //subtract life and gain impulse
		vida--;


		rigidbody.AddForce(Vector2.up*speed*90f);
		rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);


	}



	public void Enemya(){
		vida--;


		rigidbody.AddForce(Vector2.up*speed*20f);
		rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);

	
	}


	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "damaged") { //If the tag is "damaged" the enemy is destroyed
			
			Enemya ();
		}
	}
	public void position(){ //restart the position
		vida--;
		transform.position = new Vector3 (-5.3f,-0.02f, 0f);
	}
	public void plus(){
		vida++;

	}

	public void subirScore() //the score is increased
	{
		sc.gainPoints ();
		levelManager.score++; //Score++
	}
}
