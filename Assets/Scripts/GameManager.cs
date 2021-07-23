using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    public bool hasGameStarted;
    public bool isGameOver;
    
    [Header("Lap Settings")]
    [SerializeField] private int maxLaps;
    public int MaxLaps => maxLaps;
    private int _lapCount;
    public int LapCount => _lapCount;

    public void AddLap()
    {
        _lapCount++;
    }
    
}
