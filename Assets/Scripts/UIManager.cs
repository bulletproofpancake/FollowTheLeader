using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI lapsDisplay;
    [SerializeField] private TextMeshProUGUI employeeDisplay;

    private void ShowEndScreen()
    {
        endScreen.SetActive(true);
    }

    private void Start()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
    }
    
    private void Update()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
        employeeDisplay.text = $"Employees: {PlayerFollower.Instance.followers.Count}";
        titleScreen.SetActive(!GameManager.Instance.hasGameStarted && !GameManager.Instance.isGameOver);
        endScreen.SetActive(GameManager.Instance.isGameOver);
        
    }
    
    private void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        endScreen.SetActive(false);
    }
    
}
