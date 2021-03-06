﻿using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> OnCoinHit;

    public MeshRenderer meshRenderer;
    public Collider coinCollider;
    public float rotSpeed = 180f;

    void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Kart")
        {
            meshRenderer.enabled = false;
            coinCollider.enabled = false;
            if (OnCoinHit != null)
                OnCoinHit(this);
            StartCoroutine(AppearCoin());
        }
    }

    IEnumerator AppearCoin()
    {
        yield return new WaitForSeconds(3.5f);
        GetComponent<Collider>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}
