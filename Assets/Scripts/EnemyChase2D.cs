using UnityEngine;

public class EnemyChase2D : MonoBehaviour
{
    [Header("Chase Settings")]
    public float speed = 3f;
    public float detectionRadius = 8f;   // enemy only chases if player is close enough
    public float stopDistance = 0.5f;    // enemy stops when very close (prevents jitter)

    Transform player;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("player");
        if (p != null) player = p.transform;
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            // Try to reacquire player (useful if you respawn / destroy-recreate)
            GameObject p = GameObject.FindGameObjectWithTag("player");
            if (p != null) player = p.transform;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float dist = Vector2.Distance(rb.position, player.position);
        if (dist > detectionRadius)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (dist <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }

    
}
