using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlag : MonoBehaviour {
    public int maxFlagValue;
    public static int currentFlagValue = 0;
    public static int laps = 0;
	
	// Update is called once per frame
	void Update () {
        if (currentFlagValue != 0 && currentFlagValue >= maxFlagValue) {
            currentFlagValue = 0;
            laps++;
        }
	}
}
