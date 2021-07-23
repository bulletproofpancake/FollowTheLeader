using System;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public static event Action ScoreLap;

    public static event Action SpawnFollower;

    private bool _hasGameStarted;

    private void OnEnable()
    {
        GameManager.GameStart += OnGameStart;
    }
    private void OnDisable()
    {
        GameManager.GameStart -= OnGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        SpawnFollower?.Invoke();
        if (!_hasGameStarted) return;
        ScoreLap?.Invoke();
    }

    private void OnGameStart()
    {
        _hasGameStarted = true;
    }
    
}
