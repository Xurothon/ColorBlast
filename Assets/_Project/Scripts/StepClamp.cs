using UnityEngine;

public class StepClamp : MonoBehaviour
{
    [SerializeField] private int _stepCount;
    [SerializeField] private UnityEngine.UI.Text _stepCountText;

    public void DeductStep()
    {
        _stepCount--;
        UpdateText();
    }

    public bool IsHaveStep()
    {
        return _stepCount > 0;
    }

    public void AddSteps(int count)
    {
        _stepCount += count;
        UpdateText();
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _stepCountText.text = _stepCount.ToString();
    }
}
