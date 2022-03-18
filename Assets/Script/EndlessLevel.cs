using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    public GameObject Building;
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public float TimeBtwSpawn;
    private float SpawnTime;
    void Update()
    {
        if(Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBtwSpawn;
        }
    }
    void Spawn ()
    {
        float randomX = Random.Range(MinX, MaxX);
        float randomY = Random.Range(MinY, MaxY);

        Instantiate(Building, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
