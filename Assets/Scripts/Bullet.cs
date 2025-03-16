using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 20;
    public int damage = 200;
    public float lifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage); //health? vietoj if(health == null)
            
            Destroy(gameObject);
        }
    }
}
