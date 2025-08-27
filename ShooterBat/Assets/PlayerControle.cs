using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    Rigidbody2D rb2D;
    float dirX;
    float dirY;
    float moveSpeed = 20f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      dirX = Input.acceleration.x * moveSpeed;
      dirY = Input.acceleration.y * moveSpeed;
      transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.9f, 1.9f), 
          Mathf.Clamp(transform.position.y, -4.0f, 3.5f));
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(dirX, dirY);
    }
}
