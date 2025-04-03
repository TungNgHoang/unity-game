using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestored = 20;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            bool wasHealed = damageable.Heal(healthRestored);

            if (wasHealed)
                Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(spinRotationSpeed * Time.deltaTime);
    }
}
