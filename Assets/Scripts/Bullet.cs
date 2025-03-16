using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 20;
    public float lifeTime = 3;
    public int damage = 100;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if(target == null) return;
        
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            var health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage);
            
            Destroy(gameObject);
        }
    }
}
