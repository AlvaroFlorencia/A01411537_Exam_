using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {
	public Transform bob;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Vectorx = Mathf.Clamp (bob.position.x, -7.1f, 210f); //limited to the scene
		transform.position = new Vector3 (Vectorx + offset.x, bob.position.y + offset.y+.05f, offset.z-3f); //Follow the player
	}
}
