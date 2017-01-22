using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImage : MonoBehaviour {

	public enum Button : int {
		A, B, X, Y
	};

	public Sprite spriteA;
	public Sprite spriteB;
	public Sprite spriteX;
	public Sprite spriteY;

	private Image image;

	void Awake() {
		image = GetComponent<Image> ();
	}

	// Use this for initialization
	void Start () {
		SetHighlight (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHighlight(bool highlightOn) {
		image.color = highlightOn ? new Color (1, 1, 1, 1) : new Color (1, 1, 1, 0.3f);
	}

	public void SetButton(Button button) {
		switch (button) {
		case Button.A:
			image.sprite = spriteA;
			break;
		case Button.B:
			image.sprite = spriteB;
			break;
		case Button.X:
			image.sprite = spriteX;
			break;
		case Button.Y:
			image.sprite = spriteY;
			break;
		}
	}
}
