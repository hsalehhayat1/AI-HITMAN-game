using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
public class Throwable : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] float damageRadius = 20f;
    [SerializeField] float explosionForce = 1200f;

    float countdown;

    bool hasExploded = false;
    public bool hasBeenThrown = false;

    public enum ThrowableType
    {
        Grenade
    }

    public ThrowableType throwabletype;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        if(hasBeenThrown)
        {
            countdown -= Time.deltaTime;
            if(countdown < 0f && !hasExploded)
            {
                Explode();
                hasExploded = true;
            }
        }
    }

    private void Explode()
    {
        GetThrowableEffect();
        Destroy(gameObject);

    }

    private void GetThrowableEffect()
    {
        switch (throwabletype)
        {
            case ThrowableType.Grenade:
                GrenadeEffect();
                break;
        }
    }



    private void GrenadeEffect()
    {
        GameObject explosionEffect = GlobalReferences.Instance.grenadeExplosionEffect;
        Instantiate(explosionEffect,transform.position,transform.rotation);

        SoundManager.Instance.thrwoablesChannel.PlayOneShot(SoundManager.Instance.grenadeSound);

        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach(Collider objectInRange in colliders)
        {
            Rigidbody rb = objectInRange.GetComponent<Rigidbody>();
            if(rb!= null)
            {
                rb.AddExplosionForce(explosionForce, transform.position,damageRadius);
            }

            if(objectInRange.gameObject.GetComponent<Enemy>())
            {
                EnemyAI enemy = objectInRange.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(100);
                }
            }
        }
    }
}
