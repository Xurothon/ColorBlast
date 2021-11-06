using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void LoadCurrentScene()
    {
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void LoadNextScene()
    {
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        DataWorker.Instance.SaveOpenSceneCount(index);
        index++;
        if (index == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings) index = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
