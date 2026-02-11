using UnityEngine;

public class death : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("DeathGround"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Ship"))
        {
            Win();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
    }

    void Win()
    {
        Debug.Log("You Win!");
        // Stop player movement
        Time.timeScale = 0f;
        // You can add scene loading here later, e.g.:
        // SceneManager.LoadScene("WinScreen");
    }
}
