using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeSpawn : MonoBehaviour, MasterClock.BeatListener {

	public Rigidbody Vibe;
	public Transform row;
	private int counter = 0;

	void Start () {
		MasterClock clock = GameObject.FindObjectOfType<MasterClock> ();
		if (clock != null) {
			clock.AddListener (this);
		}
	}

	public void OnBeat (int bpm) {
		if (counter % 4 == 0) {
			Instantiate (Vibe, row.position, row.rotation);
		}
		counter += 1;
	}
		
	}
	