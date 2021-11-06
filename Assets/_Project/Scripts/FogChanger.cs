using UnityEngine;

public class FogChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private void Awake()
    {
        RenderSettings.fogColor = _colors[Random.Range(0, _colors.Length)];
    }
}
