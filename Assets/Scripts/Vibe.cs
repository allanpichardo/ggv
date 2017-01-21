using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibe : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		Vector3 movement = new Vector3 (0.0f, 0.0f, -1);
		transform.Translate (movement * Time.deltaTime * speed);
	}
}
