using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Configuration;

public class MasterClock : MonoBehaviour {

	private Timer masterTimer;
	private HashSet<BeatListener> listeners;

	private int lastBpm = 60;
	private bool lastEnabled = false;

	public int bpm = 60;
	public bool isEnabled = false;

	// Use this for initialization
	void Start () {
		listeners = new HashSet<BeatListener> ();
		masterTimer = new Timer(BeatUtils.BpmToMilliseconds(bpm));
		masterTimer.Enabled = isEnabled;
		masterTimer.Elapsed += OnTimedEvent;

		lastBpm = bpm;
		lastEnabled = isEnabled;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lastEnabled != isEnabled) {
			Debug.Log ("Enabled: " + isEnabled);
			masterTimer.Enabled = isEnabled;
			lastEnabled = isEnabled;
		}
		if (lastBpm != bpm) {
			Debug.Log ("BPM Change to: " + bpm);
			masterTimer.Stop ();
			masterTimer.Interval = BeatUtils.BpmToMilliseconds (bpm);
			lastBpm = bpm;
		}

	}

	private void OnTimedEvent(System.Object source, System.Timers.ElapsedEventArgs e)
    {
        Debug.Log("BEAT!");
		foreach(BeatListener listener in listeners) {
			listener.OnBeat (bpm);
		}
    }

	public void AddListener(BeatListener listener) {
		listeners.Add (listener);
	}

	public interface BeatListener {
		void OnBeat (int bpm);
	}
}
