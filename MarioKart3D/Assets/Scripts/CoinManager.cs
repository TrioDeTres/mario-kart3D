using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
	}

    void OnTriggerEnter(Collider col) {
        col.gameObject.GetComponent<KartCointPoints>().coins += 1;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        AppearCoin();
        GetComponentInChildren<MeshRenderer>().enabled = true;
        Debug.Log(col.gameObject.GetComponent<KartCointPoints>().coins);
    }

    IEnumerator AppearCoin()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3.5f);
        GetComponent<Collider>().enabled = false;
    }
}
