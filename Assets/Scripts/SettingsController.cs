using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Slider speedSlider;
    public TextMeshProUGUI speedValueText;

    public Slider jumpForceSlider;
    public TextMeshProUGUI jumpForceValueText;

    public float minSpeed = 1f;
    public float maxSpeed = 12f;

    public float minJumpForce = 1f;
    public float maxJumpForce = 20f;

    void Start()
    {
        GameSettings.Load();

        speedSlider.minValue = minSpeed;
        speedSlider.maxValue = maxSpeed;
        speedSlider.value = GameSettings.PlayerSpeed;
        UpdateSpeedText(speedSlider.value);
        speedSlider.onValueChanged.AddListener(OnSpeedChanged);

        jumpForceSlider.minValue = minJumpForce;
        jumpForceSlider.maxValue = maxJumpForce;
        jumpForceSlider.value = GameSettings.PlayerJumpForce;
        UpdateJumpForceText(jumpForceSlider.value);
        jumpForceSlider.onValueChanged.AddListener(OnJumpForceChanged);
    }

    public void OnSpeedChanged(float newSpeed)
    {
        GameSettings.PlayerSpeed = newSpeed;
        GameSettings.Save();
        UpdateSpeedText(newSpeed);
    }

    public void OnJumpForceChanged(float newJumpForce)
    {
        GameSettings.PlayerJumpForce = newJumpForce;
        GameSettings.Save();
        UpdateJumpForceText(newJumpForce);
    }

    void UpdateSpeedText(float value)
    {
        if (speedValueText != null)
            speedValueText.text = $"Speed: {value:0.0}";
    }

    void UpdateJumpForceText(float value)
    {
        if (jumpForceValueText != null)
            jumpForceValueText.text = $"Jump Force: {value:0.0}";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}