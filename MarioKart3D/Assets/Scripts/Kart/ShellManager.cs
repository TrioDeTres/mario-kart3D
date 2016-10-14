using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoBehaviour {
    public static List<GameObject> shells;
    public static GameObject blueShell;  
    //Kart as center object
    public static Transform centerOfKart;
    public static float radius = 2.0f;

    public GameObject shell;
    public Vector3 desiredPos;
    public float radiusSpeed = 40.0f;
    public float rotationSpeed = 80.0f;

    // Use this for initialization
    void Start () {
        shells = new List<GameObject>();
        blueShell = shell;
        centerOfKart = GameObject.FindGameObjectWithTag("Kart").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        for (int i = 0; i < shells.Count; i++) {
            shells[i].transform.RotateAround(centerOfKart.position, Vector3.up, (rotationSpeed + (i * 10)) * Time.deltaTime);
            desiredPos = (shells[i].transform.position - centerOfKart.position).normalized * radius + centerOfKart.position;
            shells[i].transform.position = Vector3.MoveTowards(shells[i].transform.position, desiredPos, radiusSpeed * Time.deltaTime);
        }
        desiredPos = Vector3.zero;
	}

    public static void hitBonus() {
        if (shells.Count == 0) {
            for (int i = 0; i < 3; i++) {
                shells.Add(Instantiate(blueShell));
                shells[i].transform.position = (shells[i].transform.position - centerOfKart.position).normalized * radius + centerOfKart.position;
            }
        }
        
    }
}
