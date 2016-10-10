using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHUD : MonoBehaviour {
    public GameObject kart;

    public static int coins;
    Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "X  " + coins;
    }
}
