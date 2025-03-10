using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
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
        
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().target = target;
    }

    Transform GetTarget()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] != null) return enemies[i].transform;
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
