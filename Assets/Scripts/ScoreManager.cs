using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [Header("Lap Settings")]
    [SerializeField] private int maxLaps;
    public int MaxLaps => maxLaps;
    
    private int _lapCount;

    public int LapCount => _lapCount >= maxLaps ? maxLaps : _lapCount;

    private void OnEnable()
    {
        LapCounter.ScoreLap += AddScore;
    }

    private void OnDisable()
    {
        LapCounter.ScoreLap -= AddScore;
    }

    private void Update()
    {
        if (_lapCount > maxLaps)
        {
            GameManager.Instance.isGameOver = true;
        }
    }

    private void AddScore()
    {
        _lapCount++;
    }
}
