using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10; // Damage dealt by the projectile
    public Vector2 speed = new Vector2(5f, 0); // Speed of the projectile
    Rigidbody2D rb;
    public Vector2 knockback = new Vector2(0, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector2 (speed.x * transform.localScale.x, speed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            //Hit the target
            bool gotHit = damageable.Hit(damage, deliveredKnockback);
            if (gotHit)
            {
                
                Debug.Log(collision.name + " hit for " + damage);
                Destroy(gameObject);
            }
        }
    }
}
