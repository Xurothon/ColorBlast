using UnityEngine;

public class DataWorker : MonoBehaviour
{
    public static DataWorker Instance;
    public int OpenSceneCount { get; private set; }
    public bool IsBuyVip { get { return _vip == 1; } private set { } }
    private int _vip;

    public void SaveOpenSceneCount(int count)
    {
        if (count > OpenSceneCount)
        {
            OpenSceneCount = count;
            SaveValue(PlayerPrefsKeys.OPEN_SCENE_COUNT, OpenSceneCount);
        }
    }

    public void SaveVip()
    {
        _vip = 1;
        SaveValue(PlayerPrefsKeys.VIP, 1);
    }

    private void Awake()
    {
        Instance = this;
        ReadAllPlayerPrefs();
    }

    private void ReadAllPlayerPrefs()
    {
        OpenSceneCount = GetValue(PlayerPrefsKeys.OPEN_SCENE_COUNT);
        _vip = GetValue(PlayerPrefsKeys.VIP);
    }

    private int GetValue(PlayerPrefsKeys playerPrefsKey)
    {
        if (PlayerPrefs.HasKey(playerPrefsKey.ToString()))
        {
            return PlayerPrefs.GetInt(playerPrefsKey.ToString());
        }
        return GetDefaultValue(playerPrefsKey);
    }

    private void SaveValue(PlayerPrefsKeys playerPrefsKey, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKey.ToString(), value);
    }

    private int GetDefaultValue(PlayerPrefsKeys playerPrefsKey)
    {
        switch (playerPrefsKey)
        {
            default:
                return 0;
        }
    }
}
