using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    public bool hasGameStarted;
    public bool isGameOver;

    public int bestScore;
    
    
    public static event Action GameOver;
    
    private void Update()
    {
        if (hasGameStarted)
        {
            if(isGameOver)
            {
                GameOver?.Invoke();
                hasGameStarted = false;
            }
            //isGameOver = false;
        }
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (!hasGameStarted && isGameOver) isGameOver = !isGameOver;
        //GameStart?.Invoke();
        hasGameStarted = true;
    }
}
