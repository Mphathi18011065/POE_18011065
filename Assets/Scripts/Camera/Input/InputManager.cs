using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    //How we tell the caera manager that a acyion happened

    public delegate void MoveInputHandler(Vector3 moveVector3);
    public delegate void RotateInputHandler(float rotateAmount);
    public delegate void ZoomInputHandler(float zoomAmount);

}
