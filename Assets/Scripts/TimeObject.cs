using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeObject : MonoBehaviour
{
    private bool isRewinding = false;
    
    [SerializeField] private float recordTime = 10f;

    List<PointPositionInTime> pointsInTime;
    Rigidbody rb;

    private void Start()
    {
        pointsInTime = new List<PointPositionInTime>();
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointPositionInTime(transform.position, transform.rotation));
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointPositionInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }
}
