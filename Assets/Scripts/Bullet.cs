using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 100;
    public Transform target;

    void Update()
    {
        if(target == null) return;
        
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage);//if health null, dont call TakeDamage
            Destroy(gameObject);
        }
    }
}
