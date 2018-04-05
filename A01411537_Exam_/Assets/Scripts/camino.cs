using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camino : MonoBehaviour {
	public Transform inicio;
	public Transform final;
	// Use this for initialization

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (inicio.position,final.position);  //Draw a line
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
