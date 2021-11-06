using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    [SerializeField] private Sprite _musicOnSprite;
    [SerializeField] private Sprite _musicOffSprite;
    [SerializeField] private UnityEngine.UI.Image _musicImage;
    private bool _isMusicOn;

    public void ChangeMusicValue()
    {
        _isMusicOn = !_isMusicOn;
        if (_isMusicOn)
            OnMusic();
        else
            OffMusic();

    }

    private void Start()
    {
        OnMusic();
    }

    private void OnMusic()
    {
        _musicImage.sprite = _musicOnSprite;
        _isMusicOn = true;
    }

    private void OffMusic()
    {
        _musicImage.sprite = _musicOffSprite;
        _isMusicOn = false;
    }
}
