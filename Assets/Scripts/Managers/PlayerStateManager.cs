using System;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // Gold
    public static event Action<float> OnGoldChanged;
    public static void TriggerGoldChanged(float newGold) => OnGoldChanged?.Invoke(newGold);

    // Smithing XP
    public static event Action<int, float, float> OnSmithingXPChanged; // level, currentXP, xpToNextLevel
    public static void TriggerSmithingXPChanged(int level, float currentXP, float xpToNextLevel) => OnSmithingXPChanged?.Invoke(level, currentXP, xpToNextLevel);

    // Smithing Level Up
    public static event Action<int> OnSmithingLevelUp; // newLevel
    public static void TriggerSmithingLevelUp(int newLevel) => OnSmithingLevelUp?.Invoke(newLevel);

    // Example method to simulate changes (for testing)
    // You might call these from somewhere else in your actual game logic
    public void SimulateGoldChange(float amount)
    {
        TriggerGoldChanged(amount);
    }

    public void SimulateXPChange(int level, float currentXP, float xpToNextLevel)
    {
        TriggerSmithingXPChanged(level, currentXP, xpToNextLevel);
    }

    public void SimulateLevelUp(int newLevel)
    {
        TriggerSmithingLevelUp(newLevel);
    }
}
