using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;

    private bool _isJumping;
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

        movement.x = Input.GetAxis("Horizontal");
        if (movement.x != 0f)
        {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
            transform.localEulerAngles = new Vector3(0f, movement.x < 0f ? 0f : 180f, 0f);
        }
        // movement.y = Input.GetAxisRaw("Vertical");
        //flip

        // playerX = Input.GetAxisRaw("Horizontal");
        // playerY = Input.GetAxisRaw("Vertical");
        // movement.Normalize();
        animator.SetBool("isMove", movement.x != 0f);

        // animator.SetFloat("Vertical", movement.y!=);
        JumpHandling();

    }

    private void JumpHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isJumping) return;
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, speed);
            _isJumping = true;
        }
    }

    // private void FixedUpdate()
    // {
    //     playerX = transform.position.x;
    //     playerY = transform.position.y;
    //     Debug.Log("playerX: " + playerX + " playerY: " + playerY);
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
             animator.SetBool("isJumping", false);
            _isJumping = false;
        }
    }
}
