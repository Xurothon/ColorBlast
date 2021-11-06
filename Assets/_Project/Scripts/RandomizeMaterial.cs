using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class RandomizeMaterial : MonoBehaviour
{
    public MeshRenderer meshRenderer { get; private set; }
    [SerializeField] private SphereCollider _sphereCollider;
    private Rigidbody _rigidbody;
    private bool _isDestroy;

    public void ActiveCollider()
    {
        _sphereCollider.enabled = true;
    }

    public void DestroyObject()
    {
        if (!_isDestroy)
        {
            _isDestroy = true;
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            meshRenderer.material.color *= 1.2f;
            Destroy(gameObject, 2.5f);
        }
    }

    public void SetColorMaterialAndDestroyParticle(Material material)
    {
        meshRenderer.sharedMaterial = material;
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RandomizeMaterial>())
        {
            RandomizeMaterial tempMat = other.GetComponent<RandomizeMaterial>();
            if (tempMat.meshRenderer.material.name == meshRenderer.material.name)
            {
                DestroyObject();
                tempMat.ActiveCollider();
            }
        }
    }
}