using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI bestDisplay;
    [SerializeField] private TextMeshProUGUI employeeDisplay;
    
    private void Update()
    {
        employeeDisplay.text = $"Employees: {PlayerFollower.Instance.followers.Count:00}";
        bestDisplay.text = $"Best: {GameManager.Instance.bestScore}";
        titleScreen.SetActive(!GameManager.Instance.hasGameStarted && !GameManager.Instance.isGameOver);
        endScreen.SetActive(GameManager.Instance.isGameOver);
    }

}
