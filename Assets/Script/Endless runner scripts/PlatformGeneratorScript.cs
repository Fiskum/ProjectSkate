using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorScript: MonoBehaviour
{
    //public GameObject Buildarray;

    public Transform generationPoint;
    public float distanceBetween;

    public ObjectPooler[] theObjectPools;


    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    //public GameObject[] TheBuildings;
    private int BuildingSelector;
    void Start()
    {
        if (generationPoint == null) // If this variable is null, then skip this script entirely. I have a feeling this script isn't even in use anymore, but I won't take the responsibility of removing it. I did remove the error this produced by being 'null' though. - Talha
            return;

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }
    void Update()
    {
        if (generationPoint == null) // If this variable is null, then skip this script entirely. I have a feeling this script isn't even in use anymore, but I won't take the responsibility of removing it. I did remove the error this produced by being 'null' though. - Talha
            return;

        if (transform.position.x < generationPoint.position.x)
        {

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector2 (transform.position.x + distanceBetween, heightChange);


            BuildingSelector = Random.Range(0, theObjectPools.Length);

            //Instantiate(theObjectPools[BuildingSelector], transform.position, transform.rotation);

            GameObject newBuilding = theObjectPools[BuildingSelector].GetPooledObject();

            newBuilding.transform.position = transform.position;
            newBuilding.transform.rotation = transform.rotation;
            newBuilding.SetActive(true);
            
        }
    }
}