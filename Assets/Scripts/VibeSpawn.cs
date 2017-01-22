using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeSpawn : MonoBehaviour, MasterClock.BeatListener {

	public Rigidbody Vibe1;
	public Rigidbody Vibe2;
	public Rigidbody Vibe3;
	public Rigidbody Vibe4;
	public Rigidbody Vibe5;
	public Rigidbody Vibe6;

	public Transform row1;
	public Transform row2;
	public Transform row3;
	public Transform row4;
	public Transform row5;

	private int counter = 0;

	void Start () {
		MasterClock clock = GameObject.FindObjectOfType<MasterClock> ();
		if (clock != null) {
			clock.AddListener (this);
		}
	}

	void Spawn (Rigidbody x, Transform y, Transform z) {
		Instantiate (x, y.position, z.rotation);
	}

	void counterCallback (){
		counter += 1;
		if (counter == 1000) {
			counter = 0;
		}
	}

	Transform randomCoordinates () {
		Transform row = row1;
		var coordinates = Random.Range (1, 6);
		if (coordinates == 1) {
			row = row1;
		} else if (coordinates == 2) {
			row = row2;
		} else if (coordinates == 3) {
			row = row3;
		} else if (coordinates == 4) {
			row = row4;
		} else if (coordinates == 5) {
			row = row5;
		}
		return row;
	}

	Rigidbody randomVibes () {
		Rigidbody vibe = Vibe1;
		var wave = Random.Range (1, 7);
		if (wave == 1) {
			vibe = Vibe1;
		} else if (wave == 2) {
			vibe = Vibe2;
		} else if (wave == 3) {
			vibe = Vibe3;
		} else if (wave == 4) {
			vibe = Vibe4;
		} else if (wave == 5) {
			vibe = Vibe5;
		} else if (wave == 6) {
			vibe = Vibe6;
		}
		return vibe;
	}

	public void OnBeat (int bpm) {
		Spawn (randomVibes(),randomCoordinates(),randomCoordinates());
		counterCallback ();
	}
		
}
	