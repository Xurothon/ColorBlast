using UnityEngine;
using Mycom.Tracker.Unity;

public class myTracker : MonoBehaviour
{
    public static myTracker Instance { get { return _instance; } }

    private static myTracker _instance;
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
#if !UNITY_IOS && !UNITY_ANDROID
        return;

#endif
#if UNITY_ANDROID
        var myTrackerConfig = MyTracker.MyTrackerConfig;
        MyTracker.MyTrackerParams.CustomUserId = "colorblast";
        MyTracker.Init("17830752085820145440");
        MyTracker.TrackRegistrationEvent(MyTracker.MyTrackerParams.CustomUserId);
#endif
    }
}
