using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour, MasterClock.BeatListener {

	public int steps = 8;
	public Transform buttonPrefab;

	private Transform[] buttons;
	private int currentStep = 0;

	void Awake() {
		MasterClock clock = GameObject.FindObjectOfType<MasterClock> ();
		if (clock != null) {
			clock.AddListener (this);
		}
	}

	private Vector3 GetPositionAtStep(int step) {
		Vector3 panelPosition = transform.position;
		float emptySpace = GetAvailableEmptySpace ();
		float buttonWidth = ((RectTransform)buttonPrefab.transform).rect.width;
		float x = emptySpace + step * (emptySpace + buttonWidth);

		return new Vector3 (x, panelPosition.y, 0);
	}

	private float GetAvailableEmptySpace() {
		float totalWidth = ((RectTransform)transform).rect.width;
		float buttonWidth = ((RectTransform)buttonPrefab.transform).rect.width;

		return (totalWidth - (buttonWidth * steps)) / (steps + 1);
	}

	// Use this for initialization
	void Start () {
		buttons = new Transform[steps];
		for (int i = 0; i < steps; ++i) {
			buttons [i] = Instantiate (buttonPrefab, GetPositionAtStep (i), Quaternion.identity);
			GetButtonImage (i).SetButton (ButtonImage.Button.A);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private ButtonImage GetButtonImage(int index) {
		return buttons [index].GetComponent<ButtonImage> ();
	}

	public void OnBeat(int bpm) {
		int onStep = currentStep % steps;
		int offStep = (currentStep - 1) % steps;

		GetButtonImage (onStep).SetHighlight (true);
		GetButtonImage (offStep).SetHighlight (false);

		currentStep = (currentStep + 1) % steps;
	}

}
