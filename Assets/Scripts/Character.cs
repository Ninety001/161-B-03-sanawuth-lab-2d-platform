using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health 
    { get => health;
      set => health = (value < 0) ? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;
    
    //methods
    public void Init(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} HP:{this.Health}");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name}:Take {damage}. HP left : {Health}");
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
