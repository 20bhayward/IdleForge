using System;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static event Action<int, float> OnDateTimeChanged; // day, timeInDay (e.g., 0.0f to 1.0f or seconds)
    public static void TriggerDateTimeChanged(int day, float timeInDay) => OnDateTimeChanged?.Invoke(day, timeInDay);

    // Example method to simulate time changes (for testing)
    public void SimulateNewDay(int day, float time)
    {
        TriggerDateTimeChanged(day, time);
    }
}
