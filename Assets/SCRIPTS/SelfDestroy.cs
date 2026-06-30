using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SelfDestroy : MonoBehaviour
{

    public float timeForDestruction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(DestroySelf(timeForDestruction)); 
    }

    private IEnumerator DestroySelf(float timeForDestruction)
    {
        yield return new WaitForSeconds(timeForDestruction);

        Destroy(gameObject);
    }
    
}
