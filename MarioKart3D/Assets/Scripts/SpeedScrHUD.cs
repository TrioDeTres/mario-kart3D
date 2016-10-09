using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScrHUD : MonoBehaviour {
    public GameObject kart;

    private float speed;
    Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        speed = kart.GetComponent<Rigidbody>().velocity.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        //Due to wheel collider speed is 0
        text.text = "Speed: " + speed;
	}
}
