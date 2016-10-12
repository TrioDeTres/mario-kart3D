using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 35 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider col) {
        ShellManager.hitBonus();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        AppearBonus();
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    IEnumerator AppearBonus()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5.0f);
        GetComponent<Collider>().enabled = true;
        
    }
}
