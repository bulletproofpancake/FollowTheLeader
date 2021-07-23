using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapsDisplay;

    private void Update()
    {
        lapsDisplay.text = $"Laps: {GameManager.Instance.LapCount}/{GameManager.Instance.MaxLaps}";
    }
}
