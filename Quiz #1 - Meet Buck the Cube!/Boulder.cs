using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boulder : MonoBehaviour
{
    [Header("Rock Settings")]
    public float speed = 3f;
    public bool startMovingRight = true;

    private Rigidbody2D rb;
    private int direction;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = startMovingRight ? 1 : -1;
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BuckController buck = collision.gameObject.GetComponent<BuckController>();
            if (buck != null) buck.Die();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}
