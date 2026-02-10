using UnityEngine;

public class death : MonoBehaviour
{
    

    void OnCollisionEnter2D( Collision2D collision)
    {
        if (collision.gameObject.CompareTag("asteroid") )

            {
                Die();

            }


    }

    void Die()
    {
        Destroy(gameObject);
    }


   
}
