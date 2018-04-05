using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public float speed = 2.0f;
	public float maxSpeed=5.0f;
	private Rigidbody2D rigidbody;
	public bool tocandoPiso;
	public bool telarana;
	public bool agache;
	public bool ataque;
	public int score=0;
	public GameObject projectile;
	private SpriteRenderer sprite;
	public int vida=6;
	private LevelManager levelManager;
	public float projectileSpeed;
	public Animator animator;
	public float brinco =7.0f;
	public float firingRate = 0.2f;
	public Text vidas;
	public Text scores;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		sprite =GetComponent<SpriteRenderer> ();
		levelManager = FindObjectOfType<LevelManager>(); 

	}

	// Update is called once per frame
	void Update () {
		if (vida <= 0) {
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

		animator=GetComponent<Animator>();
		animator.SetFloat ("Speed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetBool ("piso", tocandoPiso);
		animator.SetBool ("Disparando", ataque);
		animator.SetBool ("agachando", agache);

	

	}

	void FixedUpdate(){

		float a= Input.GetAxis("Horizontal");
		float b= Input.GetAxis("Vertical");//Saved 1 to -1 in the horizontal moves
		rigidbody.AddForce(Vector2.right*speed*a);
		if (rigidbody.velocity.x > maxSpeed) {
			rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);
		} 
		if (rigidbody.velocity.x < -maxSpeed) {
			rigidbody.velocity = new Vector2 (-maxSpeed, rigidbody.velocity.y);
		} 

		if (b > 0f && tocandoPiso==true) {
			tocandoPiso = false;
			rigidbody.AddForce (Vector2.up * brinco, ForceMode2D.Impulse);

		}
		if (b < 0f && tocandoPiso==true) {
			agache = true;

		}
		if (b == 0) {
			agache = false;
		}

		if (b <0f) {
			tocandoPiso = true;


		}
		if (Input.GetKey (KeyCode.Space)) {

			ataque = true;
			rigidbody.tag="Player";

		} else {
			ataque = false;
			rigidbody.tag="diferente";
		}
		if (a > 0f) {
			transform.localScale = new Vector3 (1f,1f, 1f);
		}
		if (a <0f) {
			print ("cambiando");
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}



	}
	public void Enemya2(){
		vida--;


		rigidbody.AddForce(Vector2.up*speed*90f);
		rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);


	}



	public void Enemya(){
		vida--;


		rigidbody.AddForce(Vector2.up*speed*20f);
		rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);

	
	}
	public void Scoreplayer(){
		score++;
		string s = score.ToString();
		scores.text = "SCORE: "+s;
	}
	void OnCollisionEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "damaged") { //If the tag is "Player" the enemy is destroyed
			
			Enemya ();
		}
	}
	public void position(){
		vida--;
		transform.position = new Vector3 (-5.3f,-0.02f, 0f);
	}
	public void plus(){
		vida++;

	}

}
