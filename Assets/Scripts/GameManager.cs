using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    private bool _hasGameStarted;
    public bool isGameOver;

    public static event Action GameStart;
    public static event Action GameOver;
    
    private void Update()
    {
        if (_hasGameStarted)
        {
            if(!isGameOver) return;
            else
            {
                GameOver?.Invoke();
            }
        }
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        GameStart?.Invoke();
        _hasGameStarted = true;
    }
}
