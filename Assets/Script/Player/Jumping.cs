using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jumping : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == Mathf.Round(rb.velocity.y))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        Vector2 v = rb.velocity;
        v.x = speed;
        rb.velocity = v;
        GetComponent<Rigidbody2D>().velocity = v;
    }
    void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
