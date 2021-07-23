using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    private bool _hasGameStarted;
    private bool _isGameOver;

    public static event Action GameStart;
    public static event Action GameOver;
    
    private void Update()
    {
        if (_hasGameStarted) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        GameStart?.Invoke();
        _hasGameStarted = true;
    }
}
