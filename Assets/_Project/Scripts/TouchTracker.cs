using UnityEngine;
using UnityEngine.EventSystems;

public class TouchTracker : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] ShpereSpawner _sphereSpawner;
    [SerializeField] Transform _startObjectPosition;
    [SerializeField] float _addPositionX;
    [SerializeField] float _addPositionY;
    [SerializeField] float _addPositionZ;
    [SerializeField] float _additionVelosity;
    private Camera _mainCamera;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private Vector3 _directionForBall;

    public void OnDrag(PointerEventData eventData)
    {
        _endTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        float diffecenceX = -1 * (_startTouchPosition.x - _endTouchPosition.x);
        float diffecenceY = -1 * (_startTouchPosition.y - _endTouchPosition.y);
        _directionForBall = new Vector3(_addPositionX * diffecenceX, _addPositionY * diffecenceY, _addPositionZ) - _startObjectPosition.position;
        _trajectoryRenderer.ShowTrajectory(_startObjectPosition.position, _directionForBall.normalized * _additionVelosity * 2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((_endTouchPosition.x + _endTouchPosition.y) > 0.2f)
        {
            _sphereSpawner.SpawnObject(_startObjectPosition.position, _directionForBall.normalized * _additionVelosity);
        }
        _trajectoryRenderer.DisabeleLineRenderer();
        _endTouchPosition = Vector2.zero;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }
}
