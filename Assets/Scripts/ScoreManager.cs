using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [Header("Lap Settings")]
    [SerializeField] private int maxLaps;
    public int MaxLaps => maxLaps;
    private int _lapCount = 0;
    public int LapCount => _lapCount;

    private void OnEnable()
    {
        LapCounter.ScoreLap += AddScore;
    }

    private void OnDisable()
    {
        LapCounter.ScoreLap -= AddScore;
    }

    private void AddScore()
    {
        _lapCount++;
    }
}
