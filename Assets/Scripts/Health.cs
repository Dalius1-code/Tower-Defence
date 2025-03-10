using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent<int, int> onDamage;
    public bool destroyOnDeath;
    public UnityEvent onDeath;
    
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        onDamage.Invoke(health, damage);

        if (health <= 0)
        {
            onDeath.Invoke();
            
            if(destroyOnDeath) Destroy(gameObject);

            enabled = false;//disable this script
        }
    }
}
