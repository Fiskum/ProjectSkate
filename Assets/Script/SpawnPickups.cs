using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public GameObject clockPickupPrefab;
    public float respawnTime = 5f;
    private Vector2 screenBounds;
    public Manager_Game manager_Game;
    public Transform player;
    private Vector3 cam;
    public bool allowPickupVibrations = true;

    [Header("PickupSpawnRange")]
    public float top = 10;
    public float bottom = 10;

    private void Start()
    {
        cam = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        StartCoroutine(pickupWave());
    }

    private void Update()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void SpawnPickup()
    { 
        if(manager_Game.isPaused == false)
        {
            GameObject a = Instantiate(clockPickupPrefab) as GameObject;
            a.transform.position = new Vector2(player.position.x + screenBounds.x + 5, Random.Range(player.position.y + top, player.position.y - bottom));
            a.GetComponent<ClockPickup>().allowVibrations = allowPickupVibrations;
        }
    }
    IEnumerator pickupWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnPickup();
        }
    }

    public void ToggleVibrations()
    {
        allowPickupVibrations = !allowPickupVibrations;
    }
}
