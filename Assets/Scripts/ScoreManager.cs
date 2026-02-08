using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    public void AddPoint(int amount)
    {
        score += amount;
        UpdateScore();

    }
    // Update is called once per frame
    void UpdateScore()
    {
        scoreText.text = "Score: "+ score;
    }
}
