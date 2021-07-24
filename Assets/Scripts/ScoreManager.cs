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
        GameManager.GameStart += ResetScore;
        LapCounter.ScoreLap += AddScore;
    }

    private void OnDisable()
    {
        GameManager.GameStart += ResetScore;
        LapCounter.ScoreLap -= AddScore;
    }

    private void ResetScore()
    {
        _lapCount = 0;
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
