using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(AudioSource))]
public class CollisionChecker : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private bool _isCollision;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(DestroySphere());
        Destroy(gameObject, 3f);
    }

    private System.Collections.IEnumerator DestroySphere()
    {
        yield return new WaitForSeconds(2f);
        if (!_isCollision)
        {
            BonusColorSphere.Instance.ResetFillAmountStep();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<RandomizeMaterial>())
        {
            if (other.gameObject.GetComponent<RandomizeMaterial>().meshRenderer.material.name == _meshRenderer.material.name)
            {
                _isCollision = true;
                SoundEffect.Instance.PlaySoundEffect();
                other.gameObject.GetComponent<RandomizeMaterial>().ActiveCollider();
                BonusColorSphere.Instance.AddFillAmountStep();
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
