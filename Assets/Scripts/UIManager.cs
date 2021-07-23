using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapsDisplay;

    private void OnEnable()
    {
        LapCounter.ScoreLap += UpdateScore;
    }

    private void OnDisable()
    {
        LapCounter.ScoreLap -= UpdateScore;
    }

    private void Start()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
    }

    private void UpdateScore()
    {
        lapsDisplay.text = $"Laps: {ScoreManager.Instance.LapCount}/{ScoreManager.Instance.MaxLaps}";
    }
}
