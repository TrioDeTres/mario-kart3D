using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {
    public GameObject bonus;
    Vector3 position;
    Quaternion rotation;

	// Use this for initialization
	void Start () {
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w) ;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 35 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider col) {
        ShellManager.hitBonus();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(AppearBonus());
        Debug.Log(col.gameObject.GetComponent<KartCointPoints>().coins);
    }

    IEnumerator AppearBonus()
    {
        yield return new WaitForSeconds(3.5f);
        GetComponent<Collider>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}
