﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    private BoxesCheker boxesCheker;
    private Rigidbody rb;

    public void Start()
    {
        boxesCheker = FindObjectOfType<BoxesCheker>();
        rb = GetComponent<Rigidbody>();
    }
    public IEnumerator CheckStation()
    {
        if (rb.velocity == Vector3.zero)
        {
            boxesCheker.AddPrepareBox();
        }
        else
        {
            boxesCheker.UnPrepare();
        }
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(CheckStation());
    }
}
