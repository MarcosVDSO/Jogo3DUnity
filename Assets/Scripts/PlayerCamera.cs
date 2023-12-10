using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private float sensitivity;
    [SerializeField] private RectTransform crosshair;
    
    private Transform playerTransform;
    private float inputX, inputY, rotationX, rotationY;


    
    void Start()
    {
        playerTransform = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        inputX = Input.GetAxis("Mouse Y");
        inputY = Input.GetAxis("Mouse X");

        rotationX -= inputX * sensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -60, 60);

        rotationY += inputY * sensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(0, rotationY, 0), Time.deltaTime);

    }

}
