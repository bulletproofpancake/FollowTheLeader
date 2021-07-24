using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI lapsDisplay;
    [SerializeField] private TextMeshProUGUI employeeDisplay;

    private void OnEnable()
    {
        GameManager.GameStart += HideTitleScreen;
        GameManager.GameOver += ShowEndScreen;
    }

    private void OnDisable()
    {
        GameManager.GameStart -= HideTitleScreen;
        GameManager.GameOver += ShowEndScreen;
    }

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
    }
    
    private void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        endScreen.SetActive(false);
    }
    
}
