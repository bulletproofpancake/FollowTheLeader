using System;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerFollower : Singleton<PlayerFollower>
{
    [SerializeField] private float speed;
    private PathCreator _pathCreator;
    private float _currentSpeed;
    private float _distanceTravelled;

    public List<Follower> followers;

    public static event Action SpawnCount;

    private void Awake()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
        followers = new List<Follower>();
    }

    private void OnEnable()
    {
        //GameManager.GameStart += OnGameStart;
        LapCounter.SpawnFollower += SpawnFollower;
    }
    
    private void OnDisable()
    {
        //GameManager.GameStart -= OnGameStart;
        LapCounter.SpawnFollower -= SpawnFollower;
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

    //private void OnGameStart()
    //{
        // _distanceTravelled = 0;
        // foreach (var follower in _followers)
        // {
        //     follower.gameObject.SetActive(false);
        // }
        // _followers.Clear();
    //}

    private void SpawnFollower()
    {
        GameObject follower = ObjectPool.Instance.GetPooledObject();
        followers.Add(follower.GetComponent<Follower>());
        follower.SetActive(true);
    }
    
}
