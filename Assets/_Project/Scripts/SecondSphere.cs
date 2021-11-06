using UnityEngine;

public class SecondSphere : MonoBehaviour
{
    [SerializeField] protected MainSphere _mainSphere;

    public void ChangeColor()
    {
        _mainSphere.SwapMaterials();
    }
}
