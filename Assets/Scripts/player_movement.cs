using UnityEngine;

public class player_movement : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    //[SerializeField] private float jumpForce = 7f;
    
    private Rigidbody2D body;
    public float speed = 5f;
    public float jumpForce = 7f;
    Animator animator;
    void Start()
    {

        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;
        jumpForce = GameSettings.PlayerJumpForce;
        
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        //}

        speed = GameSettings.PlayerSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        animator.SetFloat("speed", Mathf.Abs(horizontalInput));

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}

/*
 * using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed = 5f;

    //[SerializeField] private float speed;
    private Rigidbody2D body;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSettings.Load();
        speed = GameSettings.PlayerSpeed;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed = GameSettings.PlayerSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

         if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        
    }
}
 * 
 * 
 * 
 * 
 */