using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public GameObject clockPickupPrefab;
    public float respawnTime = 5f;
    private Vector2 screenBounds;
    public Manager_Game manager_Game;

    [Header("PickupSpawnRange")]
    public float top = 10;
    public float bottom = -10;

    private void Start()
    {
        StartCoroutine(pickupWave());
    }

    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void SpawnPickup()
    {
        GameObject a = Instantiate(clockPickupPrefab) as GameObject;
        a.transform.position = new Vector2(Camera.main.transform.position.x + screenBounds.x + 10, Random.Range(top, bottom));
    }
    IEnumerator pickupWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnPickup();
        }
    }
}
