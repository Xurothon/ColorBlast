using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    public static SoundEffect Instance { get; private set; }
    private AudioSource _audioSource;

    public void PlaySoundEffect()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
}
