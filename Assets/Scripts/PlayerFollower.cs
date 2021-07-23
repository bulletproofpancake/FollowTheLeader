using UnityEngine;
using PathCreation;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    private PathCreator _pathCreator;
    private float _currentSpeed;
    private float _distanceTravelled;


    private void Awake()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
    }

    private void OnEnable()
    {
        GameManager.GameStart += OnGameStart;
    }
    
    private void OnDisable()
    {
        GameManager.GameStart -= OnGameStart;
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
    
}
