using System;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public static event Action SpawnFollower;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        SpawnFollower?.Invoke();
    }
    
}
