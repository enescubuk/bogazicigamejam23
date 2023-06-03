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
    float axisY;
    Rigidbody rb => GetComponent<Rigidbody>();
    bool drunkMod = false;
    public float drunkRepeatRate;
    float drunkRate;
    float rotate;
    void Start()
    {
        rotate = Random.Range(-1f,1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            drunkMod = true;
            InvokeRepeating("randomDirection",0,drunkRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            drunkMod = false;
            CancelInvoke("randomDirection");
        }
    }
    void FixedUpdate()
    {
        //carForwardMovement();
        axisY = Input.GetAxis("Horizontal");
        //carCurve(axisY);
        if (axisY != 0)
        {
            frontWheels[0].transform.DORotate(new Vector3(-90,axisY * 50,0),0.1f);
            frontWheels[1].transform.DORotate(new Vector3(-90,axisY * 50,0),0.1f);
            
        }
        else
        {
            transform.DORotate(new Vector3(0,0,0),0.1f);
        }
        float moveForward = Input.GetAxis("Vertical");
        rotate = 0;
        float horizontal = Input.GetAxis("Horizontal");
        
        if (moveForward != 0f || rotate != 0f)
        {
            float desiredRotation = rotate  * 20;
            Quaternion rotation = Quaternion.Euler(0f, desiredRotation, 0f);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, rotation, 90f * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }
        else if (drunkMod == true)
        {
            float desiredRotation = rotate  * 20;
            Quaternion rotation = Quaternion.Euler(0f, desiredRotation, 0f);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, rotation, 90f * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }
        else
        {
            
            Quaternion zeroRotation = Quaternion.Euler(0f, 0f, 0f);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, zeroRotation, 90f * Time.fixedDeltaTime);
            rb.MoveRotation(newRotation);
        }

        Vector3 movement = transform.forward * moveForward * 10f * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        
    }

    void randomDirection()
    {
        drunkRate = Random.Range(-1f,1f);

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
