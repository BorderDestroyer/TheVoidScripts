using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvBobbing : MonoBehaviour
{
    public Vector3 pointTwo;

    float _speed = 5f;

    bool startMoving = false;
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        if (startMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointTwo, _speed * Time.deltaTime);
        }

        if(transform.position == pointTwo)
        {
            startMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            startMoving = true;
        }
    }
}
