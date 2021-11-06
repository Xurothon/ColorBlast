using UnityEngine;
using UnityEngine.UI;

public class LevelActivator : MonoBehaviour
{
    [SerializeField] private Button[] _levelButton;
    [SerializeField] private Color _color;

    private void Start()
    {
        int openSceneCount = DataWorker.Instance.OpenSceneCount + 1;
        for (int i = 0; i < openSceneCount; i++)
        {
            _levelButton[i].interactable = true;
            Image image = _levelButton[i].GetComponent<Image>();
            image.color = _color;
        }
    }
}
