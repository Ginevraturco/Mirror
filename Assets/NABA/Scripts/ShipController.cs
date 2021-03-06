﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ShipController : MonoBehaviour
{
    public float speed = 3;

    public float rotationSpeed = 3;

    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        transform.Rotate(0, hMove * rotationSpeed, 0);

        vMove = Mathf.Clamp(vMove, 0, 1);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float currentSpeed = speed * vMove;
        _controller.SimpleMove(forward * currentSpeed);
    }
}
