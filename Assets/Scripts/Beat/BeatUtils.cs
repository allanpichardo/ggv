using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatUtils {

	public static float BpmToMilliseconds(int bpm) {
		return 60000 / bpm;
	}

}
