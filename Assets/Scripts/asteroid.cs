using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;

    private Rigidbody2D rb;
    private bool isDestroyed = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isDestroyed || rb == null) return;
        
        rb.linearVelocity = new Vector2(0f, -fallSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyed) return;
        
        Debug.Log("Asteroid hit: " + collision.gameObject.name + " with tag: " + collision.gameObject.tag);
        
        // Hit the player and asteroid destroyed (player death handled by death.cs)
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyAsteroid();
        }
        // Hit ground or platform and asteroid is destoyed
        else if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyAsteroid();
        }
    }

    void DestroyAsteroid()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
}