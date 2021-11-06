using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdBanner : MonoBehaviour
{
    private string _placementBanner = "Banner";

    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4007487", false);
            StartCoroutine(ShowBannerWhenInitialized());
        }
    }

    private IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(_placementBanner);
    }
}
