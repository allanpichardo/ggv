using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Configuration;

public class MasterClock : MonoBehaviour {

	private Timer masterTimer;
	private HashSet<BeatListener> listeners = new HashSet<BeatListener> ();

	public int bpm = 60;
	public bool isEnabled = false;

	private bool isOnset = false;

	int lastBpm;

	bool lastEnabled;

	void Awake() {
		masterTimer = new Timer(BeatUtils.BpmToMilliseconds(bpm));
		masterTimer.Enabled = isEnabled;
		masterTimer.Elapsed += OnTimedEvent;

		lastBpm = bpm;
		lastEnabled = isEnabled;
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (this.lastEnabled != this.isEnabled) {
			Debug.Log ("Enabled: " + isEnabled);
			masterTimer.Enabled = this.isEnabled;
			this.lastEnabled = this.isEnabled;
		}
		if (this.lastBpm != this.bpm) {
			Debug.Log ("BPM Change to: " + bpm);
			masterTimer.Stop ();
			masterTimer.Interval = BeatUtils.BpmToMilliseconds (bpm);
			this.lastBpm = bpm;
			masterTimer.Enabled = isEnabled;
		}

		if (isOnset) {
			dispatchBeatEvent ();
		}

	}

	private void dispatchBeatEvent(){
		Debug.Log("BEAT!");
		foreach(BeatListener listener in listeners) {
			listener.OnBeat (bpm);
		}
		isOnset = false;
	}

	private void OnTimedEvent(System.Object source, System.Timers.ElapsedEventArgs e)
    {
		isOnset = true;
    }

	public void AddListener(BeatListener listener) {
		listeners.Add (listener);
	}

	public interface BeatListener {
		void OnBeat (int bpm);
	}

	public void OnDestroy(){
		masterTimer.Stop ();
	}
}
