using UnityEngine;
using System.Collections.Generic;

public class SphereCover : MonoBehaviour
{
    public float mainObjectRadius, objectsToPlaceRadius;
    public GameObject objectToPlaceRadiusPrefab;
    public float fillFromPercentage, fillToPercentage;
    public bool pointTowardsCenter, randomizeHorizontalRotation;
    public List<GameObject> clonedObjectsList = new List<GameObject>();
    private int numberOfObjectsForThisLoop;
    public Material[] materials;
    public int maxCoutMaterial;
    public int step;
    public float speed;
    public Vector3 direction;
    private int currentMaterialIndex;
    private int countMaterial;

    public void Start()
    {
        CoverThatSphere();
        Destroy(this);
    }

    public void CoverThatSphere()
    {
        int numberOfRows = Mathf.CeilToInt((Mathf.PI * mainObjectRadius) / (objectsToPlaceRadius * 2));

        int startRow = Mathf.FloorToInt(numberOfRows * fillFromPercentage * 0.01f);
        int endRow = Mathf.CeilToInt(numberOfRows * fillToPercentage * 0.01f);

        float spaceBetweenRows = (2 * Mathf.PI * mainObjectRadius) / numberOfRows;
        int temp = 0;
        for (int rowNumber = startRow; rowNumber <= endRow; rowNumber++)
        {
            currentMaterialIndex = 0;
            float rowAngle = (rowNumber * spaceBetweenRows) / mainObjectRadius * 0.5f;
            float yPosition = mainObjectRadius * Mathf.Cos(rowAngle);

            GameObject thisRow = new GameObject();
            thisRow.transform.position = new Vector3(transform.position.x, transform.position.y + yPosition, transform.position.z);
            thisRow.transform.parent = transform;
            if (temp == step)
            {
                temp = 0;
                thisRow.AddComponent<RotationRotator>().SetNewDirection(speed, direction);
            }
            else
            {
                thisRow.AddComponent<RotationRotator>().SetNewDirection(-1 * speed, direction);
            }
            temp++;


            float radiusFromLoopHeight = Mathf.Sqrt((mainObjectRadius * mainObjectRadius) - (yPosition * yPosition));

            if (rowNumber == 0 || rowNumber == numberOfRows)
                numberOfObjectsForThisLoop = 1;
            else
                numberOfObjectsForThisLoop = Mathf.FloorToInt((2 * Mathf.PI * radiusFromLoopHeight) / (objectsToPlaceRadius * 2));

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
                    yPosition = mainObjectRadius;
                else if (rowNumber == numberOfRows)
                    yPosition = -mainObjectRadius;
                else
                {
                    thisAngle = ((ringObjectNumber) * spaceBetweenObjects) / radiusFromLoopHeight;
                    xPosition = radiusFromLoopHeight * Mathf.Sin(thisAngle);
                    zPosition = radiusFromLoopHeight * Mathf.Cos(thisAngle);
                }

                GameObject thisClonedObject = Instantiate(objectToPlaceRadiusPrefab, new Vector3(transform.position.x + xPosition, (yPosition + transform.position.y), transform.position.z + zPosition), Quaternion.identity, thisRow.transform);
                thisClonedObject.GetComponent<RandomizeMaterial>().SetColorMaterialAndDestroyParticle(materials[currentMaterialIndex]);
                if (pointTowardsCenter)
                {
                    GameObject thisClonedObjectShell = new GameObject();
                    thisClonedObjectShell.transform.position = thisClonedObject.transform.position;
                    thisClonedObjectShell.transform.parent = thisClonedObject.transform.parent;
                    thisClonedObject.transform.parent = thisClonedObjectShell.transform;

                    if (randomizeHorizontalRotation)
                        thisClonedObject.transform.localEulerAngles = new Vector3(Random.Range(0, 360), 90, -90);
                    else
                        thisClonedObject.transform.localEulerAngles = new Vector3(0, 90, -90);

                    thisClonedObjectShell.transform.LookAt(transform.position);

                    thisClonedObject.name = transform.name + " Object" + (clonedObjectsList.Count + 1).ToString();
                    thisClonedObjectShell.name = thisClonedObject.name + " Shell";
                    clonedObjectsList.Add(thisClonedObject);
                }
                else
                {
                    thisClonedObject.name = transform.name + " Object" + (clonedObjectsList.Count + 1).ToString();
                    clonedObjectsList.Add(thisClonedObject);
                }
            }
        }
    }
}