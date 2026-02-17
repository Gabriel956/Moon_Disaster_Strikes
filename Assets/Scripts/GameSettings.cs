using UnityEngine;

public static class GameSettings
{
    // Default speed if nothing saved yet
    public static float PlayerSpeed = 5f;

    private const string SpeedKey = "PlayerSpeed";

    // Load from PlayerPrefs (disk)
    public static void Load()
    {
        PlayerSpeed = PlayerPrefs.GetFloat(SpeedKey, PlayerSpeed);
    }

    // Save to PlayerPrefs (disk)
    public static void Save()
    {
        PlayerPrefs.SetFloat(SpeedKey, PlayerSpeed);
        PlayerPrefs.Save();
    }
}
