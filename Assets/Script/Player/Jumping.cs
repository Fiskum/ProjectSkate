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


    public GameObject Player;
  //  public EndlessLevelReset theReset;
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

        if(rb.bodyType != RigidbodyType2D.Static) // This if statement removes a very annoying Debug.Warning that has been spamming the Console. - Talha
            rb.velocity = v;
    }
    void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      //  if (collision.gameObject.tag == "Spikes")
        {
           // theReset.RestartGame();

        }

    }
}
