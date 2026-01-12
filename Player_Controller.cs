using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private int lastHorizontalInput = 0; // -1 для A, 1 для D, 0 - ничего

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float JumpForce = 8f;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Обработка ввода с приоритетом последней клавиши
        HandleInputWithPriority();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void HandleInputWithPriority()
    {
        // Обновляем последнюю нажатую клавишу
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastHorizontalInput = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastHorizontalInput = 1;
        }

        // Если обе клавиши отпущены, сбрасываем
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            lastHorizontalInput = 0;
        }

        // Применяем движение на основе последней нажатой клавиши
        HorizontalMove = lastHorizontalInput * speed;
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        isGrounded = colliders.Length > 1;
    }
}