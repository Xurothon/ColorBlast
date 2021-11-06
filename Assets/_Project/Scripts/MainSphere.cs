using UnityEngine;

public class MainSphere : MonoBehaviour
{
    public MeshRenderer meshRenderer { get; private set; }
    public Sphere currentSphereType { get; private set; }
    [SerializeField] private GameObject _sphere;
    [SerializeField] private MeshRenderer _sphere1;
    [SerializeField] private GameObject _pushPin;
    [SerializeField] private Material[] _materials;
    private int currentColorMaterial;

    public void SetNextMaterial()
    {
        meshRenderer.sharedMaterial = _sphere1.sharedMaterial;
        int nextIndex1 = GetNextIndex(currentColorMaterial);
        _sphere1.sharedMaterial = _materials[nextIndex1];
        currentColorMaterial++;
        if (currentColorMaterial == _materials.Length)
            currentColorMaterial = 0;
    }

    public void ActiveSphere()
    {
        currentSphereType = Sphere.SIMPLE_SPHERE;
        _pushPin.SetActive(false);
        _sphere.SetActive(true);
    }

    public void ActivePushPin()
    {
        currentSphereType = Sphere.PUSH_PIN;
        _sphere.SetActive(false);
        _pushPin.SetActive(true);
    }

    public void SwapMaterials()
    {
        Material tempMaterial = _sphere1.sharedMaterial;
        _sphere1.sharedMaterial = meshRenderer.sharedMaterial;
        meshRenderer.sharedMaterial = tempMaterial;
    }

    private int GetNextIndex(int index)
    {
        index++;
        if (index >= _materials.Length) index -= _materials.Length;
        return index;
    }

    private void Start()
    {
        meshRenderer = _sphere.GetComponent<MeshRenderer>();
        ActiveSphere();
        SetMaterial();
    }

    public void SetMaterial()
    {
        meshRenderer.sharedMaterial = _materials[currentColorMaterial];
        int nextIndex1 = GetNextIndex(currentColorMaterial);
        _sphere1.sharedMaterial = _materials[nextIndex1];
        currentColorMaterial++;
    }
}