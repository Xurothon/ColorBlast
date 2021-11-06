using UnityEngine;
using System.Collections;

public class SphereChecker : MonoBehaviour
{
    [SerializeField] private Transform[] _parentsForSpawnObject;

    public void CheckSphereCount()
    {
        StartCoroutine(CheckSphere());
    }

    private IEnumerator CheckSphere()
    {
        yield return new WaitForSeconds(4.5f);
        int childCout = 0;
        for (int i = 0; i < _parentsForSpawnObject.Length; i++)
        {
            for (int j = 0; j < _parentsForSpawnObject[i].childCount; j++)
            {
                childCout += _parentsForSpawnObject[i].GetChild(j).childCount;
            }
        }
        if (childCout == 0)
            UIHelper.Instance.ActiveLevelComplete();
    }
}
