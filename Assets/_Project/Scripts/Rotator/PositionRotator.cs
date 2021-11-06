using UnityEngine;

public class PositionRotator : MonoBehaviour
{
    [SerializeField] private float _positionSpeed;
    [SerializeField] private float _distance;
    private Vector3 _rightPoint;
    private Vector3 _leftPoint;

    public void SetNewDirection(float speed, float distance)
    {
        _positionSpeed = speed;
        _distance = distance;
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        _rightPoint = new Vector3(transform.localPosition.x + _distance, 0, 0);
        _leftPoint = new Vector3(transform.localPosition.x - _distance, 0, 0);
    }

    private void Update()
    {
        transform.localPosition += Vector3.right * _positionSpeed * Time.deltaTime;
        if (transform.localPosition.x >= _rightPoint.x)
        {
            _positionSpeed *= -1;
        }
        if (transform.localPosition.x <= _leftPoint.x)
        {
            _positionSpeed *= -1;
        }
    }

    private void Awake()
    {
        UpdatePoints();
    }
}
