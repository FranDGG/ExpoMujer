using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Anim : MonoBehaviour
{
    //public float movementRange = 10f; // Range of movement for the button
    //public float movementSpeed = 1f; // Speed of movement
    public float rotationAngle = 15f; // Angle of rotation
    public float rotationSpeed = 1f; // Speed of rotation

    //private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        //originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate new position based on sine wave
        //float x = originalPosition.x + Mathf.Sin(Time.time * movementSpeed) * movementRange;
        //float y = originalPosition.y;
        //float z = originalPosition.z;
        //Vector3 newPosition = new Vector3(x, y, z);

        // Calculate new rotation based on cosine wave
        Quaternion newRotation = Quaternion.Euler(0f, 0f, Mathf.Cos(Time.time * rotationSpeed) * rotationAngle);

        // Apply new position and rotation to the button
        //transform.position = newPosition;
        transform.rotation = originalRotation * newRotation;
    }
}