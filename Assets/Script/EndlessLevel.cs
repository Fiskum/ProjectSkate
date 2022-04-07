using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    public float MinY;
    public float MaxY;
    public float Zvalue;
    public float TimeBtwSpawn;
    public float SpawnTime;
    public ArrayList buildings;
    public GameObject[] Buildarray;

    
    void FixedUpdate()
    {
        if (Time.time > SpawnTime)
        {
            SpawnTime = Time.time + TimeBtwSpawn;
            Spawn();
        }
    }
    void Spawn ()
    {
      
        float randomY = Random.Range(MinY, MaxY);
        int Buildspawn = Random.Range(0, Buildarray.Length);
   
        Instantiate(Buildarray[Buildspawn], transform.position + new Vector3(0, randomY, Zvalue), transform.rotation);
        //GameObject.Find("Slider").GetComponent<BuildingSlider>();

    }
}
