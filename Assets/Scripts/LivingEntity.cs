using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public virtual void Start()
    {
        health = startingHealth;
    }
    public void TakeHit(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }
    public void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
