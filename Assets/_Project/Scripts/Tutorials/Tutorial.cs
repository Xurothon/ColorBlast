using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _firstTutorial;
    [SerializeField] private GameObject _secondTutorial;
    private bool _isFirstTutorialComplete;
    private bool _isSecondTutorialComplete;

    public void CompleteTutorial()
    {
        if (!_isFirstTutorialComplete)
        {
            _isFirstTutorialComplete = true;
            DisableFirstTutorial();
            ActiveSecondTutorial();
        }
        else if (!_isSecondTutorialComplete)
        {
            _isFirstTutorialComplete = true;
            DisableSecondTutorial();
        }
    }

    private void DisableFirstTutorial()
    {
        _firstTutorial.SetActive(false);
    }

    private void ActiveSecondTutorial()
    {
        _secondTutorial.SetActive(true);
    }

    private void DisableSecondTutorial()
    {
        _secondTutorial.SetActive(false);
    }
}
