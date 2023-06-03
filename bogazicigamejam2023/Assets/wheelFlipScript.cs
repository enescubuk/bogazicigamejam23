using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class wheelFlipScript : MonoBehaviour
{
    public int rotationSpeed;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
