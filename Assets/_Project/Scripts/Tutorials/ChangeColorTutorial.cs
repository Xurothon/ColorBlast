using DG.Tweening;
using UnityEngine;

public class ChangeColorTutorial : MonoBehaviour
{
    [SerializeField] private Vector3 _touchScalePointer;
    [SerializeField] private float _durationScale;
    [SerializeField] private Transform _pointer1;
    private Sequence _mySequence;

    private void Start()
    {
        _mySequence = DOTween.Sequence();
        StartTutorial();
    }

    public void StartTutorial()
    {
        _mySequence.Append(_pointer1.DOScale(_touchScalePointer, _durationScale))
            .Append(_pointer1.DOScale(new Vector3(1f, 1f, 1f), _durationScale).OnComplete(RepeatTutorial));
    }

    public void RepeatTutorial()
    {
        _mySequence.Restart();
    }

    private void OnDisable()
    {
        _mySequence.Kill();
    }
}
