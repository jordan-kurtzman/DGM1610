using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPC : MonoBehaviour
{
    public float moveSpeed;
    private float hMove;
    private float vMove;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (hMove * moveSpeed, vMove * moveSpeed);
    }   

    void Move()
    {
       hMove = Input.GetAxis("Horizontal") * moveSpeed;
       vMove = Input.GetAxis("Vertical") * moveSpeed;

    }

    void Update()
    {
        Move();
    }
}
