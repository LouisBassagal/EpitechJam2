using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkierManager : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D SkierRb;
    private Vector3 StartingPosition;
    void Start()
    {
        SkierRb = this.GetComponent<Rigidbody2D>();
        StartingPosition = this.transform.position;
    }

    void FixedUpdate()
    {
        SkierRb.velocity = new Vector3(1 * Speed, -1 * Speed, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ResetSkier"))
        {
            this.transform.position = StartingPosition;
        }
    }
}
