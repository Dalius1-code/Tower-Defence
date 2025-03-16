using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldown = 2;
    
    
    public List<GameObject> enemies = new();
    
    void Start()
    {
        InvokeRepeating("Shoot", 0, cooldown);
    }

    public void Shoot()
    {
        enemies.RemoveAll(e => e == null);
        
        if(enemies.Count <= 0) return;
        
        var bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.GetComponent<Bullet>().target = enemies[0].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            enemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            enemies.Remove(other.gameObject);
    }
}
