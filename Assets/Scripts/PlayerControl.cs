using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public Text countText;
	private Rigidbody rb;
	private int count;

	void Start () {
		count = 0;
		rb = GetComponent<Rigidbody> ();
		SetCountText ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Vibe")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString();
		}

}