using UnityEngine;

public class Player : Character
{
    void Start()
    {
        base.Init(100);
    }

    public void OnHitEnemy(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}");
            OnHitEnemy(enemy);
        }

        if (Health <= 0)
        {
            IsDead();
        }
    }
}
