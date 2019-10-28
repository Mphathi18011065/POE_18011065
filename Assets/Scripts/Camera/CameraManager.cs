using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraManager : MonoBehaviour
{
    [Header("Camera Positioning")]
    public Vector2 cameraOffset = new Vector2(10f, 14f);
    public float looAtOffset = 2f;

    [Header("Move Controls")]
    public float inOutSpeed = 5f;
    public float lateralSpeed = 5f;
    public float rotateSpeed = 4f;

    [Header("Move Around")]
    public Vector2 minBounds, maxRounds;

    [Header("Zoom controls")]
    public float zoomSpeed = 4f;
    public float nearZoomLimit = 2f;
    public float farZoomLimit = 16f;
    public float startingZoom = 5f;

    IZoomStrategy zoomStrategy;
    Vector3 frameMove;
    float frameRotate;
    float frameZoom;
    Camera cam;
    private float zoom;

    private void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            float zoomChangeAmount = 2.5f;

            cam.fieldOfView -= zoomChangeAmount - Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            float zoomChangeAmount = 2.5f;

            cam.fieldOfView += zoomChangeAmount;

        }
    }

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        cam.transform.localPosition = new Vector3(0f, Mathf.Abs(cameraOffset.y), -Mathf.Abs(cameraOffset.x));
        zoomStrategy = new OrthographicZoomStratey(cam, startingZoom);
        cam.transform.LookAt(transform.position + Vector3.up * looAtOffset);

    }

    private void OnEnable()
    {
        KeyboardInputManager.onMoveInput += UpdateFrameMove;
        KeyboardInputManager.onRotateInput += UpdateFrameRotate;
        KeyboardInputManager.onZoomInput += UpdateFrameZoom;

    }
    private void UpdateFrameMove(Vector3 moveVector)
    {
        frameMove += moveVector;
    }
    private void UpdateFrameRotate(float rotateAmount)
    {
        frameRotate += rotateAmount;
    }

    private void UpdateFrameZoom(float zoomAmount)
    {
        frameZoom += zoomAmount;
    }

    private void LateUpdate()
    {
        if (frameMove != Vector3.zero)
        {
            Vector3 speedModFrameMove = new Vector3(frameMove.x * lateralSpeed, frameMove.y, frameMove.z * inOutSpeed);
            transform.position += transform.TransformDirection(speedModFrameMove) * Time.deltaTime;
            LockPositionInBounds();
            frameMove = Vector3.zero;

        }
        if (frameRotate!= 0f)
        {
            transform.Rotate(Vector3.up, frameRotate * Time.deltaTime * rotateSpeed);
            frameZoom = 0f;
        }
        if (frameZoom <0f)
        {
            zoomStrategy.ZoomIn(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomSpeed, nearZoomLimit);
            frameZoom = 0f;

        }
        else if (frameZoom >0f)
        {
            zoomStrategy.ZoomOut(cam, Time.deltaTime * frameZoom * zoomSpeed, farZoomLimit);
            frameZoom = 0f;
        }
    }

    private void LockPositionInBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBounds.x, maxRounds.x), transform.position.y,
                                            Mathf.Clamp(transform.position.z, minBounds.y, maxRounds.y));
    }

    private void HandleZoom()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            float zoomChangeAmount = 80f;

            zoom -= zoomChangeAmount - Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            float zoomChangeAmount = 80f;

            zoom += zoomChangeAmount - Time.deltaTime;

        }
    }
}
