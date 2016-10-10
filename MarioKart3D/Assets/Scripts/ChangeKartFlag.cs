using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKartFlag : MonoBehaviour {
    public int flagValue = 0;

    void OnTriggerEnter(Collider col)
    {
        if (TriggerFlag.currentFlagValue <= flagValue && TriggerFlag.currentFlagValue != flagValue)
        {
            TriggerFlag.currentFlagValue = flagValue;
            Debug.Log("Flag " + flagValue + " current " + TriggerFlag.currentFlagValue);
        }
        else {
            Debug.Log("Wrong way");
        }
        
    }
}
