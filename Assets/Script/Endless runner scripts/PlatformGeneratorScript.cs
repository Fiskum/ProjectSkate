using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorScript: MonoBehaviour
{
    public GameObject Buildarray;

    public Transform generationPoint;
    public float distanceBetween;

    public ObjectPooler[] theObjectPools;

    //public GameObject[] TheBuildings;
    private int BuildingSelector;
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector2 (transform.position.x + distanceBetween, transform.position.y);

            BuildingSelector = Random.Range(0, theObjectPools.Length);

            //Instantiate(theObjectPools[BuildingSelector], transform.position, transform.rotation);

            GameObject newBuilding = theObjectPools[BuildingSelector].GetPooledObject();

            newBuilding.transform.position = transform.position;
            newBuilding.transform.rotation = transform.rotation;
            newBuilding.SetActive(true);
            
        }
    }
}