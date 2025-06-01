using UnityEngine;
using System;

public class PlayerStateManager : MonoBehaviour
{
    // Fields
    public float currentGold;
    public float currentSmithingXP;
    public int currentSmithingLevel;
    public float xpForNextSmithingLevel;
    public AnimationCurve smithingLevelUpCurve;

    // Events
    public static event Action<float> OnGoldChanged;
    public static event Action<int, float, float> OnSmithingXPChanged; // Level, CurrentXP, XPForNextLevel
    public static event Action<int> OnSmithingLevelUp; // NewLevel

    void Awake()
    {
        InitializeSmithingProgression();
    }

    public void InitializeSmithingProgression()
    {
        // Initialize smithing level if it's not already set (e.g. new game)
        if (currentSmithingLevel == 0)
        {
            currentSmithingLevel = 1;
        }
        xpForNextSmithingLevel = smithingLevelUpCurve.Evaluate(currentSmithingLevel);
        // Invoke events to ensure UI and other systems are updated with initial values
        OnSmithingXPChanged?.Invoke(currentSmithingLevel, currentSmithingXP, xpForNextSmithingLevel);
        OnSmithingLevelUp?.Invoke(currentSmithingLevel);
    }

    public void AddGold(float amount)
    {
        currentGold += amount;
        OnGoldChanged?.Invoke(currentGold);
    }

    public bool SpendGold(float amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            OnGoldChanged?.Invoke(currentGold);
            return true;
        }
        return false;
    }

    public void AddSmithingXP(float amount)
    {
        currentSmithingXP += amount;
        if (currentSmithingXP >= xpForNextSmithingLevel)
        {
            LevelUpSmithing();
        }
        OnSmithingXPChanged?.Invoke(currentSmithingLevel, currentSmithingXP, xpForNextSmithingLevel);
    }

    void LevelUpSmithing()
    {
        currentSmithingLevel++;
        currentSmithingXP -= xpForNextSmithingLevel; // Carry over excess XP
        xpForNextSmithingLevel = smithingLevelUpCurve.Evaluate(currentSmithingLevel);
        OnSmithingLevelUp?.Invoke(currentSmithingLevel);
        Debug.Log($"Player smithing skill leveled up to {currentSmithingLevel}! (Placeholder for randomized upgrade choice)");
    }
}
