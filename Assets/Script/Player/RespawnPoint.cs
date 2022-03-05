using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnPoint : MonoBehaviour
{
    public GameObject Player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            Player.transform.position = new Vector2(-10, 0);
        }
        }

    }
