using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;

    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float playerX, playerY;
    void Update()
    {
      
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
  
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
    }

}
