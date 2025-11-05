using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(damage);
            Debug.Log($"Banana hit {character.name}, dealt {damage} damage!");
        }
    }

    void Start()
    {
        speed = 4.0f * GetShootDirection();
        damage = 15;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character target = other.GetComponent<Character>();

        if (target != null)
        {
            OnHitWith(target);   // เรียก method ของ Weapon.cs
            Destroy(gameObject); // ทำลายกระสุนหลังชน
        }
    }
}
