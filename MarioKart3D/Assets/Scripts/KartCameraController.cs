using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCameraController : MonoBehaviour {

    public Transform kartCenterOfMass;
    public float damping = 1.0f;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - kartCenterOfMass.position;
        transform.rotation = kartCenterOfMass.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = kartCenterOfMass.position + offset;

        Vector3 relativePos = kartCenterOfMass.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping * Time.deltaTime);
	}
}
