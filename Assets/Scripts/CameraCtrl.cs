using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float sensitivity = 100f; // 控制旋转速度
    private float xRotation = 0f;
    private float yRotation = 0f;
    private bool isDragging = false;
    private Vector2 mouseStartPos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            mouseStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - mouseStartPos;

            float mouseX = mouseDelta.x * sensitivity * Time.deltaTime;
            float mouseY = mouseDelta.y * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制垂直旋转范围

            yRotation += mouseX;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

            mouseStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
