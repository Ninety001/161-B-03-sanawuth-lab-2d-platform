using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    private int health;
    protected int maxHealth;

    public int MaxHealth { get; private set; }
    public int Health
    {
        get => health;
        set
        {
            int newVal = (value < 0) ? 0 : value;
            if (newVal == health) return;
            health = newVal;

            OnHealthChanged?.Invoke(health, maxHealth);

            if (health <= 0) IsDead();    
        }
    }

    public event Action<int, int> OnHealthChanged;

    protected Animator anim;
    protected Rigidbody2D rb;
    
    //methods
    public void Init(int startHealth)
    {
        MaxHealth = startHealth;               
        Health = startHealth;
        Debug.Log($"{this.name} HP:{this.Health}");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name}:Take {damage}. HP left : {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Debug.Log($"{this.name} is dead! and destroyed!");
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

}
