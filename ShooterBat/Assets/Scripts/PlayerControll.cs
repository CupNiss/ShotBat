using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public float moveSpeed;
    public float limitX = 5.0f;
    private float tiltAmount = 30.0f;
    private float tiltSmooth = 5;

    private bool invertControl = false;
    private Vector3 targetPosition;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        TouchController();
        Gyro();
    }

    private void TouchController()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0)
            {
                rb2D.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb2D.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    void Gyro()
    {
        float tilt = Input.acceleration.x;

        if (invertControl)
        {
            tilt = -tilt;
        }

        float moveX = tilt * moveSpeed * Time.deltaTime;

        targetPosition.x = Mathf.Clamp(transform.position.x + moveX, -limitX, limitX);
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(targetPosition, targetPosition, moveSpeed * Time.deltaTime);

        float targetTilt = -tilt * tiltAmount;

        Quaternion tiltRotation = Quaternion.Euler(0.0f, 0.0f, targetTilt);

        transform.rotation = Quaternion.Lerp(transform.rotation, tiltRotation, tiltAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
