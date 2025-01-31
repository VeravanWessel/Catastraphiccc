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
    private float Beginx = -58.63f;
    private float Beginy = -2.97f;
    public HealthBar healthbarscript;

    private void Start()
    {
        currentHealth = maxHealth;
        transform.position = new Vector3(Beginx, Beginy, 0f);
        healthbarscript.DrawHearts();


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
            Doodgaan();
        }
    }

    public void Doodgaan()
    {
        Start();

    }
}
