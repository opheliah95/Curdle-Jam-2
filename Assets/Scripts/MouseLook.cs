using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thanks, Brackeys-senpai.
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    public float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Keep it in the window, like a virus in a mask.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // X-axis -> Rotate player
        // Y-axis -> Rotate camera (w/ clamping)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
        // To allow for clamping, middle man it.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
} 
