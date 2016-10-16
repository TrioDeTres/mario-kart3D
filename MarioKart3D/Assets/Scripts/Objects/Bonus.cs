using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public event Action<Bonus> OnBonusHit;
    public MeshRenderer         meshRenderer;
    public Collider             bonusCollider;
	void Update ()
    {
        transform.Rotate(0, 35 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Kart")
        {
            if (OnBonusHit != null)
                OnBonusHit(this);
            meshRenderer.enabled = false;
            bonusCollider.enabled = false;
            StartCoroutine(AppearBonus());
        }
    }

    IEnumerator AppearBonus()
    {
        yield return new WaitForSeconds(3.5f);
        meshRenderer.enabled = true;
        bonusCollider.enabled = true;
    }
}
