using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            ScoreManager.instance.AddPoint(points);
            Destroy(gameObject);
        }
    }
}