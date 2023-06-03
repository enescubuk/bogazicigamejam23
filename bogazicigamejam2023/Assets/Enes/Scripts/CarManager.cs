using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarManager : MonoBehaviour
{
    public float speed;
    public GameObject bartarget,mainbar;
    public int randomScale;
    public GameObject[] frontWheels;
    Rigidbody rb => GetComponent<Rigidbody>();

    int drunkValue = 1;
    float rotate;
    private void Start()
    {
        InvokeRepeating("ChangeDrunkValue", 1, 1);
    }
    void Update()
    {
        rotate = drunkValue;

        if (Input.GetKey(KeyCode.A)) { rotate = -1; }
        if (Input.GetKey(KeyCode.S)) { rotate = 0; }
        if (Input.GetKey(KeyCode.D)) { rotate = 1; }
    }
    void FixedUpdate()
    {
        //Rotate Car and Wheels
        if (rotate != 0f)
        {
            float desiredRotation = rotate  * 20;
            Quaternion rotation = Quaternion.Euler(0f, desiredRotation, 0f);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, rotation, 90f * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
            frontWheels[0].transform.DORotate(new Vector3(-90, rotate * 50, 0), 0.1f);
            frontWheels[1].transform.DORotate(new Vector3(-90, rotate * 50, 0), 0.1f);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, 0), 0.1f);
            Quaternion zeroRotation = Quaternion.Euler(0f, 0f, 0f);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, zeroRotation, 90f * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }

        Vector3 movement = transform.forward * 10f * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
    void ChangeDrunkValue()
    {
        drunkValue = Random.Range(-1, 2);
        Debug.Log(drunkValue);
    }
    void barRandomMovement()
    {
        Vector3 randomPos;
        randomPos = mainbar.transform.position;
        float mainBarY = randomPos.y;
        float newMainBarY = Random.Range(mainBarY-randomScale,mainBarY+randomScale  );
        bartarget.transform.DOMoveY(newMainBarY,1f);
    }
}
