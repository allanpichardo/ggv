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

	public void OnBeat (int bpm) {
		if (counter % 4 == 0) {
			Spawn (Vibe1, row1, row1);
		} else if (counter % 6 == 0) {
			Spawn (Vibe4, row4, row4);
		} else if (counter % 6 == 0 && counter % 4 == 0) {
			Spawn (Vibe3, row3, row3);
		}
		counter += 1;
	}
		
}
	