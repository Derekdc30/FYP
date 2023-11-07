using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movemennt : MonoBehaviour
{
    public float speed;
    Vector2 movement;
    public Rigidbody2D rb;
    void Start()
    {

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed);
    }
}