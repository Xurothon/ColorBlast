using UnityEngine;

public class BonusColorSphere : MonoBehaviour
{
    public static BonusColorSphere Instance { get { return _instance; } }
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private int _stepsForBonus;
    [SerializeField] private MainSphere _mainSphere;
    private float _stepFillAmount;
    private float _currentFillAmount;
    private static BonusColorSphere _instance;

    public void AddFillAmountStep()
    {
        _currentFillAmount += _stepFillAmount;
        if (_currentFillAmount == 1)
        {
            _currentFillAmount = 0;
            _mainSphere.ActivePushPin();
        }
        UpdateFillAmountImage();
    }

    public void ResetFillAmountStep()
    {
        _currentFillAmount = 0;
        UpdateFillAmountImage();
    }

    private void UpdateFillAmountImage()
    {
        _image.fillAmount = _currentFillAmount;
    }

    private void Awake()
    {
        _instance = this;
        _stepFillAmount = 1f / _stepsForBonus;
        UpdateFillAmountImage();
    }
}
