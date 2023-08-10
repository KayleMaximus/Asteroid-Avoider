using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _roatationSpeed;
    private Camera _mainCamera;
    private Rigidbody _rb;

    private Vector3 _movementDirection;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }
    
    private void FixedUpdate()
    {
        if (_movementDirection == Vector3.zero) { return; }

        _rb.AddForce(_movementDirection * _forceMagnitude * Time.deltaTime, ForceMode.Force);

        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }
    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            //Get Input
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
            //Translate the plane
            _movementDirection = transform.position - worldPosition;
            _movementDirection.z = 0f;
            _movementDirection.Normalize(); //Care about DIRECTION not MAGNITUDE
        }
        else
        {
            _movementDirection = Vector3.zero;
        }
    }

    private void RotateToFaceVelocity()
    {
        if(_rb.velocity == Vector3.zero) return;

        Quaternion targetLocation = Quaternion.LookRotation(_rb.velocity,Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetLocation, _roatationSpeed * Time.deltaTime);   
    }
}
