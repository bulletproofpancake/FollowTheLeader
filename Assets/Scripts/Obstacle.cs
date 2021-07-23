using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform[] moveLocations;
    private Sequence _sequence;
    private void Start()
    {
        InvokeRepeating("PlaySequence",0f,2f);
    }

    void PlaySequence()
    {
        _sequence = DOTween.Sequence();
        for (int i = 0; i < moveLocations.Length; i++)
        {
            _sequence.Append(transform.DOMove(moveLocations[i].position,1f));
        }
    }
}
