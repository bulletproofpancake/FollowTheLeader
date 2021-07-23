using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private TextMeshProUGUI lapsDisplay;
    [SerializeField] private TextMeshProUGUI employeeDisplay;

    private void OnEnable()
    {
        LapCounter.ScoreLap += UpdateScore;
        GameManager.GameStart += HideTitleScreen;
    }

    private void OnDisable()
    {
        LapCounter.ScoreLap -= UpdateScore;
        GameManager.GameStart -= HideTitleScreen;
    }

    private void Start()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
    }

    private void UpdateScore()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
    }

    private void Update()
    {
        employeeDisplay.text = $"Employees: {PlayerFollower.Instance.followers.Count}";
    }
    
    private void HideTitleScreen()
    {
        titleScreen.SetActive(false);
    }
    
}
