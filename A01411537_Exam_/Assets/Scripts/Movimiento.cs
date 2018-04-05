using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	public Transform puntero;
	public float Speed;
	private Vector3 inicio,final;

	// Use this for initialization
	void Start () {
		puntero.parent = null; //To elimante the "follow"
		inicio=transform.position; //Indicate the beginning
		final = puntero.position; //Indicate the end

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate ()
	{
		float time2 = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, puntero.position, time2); //Indicates the movement
		if (transform.position == puntero.position) { //If the position of this object is the same as that of the pointer
			if (puntero.position == inicio) { 
				transform.localScale = new Vector3 (1f,1f, 1f);
				//If the pointer is in the beginning
				puntero.position = final; //Change the position to follow, to the position "final"
			} else {
				transform.localScale = new Vector3 (-1f,1f, 1f);
				puntero.position = inicio;
				//If not ,change the position to follow, to the position "beginning"
			}
		}
	}
}
