using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public UnityEvent onDeath;
    public bool destroyOnDeath;
    public UnityEvent onDamage;
    

    private int health;
    
    
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        onDamage.Invoke();

        if (health == 0)
        {
            onDeath.Invoke();
            
            if(destroyOnDeath) Destroy(gameObject);
        }
    }
    
}
