using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
    
    public int maxHealth = 3;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}
