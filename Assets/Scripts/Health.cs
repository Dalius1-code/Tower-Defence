using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent OnDeath;
    public UnityEvent<float> OnHit;
    public bool destroyOnDeath;

    private int health;
    
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        
        OnHit.Invoke((float)health/maxHealth);

        if (health <= 0)
        {
            OnDeath.Invoke();

            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }
}
