using UnityEngine;

public class PushPin : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<RandomizeMaterial>())
        {
            SoundEffect.Instance.PlaySoundEffect();
            other.gameObject.GetComponent<RandomizeMaterial>().ActiveCollider();
            other.gameObject.GetComponent<RandomizeMaterial>().DestroyObject();
            Destroy(gameObject, 3f);
        }
    }
}
