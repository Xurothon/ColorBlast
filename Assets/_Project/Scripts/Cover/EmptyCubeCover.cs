using UnityEngine;

public class EmptyCubeCover : MonoBehaviour
{
    public GameObject objectToPlaceRadiusPrefab;
    public int lengthCount, widthCount, heightCount;
    public Material[] materials;
    public int maxCoutMaterial;
    private int currentMaterialIndex;
    private int countMaterial;

    private void Start()
    {
        CoverSphere();
        Destroy(this);
    }

    public void CoverSphere()
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
                    if (l == 0 || l == (lengthCount - 1))
                        CreateSphere(new Vector3(transform.position.x + w, h + transform.position.y, transform.position.z + l), transform);
                    else if (w == 0 || w == (widthCount - 1))
                        CreateSphere(new Vector3(transform.position.x + w, h + transform.position.y, transform.position.z + l), transform);
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
