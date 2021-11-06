using UnityEngine;

public class HeightRotator : MonoBehaviour
{
    [SerializeField] private float _positionSpeed;
    [SerializeField] private float _distance;
    private Vector3 _upPoint;
    private Vector3 _downPoint;

    public void SetNewDirection(float speed, float distance)
    {
        _positionSpeed = speed;
        _distance = distance;
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        _upPoint = new Vector3(0, transform.localPosition.y + _distance, 0);
        _downPoint = new Vector3(0, transform.localPosition.y - _distance, 0);
    }

    private void Update()
    {
        transform.localPosition += Vector3.up * _positionSpeed * Time.deltaTime;
        if (transform.localPosition.y >= _upPoint.y)
        {
            _positionSpeed *= -1;
        }
        if (transform.localPosition.y <= _downPoint.y)
        {
            _positionSpeed *= -1;
        }
    }

    private void Awake()
    {
        UpdatePoints();
    }
}
