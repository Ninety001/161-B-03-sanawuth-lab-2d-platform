using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; } = 1f;
    public float WaitTime { get; set; } = 0.2f;

    private float nextShootTime = 0f;

    void Start()
    {
        base.Init(100);
    }

    public void Shoot()
    {
        if (Time.time >= nextShootTime && Bullet != null && ShootPoint != null)
        {
            
            GameObject newBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);

            
            Weapon weapon = newBullet.GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.InitWeapon(10, this);
            }

            nextShootTime = Time.time + ReloadTime + WaitTime;
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        if (enemy != null)
        {
            Debug.Log("Player hit by enemy!");
            TakeDamage(10);
        }
    }
}
