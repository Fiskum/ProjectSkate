using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingendlessly : MonoBehaviour
{
    public float x;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0);

    
    }
}