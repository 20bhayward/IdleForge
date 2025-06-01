using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; // For System.Action
// Assuming PlayerStateManager.cs and RunManager.cs are in Assets/Scripts/Managers/
// using YourNamespace.Managers;

public class MainHUDController : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI dateTimeText;
    public TextMeshProUGUI playerLevelText;
    public Image playerXPBarFill; // The fill image for XP bar
    public TextMeshProUGUI playerXPText; // Text for XP numbers like "50/120 XP"

    void OnEnable()
    {
        // Subscribe to events
        PlayerStateManager.OnGoldChanged += UpdateGoldDisplay;
        PlayerStateManager.OnSmithingXPChanged += UpdateSmithingXPDisplay;
        PlayerStateManager.OnSmithingLevelUp += UpdateSmithingLevelDisplay;
        RunManager.OnDateTimeChanged += UpdateDateTimeDisplay;

        // Initialize display with default or current values
        // This assumes that the managers might have initial values or will soon fire events
        // For a robust setup, you might want to fetch current state directly if available
        UpdateGoldDisplay(0); // Default to 0 or fetch from PlayerStateManager
        UpdateDateTimeDisplay(1, 0); // Default to Day 1, 00:00 or fetch
        UpdateSmithingLevelDisplay(1); // Default to level 1 or fetch
        UpdateSmithingXPDisplay(1, 0, 100); // Default to 0/100 XP or fetch
    }

    void OnDisable()
    {
        // Unsubscribe from events
        PlayerStateManager.OnGoldChanged -= UpdateGoldDisplay;
        PlayerStateManager.OnSmithingXPChanged -= UpdateSmithingXPDisplay;
        PlayerStateManager.OnSmithingLevelUp -= UpdateSmithingLevelDisplay;
        RunManager.OnDateTimeChanged -= UpdateDateTimeDisplay;
    }

    public void UpdateGoldDisplay(float newGoldAmount)
    {
        if (goldText != null)
        {
            goldText.text = $"Gold: {newGoldAmount:N0}"; // Format as whole number
        }
    }

    public void UpdateDateTimeDisplay(int day, float timeInDay) // timeInDay could be seconds from start of day or a 0-1 float
    {
        if (dateTimeText != null)
        {
            // Assuming timeInDay is fraction of day (0.0 to 1.0)
            // Or if timeInDay is in seconds, adjust calculation (e.g., totalSeconds = 24 * 60 * 60)
            int hours = Mathf.FloorToInt(timeInDay * 24f); // If timeInDay is 0-1 fraction
            int minutes = Mathf.FloorToInt((timeInDay * 24f * 60f) % 60);
            // If timeInDay is in seconds:
            // int hours = Mathf.FloorToInt(timeInDay / 3600f);
            // int minutes = Mathf.FloorToInt((timeInDay % 3600f) / 60f);
            dateTimeText.text = $"Day: {day}, Time: {hours:D2}:{minutes:D2}";
        }
    }

    public void UpdateSmithingLevelDisplay(int newLevel)
    {
        if (playerLevelText != null)
        {
            playerLevelText.text = $"Level: {newLevel}";
        }
    }

    public void UpdateSmithingXPDisplay(int level, float currentXP, float xpToNextLevel)
    {
        if (playerXPBarFill != null)
        {
            if (xpToNextLevel > 0)
            {
                playerXPBarFill.fillAmount = Mathf.Clamp01(currentXP / xpToNextLevel);
            }
            else // Avoid division by zero if xpToNextLevel is 0 (e.g., max level)
            {
                playerXPBarFill.fillAmount = (currentXP > 0) ? 1f : 0f;
            }
        }
        if (playerXPText != null)
        {
            if (xpToNextLevel > 0)
            {
                playerXPText.text = $"{currentXP:N0} / {xpToNextLevel:N0} XP";
            }
            else // Max level or undefined next level
            {
                playerXPText.text = $"{currentXP:N0} XP";
            }
        }
        // Also update the level display if it's part of this event context
        // UpdateSmithingLevelDisplay(level); // Or ensure OnSmithingLevelUp handles it separately
    }
}
