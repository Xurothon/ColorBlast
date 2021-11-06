using UnityEngine;

public class ShpereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _sphereForShootPrefab;
    [SerializeField] private GameObject _colorBallPrefab;
    [SerializeField] private MainSphere _mainSphere;
    [SerializeField] private StepClamp _stepClamp;
    [SerializeField] private SphereChecker _sphereChecker;

    public void SpawnObject(Vector3 startPosition, Vector3 direction)
    {
        if (_stepClamp.IsHaveStep())
        {
            _stepClamp.DeductStep();
            switch (_mainSphere.currentSphereType)
            {
                case Sphere.SIMPLE_SPHERE:
                    SpawnSphere(startPosition, direction);
                    _mainSphere.SetNextMaterial();
                    break;
                case Sphere.PUSH_PIN:
                    SpawnPushPin(startPosition, direction);
                    break;
            }
            _sphereChecker.CheckSphereCount();
        }
        else
            UIHelper.Instance.ActiveGameOverPanel();
    }

    private void SpawnSphere(Vector3 startPosition, Vector3 direction)
    {
        GameObject sphereObj = Instantiate(_sphereForShootPrefab);
        sphereObj.transform.position = startPosition;
        sphereObj.GetComponent<Rigidbody>().AddForce(direction * 2, ForceMode.Impulse);
        sphereObj.GetComponent<MeshRenderer>().sharedMaterial = _mainSphere.meshRenderer.sharedMaterial;
    }

    private void SpawnPushPin(Vector3 startPosition, Vector3 direction)
    {
        GameObject sphereObj = Instantiate(_colorBallPrefab);
        sphereObj.transform.position = startPosition;
        sphereObj.GetComponent<Rigidbody>().AddForce(direction * 2, ForceMode.Impulse);
        Destroy(sphereObj, 3f);
        _mainSphere.ActiveSphere();
    }
}