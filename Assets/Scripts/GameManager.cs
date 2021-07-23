using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    public bool hasGameStarted;
    public bool isGameOver;

    private void Update()
    {
        if (hasGameStarted) return;
        hasGameStarted = Input.GetKeyDown(KeyCode.Space);
    }
}
