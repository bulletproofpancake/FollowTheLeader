using System;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public static event Action ScoreLap;

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
        if (!_hasGameStarted) return;
        if (!other.CompareTag("Player")) return;
        ScoreLap?.Invoke();
    }

    private void OnGameStart()
    {
        _hasGameStarted = true;
    }
    
}
