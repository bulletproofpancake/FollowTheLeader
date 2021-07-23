using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    private PathCreator _pathCreator;
    private float _currentSpeed;
    private float _distanceTravelled;

    private List<Follower> _followers;


    private void Awake()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
        _followers = new List<Follower>();
    }

    private void OnEnable()
    {
        GameManager.GameStart += OnGameStart;
        LapCounter.ScoreLap += SpawnFollower;
    }
    
    private void OnDisable()
    {
        GameManager.GameStart -= OnGameStart;
        LapCounter.ScoreLap -= SpawnFollower;
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        _currentSpeed = Input.GetKey(KeyCode.Space) ? 0f : speed;
        _distanceTravelled += _currentSpeed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }

    private void OnGameStart()
    {
        _distanceTravelled = 0;
    }

    private void SpawnFollower()
    {
        GameObject follower = ObjectPool.Instance.GetPooledObject();
        _followers.Add(follower.GetComponent<Follower>());
        follower.SetActive(true);
    }
    
}
