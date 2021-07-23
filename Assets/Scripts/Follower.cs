using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private float speed;
    private float _currentSpeed;
    private float _distanceTravelled;

    private void Update()
    {
        _currentSpeed = Input.GetKey(KeyCode.Space) ? 0f : speed;
        _distanceTravelled += _currentSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }
}
