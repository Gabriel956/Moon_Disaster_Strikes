using UnityEngine;

public class death : MonoBehaviour
{
    

    void OnCollisionEnter2D( Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb") )

            {
                Die();

            }


    }

    void Die()
    {
        Destroy(gameObject);
    }


   
}
