using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    public bool hasGameStarted;
    public bool isGameOver;

    public static event Action GameStart;
    public static event Action GameOver;
    
    private void Update()
    {
        if (hasGameStarted)
        {
            if(!isGameOver) return; 
            GameOver?.Invoke();
            hasGameStarted = false;
            isGameOver = false;
        }
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        GameStart?.Invoke();
        hasGameStarted = true;
    }
}
