using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestored = 20;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);
    public AudioSource pickupSource;

    private void Awake()
    {
            pickupSource = GetComponent<AudioSource>();
    }
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
                if (pickupSource)
                    AudioSource.PlayClipAtPoint(pickupSource.clip, transform.position, pickupSource.volume);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(spinRotationSpeed * Time.deltaTime);
    }
}
