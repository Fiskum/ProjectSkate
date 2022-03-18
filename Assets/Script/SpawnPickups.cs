using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public GameObject clockPickupPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    public Manager_Game manager_Game;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(pickupWave());
    }
    private void SpawnPickup()
    {
        GameObject a = Instantiate(clockPickupPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y + 3, screenBounds.y - 3));
    }
    IEnumerator pickupWave()
    {
        while (manager_Game.timer_unPause < 0)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnPickup();
        }
    }
}
