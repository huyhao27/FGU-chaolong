using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;

    private Vector2 movement;
    
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    float playerX, playerY;
    void Update()
    {
      
        movement.x = Input.GetAxisRaw("Horizontal");
        transform.localEulerAngles = new Vector3(0, movement.x < 0 ? 0 : 180, 0);
        // movement.y = Input.GetAxisRaw("Vertical");
        //flip
        
        // playerX = Input.GetAxisRaw("Horizontal");
        // playerY = Input.GetAxisRaw("Vertical");
        // movement.Normalize();
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
        animator.SetBool("isMove", movement.x!=0);
        // animator.SetFloat("Vertical", movement.y!=);
        
        
    }

    // private void FixedUpdate()
    // {
    //     playerX = transform.position.x;
    //     playerY = transform.position.y;
    //     Debug.Log("playerX: " + playerX + " playerY: " + playerY);
    // }
}
