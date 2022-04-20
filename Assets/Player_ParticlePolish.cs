using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ParticlePolish : MonoBehaviour
{
    ParticleSystem[] particles;
    Animator anim;

    public float height = 1.38f;

    float lastX;
    void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool horizontalMovement = transform.position.x != lastX;
        lastX = transform.position.x;

        Debug.DrawRay(transform.position, Vector2.down * height);

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, height);


        anim.SetBool("isGrounded", isGrounded);

        for (int i = 0; i < particles.Length; i++)
            particles[i].enableEmission = isGrounded && horizontalMovement;
    }
}
