using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeMovement : MonoBehaviour {

	public float speed;

	void Start () {
	}
	
	void FixedUpdate () {
		Vector3 movement = new Vector3 (0.0f, 0.0f, -1);
		transform.Translate (movement * Time.deltaTime * speed);
	}
}
