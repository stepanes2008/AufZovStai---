﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject playerBody;
    public float jumpForce;
    private float _fallVelocity = 0f;
    public float speed = 5f;
    public GameObject Player;
    CharacterController _controller;
    Vector3 _move;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player.GetComponent<Animator>().SetBool("isRunning", false);

        if (!GetComponent<PlayerHealth>().isDead)
        {
            _move = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
            {
                _fallVelocity = -jumpForce;
                playerBody.GetComponent<Animator>().SetTrigger("Jump");
            }
            if (Input.GetKey(KeyCode.W))
            {
                _move += transform.forward;
                playerBody.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _move += transform.forward;
                playerBody.GetComponent<Animator>().SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _move -= transform.right;
                playerBody.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _move -= transform.right;
                playerBody.GetComponent<Animator>().SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _move -= transform.forward;
                playerBody.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _move -= transform.forward;
                playerBody.GetComponent<Animator>().SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _move += transform.right;
                playerBody.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _move += transform.right;
                playerBody.GetComponent<Animator>().SetBool("isRunning", false);
            }
        }
    }

    void FixedUpdate()
    {
        _controller.Move(_move * 6 * Time.fixedDeltaTime);
        _fallVelocity += 9.8f * Time.fixedDeltaTime;
        _controller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_controller.isGrounded)
        {
            _fallVelocity = 0f;
        }
    }
}

