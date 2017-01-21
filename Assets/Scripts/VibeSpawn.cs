using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeSpawn : MonoBehaviour, MasterClock.BeatListener {

	public Rigidbody Vibe;
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

	void Spawn (Transform x, Transform y) {
		Instantiate (Vibe, x.position, y.rotation);
	}

	public void OnBeat (int bpm) {
		if (counter % 4 == 0) {
			Spawn (row1, row1);
		} else if (counter % 6 == 0) {
			Spawn (row4, row4);
		} else if (counter % 6 == 0 && counter % 4 == 0) {
			Spawn (row3, row3);
		}
		counter += 1;
	}
		
}
	