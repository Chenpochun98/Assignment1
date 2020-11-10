using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public Transform playerBody;
    public float mousesens = 1000.0f;
    public float xRotation = 0.0f;
    public float maxRotation = 90.0f; 
    public float minRotation = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * mousesens * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mousesens * Time.deltaTime;

        xRotation -= moveY;
        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * moveX);
    }
}
