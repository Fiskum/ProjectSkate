using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpeed : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        Vector2 velocity = new Vector2(speed * Time.fixedDeltaTime,0);
        GetComponent<Rigidbody2D>().velocity = velocity;

    }
    public void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
