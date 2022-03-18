using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPickup : MonoBehaviour
{
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager_Game.GetManager().timer += 5;
            Destroy(this.gameObject);
        }
    }
}
