using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator Animator;
    private float _horizontalMove = 0f;
    private bool _jump = false;
    private bool _crouch = false;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsCrouching = Animator.StringToHash("isCrouching");

    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        Animator.SetFloat(Speed, Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            Animator.SetBool(IsJumping, true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            _crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            _crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }

    public void OnLanding()
    {
        Animator.SetBool(IsJumping, false);
    }

    public void OnCrouching(bool isCrouching)
    {
        Animator.SetBool(IsCrouching, isCrouching);
    }
}