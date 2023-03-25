using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    public float Speed = 3f;
    public Vector2 Direction = Vector2.left;

    private Rigidbody2D SlimeRb;
    private SpriteRenderer SlimeRenderer;
    void Start()
    {
        SlimeRb = this.GetComponent<Rigidbody2D>();
        SlimeRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SlimeRb.velocity = Direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SlimeStop"))
        {
            SlimeRenderer.flipX = !SlimeRenderer.flipX;
            Direction.x *= -1;
        }
    }
}
