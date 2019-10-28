using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeyboardInputManager : InputManager
{
    //Events that use the delagates
    public static event MoveInputHandler onMoveInput;
    public static event RotateInputHandler onRotateInput;
    public static event ZoomInputHandler onZoomInput;


    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            onMoveInput?.Invoke(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            onMoveInput?.Invoke(-Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            onMoveInput?.Invoke(-Vector3.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            onMoveInput?.Invoke(Vector3.right);
        }


        //Q and E for roatation
        if (Input.GetKey(KeyCode.E))
        {
            onRotateInput?.Invoke(-1f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            onRotateInput?.Invoke(1f);
        }

        //Zoom
        if (Input.GetKey(KeyCode.Z))
        {
            onZoomInput?.Invoke(-5f);
        }
        if (Input.GetKey(KeyCode.X))
        {
            onZoomInput?.Invoke(5f);
        }

    }
}
