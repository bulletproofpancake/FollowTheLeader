using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _distanceTravelled;
    private PathCreator _pathCreator;

    private void Start()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _distanceTravelled = 0f;
    }

    private void Move()
    {
        speed = Input.GetKey(KeyCode.Space) ? speed > 0 ? speed -= Time.deltaTime * 5f : 0 : 2.75f;
        _distanceTravelled += speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }
}
