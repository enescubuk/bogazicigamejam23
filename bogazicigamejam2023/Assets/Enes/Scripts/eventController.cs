using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventController : MonoBehaviour
{
    public UnityEvent myEvent;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myEvent.Invoke();
        }
    }
}
