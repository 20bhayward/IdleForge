using UnityEngine;
using System;

public class RunManager : MonoBehaviour
{
    // Fields
    public int currentDay;
    public float currentTimeInDay;
    public float secondsPerDay = 60f; // Example: 60 seconds per day

    // Events
    public static event Action<int> OnNewDay; // DayNumber

    // Reference to PlayerStateManager to reset player stats
    private PlayerStateManager playerStateManager;

    void Awake()
    {
        // Example of how to get PlayerStateManager, assuming it's on a GameObject named "Player"
        // You might need a more robust way to find/assign this depending on your scene setup
        GameObject playerObject = GameObject.FindWithTag("Player"); // Or find by name/type
        if (playerObject != null)
        {
            playerStateManager = playerObject.GetComponent<PlayerStateManager>();
        } else {
            Debug.LogError("RunManager: PlayerStateManager not found. Make sure a GameObject with PlayerStateManager exists and is tagged 'Player' or adjust finder logic.");
        }
    }

    void Start()
    {
        StartNewRun();
    }

    void Update()
    {
        currentTimeInDay += Time.deltaTime;
        if (currentTimeInDay >= secondsPerDay)
        {
            currentDay++;
            currentTimeInDay = 0; // Reset time for the new day
            OnNewDay?.Invoke(currentDay);
            Debug.Log($"End of Day {currentDay -1} event triggered (Placeholder)"); // Log end of the previous day
            Debug.Log($"Start of Day {currentDay} event triggered (Placeholder)");
        }
    }

    public void StartNewRun()
    {
        currentDay = 1;
        currentTimeInDay = 0;

        if (playerStateManager != null)
        {
            // Reset player gold and smithing level/XP
            playerStateManager.currentGold = 0;
            playerStateManager.currentSmithingXP = 0;
            playerStateManager.currentSmithingLevel = 0; // This will be set to 1 by InitializeSmithingProgression
            playerStateManager.InitializeSmithingProgression(); // Resets level to 1 and XP requirement
            // Manually invoke gold changed event if you want UI to update to 0 gold at run start
            PlayerStateManager.OnGoldChanged?.Invoke(playerStateManager.currentGold);
        }
        else
        {
            Debug.LogError("RunManager: PlayerStateManager not available to reset stats for a new run.");
        }

        OnNewDay?.Invoke(currentDay); // Announce Day 1
        Debug.Log("New Run Started. Day: " + currentDay);
    }

    // Public method to get current run time/day for UI or other systems
    public string GetCurrentRunStatus()
    {
        return $"Day: {currentDay} - Time: {Mathf.FloorToInt(currentTimeInDay)}s / {secondsPerDay}s";
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }

    public float GetCurrentTimeInDay()
    {
        return currentTimeInDay;
    }
}
