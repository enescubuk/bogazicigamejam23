using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Temas");
        if (other.CompareTag("Layer"))
        {
            PoolManager.instance.Despawn(other.gameObject);
            // the it's a background object it will trigger spawn new one in the right side.
            GameManager.instance.UpdateBG();
            // update the score counter +1
            if (GameManager.instance.GameRun)
            {
                GameManager.instance.Score = 1;
            }
        }
        else
        {
            // other objects just return to pool.
            PoolManager.instance.Despawn(other.gameObject);
        }
    }
}
