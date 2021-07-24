using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    private float _speed;
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
        if (PlayerFollower.Instance.followers.Contains(this))
        {
            PlayerFollower.Instance.followers.Remove(this);    
        }
    }

    private void Move()
    {
        _speed = Input.GetKey(KeyCode.Space) ? _speed > 0 ? _speed -= Time.deltaTime * 5f : 0 : baseSpeed;
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            print("Obstacle");
            gameObject.SetActive(false);
        }
    }
}
