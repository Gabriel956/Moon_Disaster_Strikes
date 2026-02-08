using UnityEngine;

public class player_movement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D body;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
 
        //Flip player when facing left/right.
        //if (horizontalInput > 0.01f)
        //    transform. = new Vector3(-0.3f, 0.3f, 0.3f);

        //else if (horizontalInput < -0.01f)
        //    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

         if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        
    }
}
