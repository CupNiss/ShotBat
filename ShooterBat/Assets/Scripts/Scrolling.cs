using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -9.98f)
        {
           transform.position = startPosition;
        }
    }
}
