using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public CharacterController2D controller;

    public float _speed = 40;
    public bool jump = false;

    float horizontalMovement = 0f;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * _speed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
