using System.Collections;
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
        StartCoroutine(CheckrStation());
    }

    IEnumerator CheckrStation()
    {
        yield return new WaitForSeconds(2.5f);
        if (rb.velocity == Vector3.zero)
        {
            boxesCheker.AddPrepareBox();
        }
        else
        {
            boxesCheker.UnPrepare();
        }
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(CheckrStation());
    }
}
