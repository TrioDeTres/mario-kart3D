using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoBehaviour {
    public static List<GameObject> shells;
    public static List<Transform> transforms;
    public static GameObject blueShell;
    public GameObject shell;
    public Transform auxTrasnform;

	// Use this for initialization
	void Start () {
        shells = new List<GameObject>();
        transforms = new List<Transform>() { auxTrasnform , auxTrasnform , auxTrasnform };
        blueShell = shell;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        for (int i = 0; i < shells.Count; i++) {
            shells[i].transform.RotateAround(transform.position, Vector3.up, (40 + (i * 10)) * Time.deltaTime);
        }
	}

    public static void hitBonus() {
        if (shells.Count == 0) {
            for (int i = 0; i < 3; i++) {
                shells.Add(Instantiate(blueShell));
                shells[i].transform.position = transforms[i].position;
                shells[i].transform.rotation = transforms[i].rotation;
            }
        }
        
    }
}
