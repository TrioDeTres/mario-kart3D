using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKartFlag : MonoBehaviour {
    public int flagValue = 0;

    void OnTriggerEnter(Collider col)
    {
        int kartFlagValue = col.gameObject.GetComponent<TriggerFlag>().currentFlagValue;
        if (kartFlagValue < flagValue)
        {
            col.gameObject.GetComponent<TriggerFlag>().currentFlagValue = flagValue;
            Debug.Log("Flag" + flagValue);
        }
        else {
            Debug.Log("Wrong way");
        }
        
    }
}
