using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class speedStabilization : MonoBehaviour
{
    public float arrowSpeed;
    public GameObject arrow;
    public GameObject mainbar;
    public GameObject barTarget;
    public float randomScale;
    Rigidbody2D rb;
    public int increaseValue,decreaseValue;
    public Slider slider;
    

    void Start()
    {
        rb = arrow.GetComponent<Rigidbody2D>();
        InvokeRepeating("checkBar",1f,0.5f);
        InvokeRepeating("barRandomMovement",1f,1f);
    }
    void barRandomMovement()
    {
        Vector3 randomPos = mainbar.transform.position;
        float mainBarY = randomPos.y;
        float newMainBarY = Mathf.Clamp(Random.Range(mainBarY-randomScale,mainBarY+randomScale),mainBarY - 257,mainBarY + 257);
        barTarget.transform.DOMoveY(newMainBarY,1f);
    }
    void FixedUpdate()
    {
        float moveY = Mathf.Clamp(Input.GetAxis("Vertical"),0,1);
        
        arrow.transform.Translate(Vector3.up * Time.deltaTime * arrowSpeed * moveY);
        if (moveY != 0)
        {
            rb.velocity = new Vector3(0f,0f,0f);
        }
        
    }
    void checkBar()
    {
        float a = arrow.transform.position.y - barTarget.transform.position.y;
        if (a < 0)
        {
            a *= -1;
        }
        if (a < 37)
        {
            slider.value += increaseValue;
        }
        else if (a < 92)
        {
            slider.value -= decreaseValue;
        }
        else
        {
            slider.value -= decreaseValue *2;
        }
        if (slider.value == 100)
        {
            Debug.Log("its done");
        }
    }
}
