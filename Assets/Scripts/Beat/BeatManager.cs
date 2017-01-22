using System;
using UnityEngine;

public class BeatManager : MonoBehaviour, MasterClock.BeatListener, InputManager.InputListener {

    private int beatTimestamp = 0;
    private int currentBpm = 0;
    public float upperLimit = 750f;

    private bool isAcceptingInput = true;


    void Awake() {
        MasterClock clock = GameObject.FindObjectOfType<MasterClock>();
        if (clock != null) {
            clock.AddListener(this);
        }
        InputManager inputManager = GameObject.FindObjectOfType<InputManager>();
        if (inputManager != null) {
            inputManager.AddInputListener(this);
        }
    }

    public void OnBeat(int bpm) {
        beatTimestamp = DateTime.Now.Millisecond;
        currentBpm = bpm;
        Debug.Log(string.Format("Beat:{0}", bpm));

        isAcceptingInput = true;
    }

    public void OnButtonPressed(string keyName, int keyTimestamp) {
        int score = Math.Abs((keyTimestamp - beatTimestamp));
        float lowerLimit = BeatUtils.BpmToMilliseconds(currentBpm)/4;

        if(isAcceptingInput) {
            if (score <= upperLimit && score >= lowerLimit) {
                Debug.Log("In the money!!!!!!!!!!!!!!!!!!");
            }
        }

        isAcceptingInput = false;
    }


}