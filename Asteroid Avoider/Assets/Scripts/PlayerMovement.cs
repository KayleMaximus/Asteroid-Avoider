using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCamera;


    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if( Touchscreen.current.primaryTouch.press.isPressed){
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Debug.Log(touchPosition);

            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            Debug.Log(worldPosition);
        }
    }
}
