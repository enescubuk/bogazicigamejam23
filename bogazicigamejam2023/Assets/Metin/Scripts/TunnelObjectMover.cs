using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelObjectMover : MonoBehaviour
{
    public Transform startPoint;    // Start point of the tunnel
    public Transform endPoint;      // End point of the tunnel
    public float speed = 1f;        // Movement speed of the objects

    private float distance;         // Distance between start and end points

    private void Start()
    {
        // Calculate the distance between start and end points
        distance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    private void Update()
    {
        // Move the object along the tunnel
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);

        // Check if the object has reached the end point
        if (transform.position == endPoint.position)
        {
            // Reset the object's position to the start point
            transform.position = startPoint.position;
        }
    }
}
