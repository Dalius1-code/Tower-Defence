using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cooldown;
    
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("Fire", 0, cooldown);
    }

    void Fire()
    {
        var target = GetTarget();
        if (target == null) return;
        
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().target = target;
    }

    Transform GetTarget()
    {
        var hits = Physics.OverlapSphere(transform.position, 15);
        foreach (var h in hits)
        {
            if (h.transform.CompareTag("Enemy"))
            {
                print(h.name);
                return h.transform;
            }
        }
        
        return null;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            enemies.Remove(other.gameObject);
        }
    }
}
