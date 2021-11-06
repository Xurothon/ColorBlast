using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private int _pointCount;
    [SerializeField] private Material[] _simpleMaterials;
    private LineRenderer _linerRenderer;
    private MeshRenderer _oldMesh;
    private int _indexColor;

    public void ShowTrajectory(Vector3 initialPosition, Vector3 speed)
    {
        Vector3[] points = new Vector3[_pointCount];
        _linerRenderer.positionCount = _pointCount;
        for (int i = 0; i < _pointCount; i++)
        {
            float time = i * 0.1f;
            points[i] = initialPosition + speed * time + Physics.gravity * time * time / 2f;
        }
        _linerRenderer.SetPositions(points);
    }

    public void DisabeleLineRenderer()
    {
        _linerRenderer.positionCount = 0;
    }

    private int GetIndexMaterial(Material material)
    {
        for (int i = 0; i < _simpleMaterials.Length; i++)
        {
            if (material.color == _simpleMaterials[i].color)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        if (_linerRenderer.positionCount > 0)
        {
            Color colour;
            RaycastHit hit;
            if (Physics.Raycast(_linerRenderer.GetPosition(1), _linerRenderer.GetPosition(_linerRenderer.positionCount - 1) - _linerRenderer.GetPosition(1), out hit))
            {
                if (hit.collider.gameObject.GetComponent<RandomizeMaterial>())
                {
                    if (hit.collider.gameObject.GetComponent<MeshRenderer>() != _oldMesh)
                    {
                        if (_oldMesh)
                        {
                            _oldMesh.material = _simpleMaterials[_indexColor];
                        }
                        _oldMesh = hit.collider.gameObject.GetComponent<MeshRenderer>();

                        colour = _oldMesh.material.color;
                        _indexColor = GetIndexMaterial(_oldMesh.material);
                        colour *= 50f;
                        _oldMesh.material.color = colour;
                    }
                }
            }
        }
        else
        {
            if (_oldMesh)
            {
                _oldMesh.material = _simpleMaterials[_indexColor]; ;
            }
        }
    }

    private void Start()
    {
        _linerRenderer = GetComponent<LineRenderer>();
    }
}