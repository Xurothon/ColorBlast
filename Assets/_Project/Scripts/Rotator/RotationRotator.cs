using UnityEngine;

public class RotationRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _currentDirection;

    public void SetNewDirection(float speed, Vector3 direction)
    {
        _rotationSpeed = speed;
        _currentDirection = direction;
    }

    private void Update()
    {
        transform.Rotate(_currentDirection, _rotationSpeed * Time.deltaTime, Space.World);
    }
}