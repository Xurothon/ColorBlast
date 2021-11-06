using UnityEngine;
using UnityEngine.Advertisements;

public class AdHelper : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private StepClamp _stepClamp;
    [SerializeField] private MainSphere _mainSphere;
    [SerializeField] private int _addStepsCount;
    private string _placementAddSteps = "AddSteps";
    private string _placementAnotherObject = "AnotherObject";
    private string _placementEndLevel = "EndLevel";

    private void Start()
    {
        Advertisement.AddListener(this);
        if (Advertisement.isSupported)
            Advertisement.Initialize("4007487", false);
    }

    public void ShowAddSteps()
    {
        if (Advertisement.IsReady(_placementAddSteps))
            Advertisement.Show(_placementAddSteps);
    }

    public void ShowAnotherObject()
    {
        if (Advertisement.IsReady(_placementAnotherObject))
            Advertisement.Show(_placementAnotherObject);
    }


    public void ShowEndLevelInterstitial()
    {
        if (!DataWorker.Instance.IsBuyVip)
        {
            if (Advertisement.IsReady(_placementEndLevel))
                Advertisement.Show(_placementEndLevel);
        }
    }


    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId) { }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _placementAddSteps)
        {
            if (showResult == ShowResult.Finished)
            {
                _stepClamp.AddSteps(_addStepsCount);
                UIHelper.Instance.DisableGameOverPanel();
            }
        }
        else if (placementId == _placementAnotherObject)
        {
            if (showResult == ShowResult.Finished)
            {
                _mainSphere.ActivePushPin();
            }
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
