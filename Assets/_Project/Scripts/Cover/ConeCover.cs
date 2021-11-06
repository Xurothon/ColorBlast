using UnityEngine;
using System.Collections.Generic;


public class ConeCover : MonoBehaviour
{
    public float mainObjectHeight, objectsToPlaceRadius, coneWidthAdjustment;
    public GameObject objectsToPlaceRadiusPrefab;
    public float fillFromPercentage, fillToPercentage;
    public List<GameObject> clonedObjectsList = new List<GameObject>();
    public bool isInverse;
    public Material[] materials;
    public float rotationSpeed;
    public Vector3 rotationDirection;
    public int step;
    public int maxCoutMaterial;
    private int currentMaterialIndex;
    private int countMaterial;
    private int numberOfObjectsForThisLoop;


    public void Start()
    {
        CoverThatCone();
        Destroy(this);
    }

    public void CoverThatCone()
    {
        int numberOfRows = Mathf.CeilToInt(mainObjectHeight / (objectsToPlaceRadius * 2));

        int startRow = Mathf.FloorToInt(numberOfRows * fillFromPercentage * 0.01f);
        int endRow = Mathf.CeilToInt(numberOfRows * fillToPercentage * 0.01f);

        float spaceBetweenRows = objectsToPlaceRadius * 2 / numberOfRows;
        int temp = 0;
        for (int rowNumber = startRow; rowNumber <= endRow; rowNumber++)
        {
            currentMaterialIndex = 0;
            float yPosition = mainObjectHeight - (rowNumber * objectsToPlaceRadius * 2);

            GameObject thisRow = new GameObject();
            thisRow.transform.position = new Vector3(transform.position.x, transform.position.y + yPosition, transform.position.z);
            thisRow.transform.parent = transform;

            if (temp == step)
            {
                temp = 0;
                thisRow.AddComponent<RotationRotator>().SetNewDirection(rotationSpeed, rotationDirection);
            }
            else
            {
                thisRow.AddComponent<RotationRotator>().SetNewDirection(-1 * rotationSpeed, rotationDirection);
            }
            temp++;

            float radiusFromLoopHeight = (rowNumber * objectsToPlaceRadius * coneWidthAdjustment);

            if (rowNumber == 0)
                numberOfObjectsForThisLoop = 1;
            else
            {
                numberOfObjectsForThisLoop = Mathf.FloorToInt((2 * Mathf.PI * radiusFromLoopHeight) / (objectsToPlaceRadius * 2));

                if (numberOfObjectsForThisLoop == 1 && rowNumber == 1)
                    numberOfObjectsForThisLoop = 2;
            }

            float spaceBetweenObjects = (2 * Mathf.PI * radiusFromLoopHeight) / numberOfObjectsForThisLoop;

            for (int ringObjectNumber = 1; ringObjectNumber <= numberOfObjectsForThisLoop; ringObjectNumber++)
            {
                countMaterial++;
                if (countMaterial == maxCoutMaterial)
                {
                    countMaterial = 0;
                    currentMaterialIndex++;
                    if (currentMaterialIndex == materials.Length)
                        currentMaterialIndex = 0;
                }
                float xPosition = 0;
                float zPosition = 0;
                float thisAngle = 0;

                if (rowNumber == 0)
                    yPosition = mainObjectHeight;
                else
                {
                    thisAngle = ((ringObjectNumber) * spaceBetweenObjects) / radiusFromLoopHeight;
                    xPosition = radiusFromLoopHeight * Mathf.Sin(thisAngle);
                    zPosition = radiusFromLoopHeight * Mathf.Cos(thisAngle);
                }

                bool spawnLoopFinished = false;

                while (!spawnLoopFinished)
                {
                    GameObject thisClonedObject = null;
                    if (!isInverse)
                        thisClonedObject = Instantiate(objectsToPlaceRadiusPrefab, new Vector3(transform.position.x + xPosition, (yPosition + transform.position.y), transform.position.z + zPosition), Quaternion.identity, thisRow.transform);
                    else
                        thisClonedObject = Instantiate(objectsToPlaceRadiusPrefab, new Vector3(transform.position.x + xPosition, (-yPosition + transform.position.y), transform.position.z + zPosition), Quaternion.identity, thisRow.transform);

                    thisClonedObject.name = transform.name + " Object" + (clonedObjectsList.Count + 1).ToString();
                    thisClonedObject.GetComponent<RandomizeMaterial>().SetColorMaterialAndDestroyParticle(materials[currentMaterialIndex]);
                    clonedObjectsList.Add(thisClonedObject);
                    spawnLoopFinished = true;
                }
            }
        }
    }
}