using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public Vector3 pointOne;
    public Vector3 pointTwo;

    float _speed = .25f;

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(pointOne, pointTwo, Mathf.PingPong(Time.time * _speed, 1.0f));
    }
}
