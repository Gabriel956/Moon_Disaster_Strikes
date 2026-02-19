using UnityEngine;

public static class GameSettings
{
    // Default speed if nothing saved yet
    public static float PlayerSpeed = 5f;
    public static float PlayerJumpForce = 7f;

    private const string SpeedKey = "PlayerSpeed";
    private const string JumpForceKey = "PlayerJumpForce";

    // Load from PlayerPrefs (disk)
    public static void Load()
    {
        PlayerSpeed = PlayerPrefs.GetFloat(SpeedKey, PlayerSpeed);
        PlayerJumpForce = PlayerPrefs.GetFloat(JumpForceKey, PlayerJumpForce);
    }

    // Save to PlayerPrefs (disk)
    public static void Save()
    {
        PlayerPrefs.SetFloat(SpeedKey, PlayerSpeed);
        PlayerPrefs.SetFloat(JumpForceKey, PlayerJumpForce);
        PlayerPrefs.Save();
    }
}
