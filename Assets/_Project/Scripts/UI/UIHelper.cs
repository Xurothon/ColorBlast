using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    public static UIHelper Instance;
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private AdHelper _adHelper;
    [SerializeField] private Text _currentLevelText;

    public void ActiveLevelComplete()
    {
        _adHelper.ShowEndLevelInterstitial();
        _levelCompletePanel.SetActive(true);
    }

    public void ActiveGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void DisableGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
        _currentLevelText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
