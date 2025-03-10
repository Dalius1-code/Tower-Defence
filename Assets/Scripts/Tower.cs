using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cooldown = 1;
    
    public List<GameObject> enemies;
    
    void Start()
    {
        InvokeRepeating("Fire", 0, cooldown);
    }

    void Fire()
    {
        CleanTargets();
        if (enemies.Count == 0) return;
        
        
        var target = enemies[Random.Range(0, enemies.Count)];
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().target = target.transform;
    }

    void CleanTargets()
    {
        enemies.RemoveAll(enemy => enemy == null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Enemy")) enemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Enemy")) enemies.Remove(other.gameObject);
    }
}
