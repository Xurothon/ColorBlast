using UnityEngine;

public class CubeCover : MonoBehaviour
{
    public GameObject objectToPlaceRadiusPrefab;
    public int lengthCount, widthCount, heightCount;
    public Material[] materials;
    public int maxCoutMaterial;
    public bool isNew;
    public float positionSpeed;
    public float distance;
    private int currentMaterialIndex;
    private int countMaterial;

    private void Start()
    {
        if (isNew)
        {
            CoverNewSphere();
        }
        else
        {
            CoverThatSphere();
        }
        Destroy(this);
    }

    public void CoverNewSphere()
    {
        for (int h = 0; h < heightCount; h++)
        {
            GameObject thisHeight = new GameObject();
            thisHeight.transform.position = new Vector3(transform.position.x, transform.position.y + h, transform.position.z);
            thisHeight.transform.parent = transform;
            thisHeight.AddComponent<PositionRotator>().SetNewDirection((1 - 2 * (h % 2)) * positionSpeed, distance);

            currentMaterialIndex = 0;
            for (int w = 0; w < widthCount; w++)
            {
                for (int l = 0; l < lengthCount; l++)
                {
                    countMaterial++;
                    if (countMaterial == maxCoutMaterial)
                    {
                        countMaterial = 0;
                        currentMaterialIndex++;
                        if (currentMaterialIndex == materials.Length)
                            currentMaterialIndex = 0;
                    }
                    if (h == 0 || h == (heightCount - 1))
                        CreateSphere(new Vector3(thisHeight.transform.position.x + w, thisHeight.transform.position.y, thisHeight.transform.position.z + l), thisHeight.transform);
                    else
                    {
                        if (l == 0 || l == (lengthCount - 1))
                            CreateSphere(new Vector3(thisHeight.transform.position.x + w, thisHeight.transform.position.y, thisHeight.transform.position.z + l), thisHeight.transform);
                        else if (w == 0 || w == (widthCount - 1))
                            CreateSphere(new Vector3(thisHeight.transform.position.x + w, thisHeight.transform.position.y, thisHeight.transform.position.z + l), thisHeight.transform);
                    }
                }
            }
        }
    }

    public void CoverThatSphere()
    {
        for (int h = 0; h < heightCount; h++)
        {
            currentMaterialIndex = 0;
            for (int w = 0; w < widthCount; w++)
            {
                for (int l = 0; l < lengthCount; l++)
                {
                    countMaterial++;
                    if (countMaterial == maxCoutMaterial)
                    {
                        countMaterial = 0;
                        currentMaterialIndex++;
                        if (currentMaterialIndex == materials.Length)
                            currentMaterialIndex = 0;
                    }
                    if (h == 0 || h == (heightCount - 1))
                        CreateSphere(new Vector3(transform.position.x + w, h + transform.position.y, transform.position.z + l), transform);
                    else
                    {
                        if (l == 0 || l == (lengthCount - 1))
                            CreateSphere(new Vector3(transform.position.x + w, h + transform.position.y, transform.position.z + l), transform);
                        else if (w == 0 || w == (widthCount - 1))
                            CreateSphere(new Vector3(transform.position.x + w, h + transform.position.y, transform.position.z + l), transform);
                    }
                }
            }
        }
    }

    private void CreateSphere(Vector3 startPosition, Transform thisRow)
    {
        GameObject thisClonedObject = Instantiate(objectToPlaceRadiusPrefab, startPosition, Quaternion.identity, thisRow);
        thisClonedObject.GetComponent<RandomizeMaterial>().SetColorMaterialAndDestroyParticle(materials[currentMaterialIndex]);
    }
}