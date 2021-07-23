using System;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public static event Action ScoreLap;
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.hasGameStarted) return;
        if (!other.CompareTag("Player")) return;
        ScoreLap?.Invoke();
    }
}
