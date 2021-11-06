using UnityEngine;

[RequireComponent(typeof(UIGradient))]
public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private UIGradient _uiGradient;
    private void Start()
    {
        _uiGradient = GetComponent<UIGradient>();
        SetRandomColors();
    }

    private void SetRandomColors()
    {
        _uiGradient.m_color1 = _colors[Random.Range(0, _colors.Length)];
        Color temp = _colors[Random.Range(0, _colors.Length)];
        while (_uiGradient.m_color1 == temp)
        {
            temp = _colors[Random.Range(0, _colors.Length)];
        }
        _uiGradient.m_color2 = temp;
    }
}
