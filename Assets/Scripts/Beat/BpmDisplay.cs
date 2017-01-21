using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BpmDisplay : MonoBehaviour, MasterClock.BeatListener {

	private Text bpmText;

	private bool isColorChange = false;

	// Use this for initialization
	void Start () {
		MasterClock clock = GameObject.FindObjectOfType<MasterClock> ();
		if (clock != null) {
			clock.AddListener (this);
		}
			
		bpmText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void OnBeat(int bpm) {

		bpmText.text = bpm.ToString();

		if (isColorChange) {
			bpmText.color = Color.red;
			isColorChange = !isColorChange;
		} else {
			bpmText.color = Color.black;
			isColorChange = !isColorChange;
		}
	}

}
