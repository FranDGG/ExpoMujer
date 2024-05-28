using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptBichos : MonoBehaviour
{
    public float speed = 2f;
    public float rotationAngle = 15f; // Angle of rotation
    public float rotationSpeed = 1f; // Speed of rotation

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        //imagen = GetComponent<Image>();
    }

    private void Update()
    {
        // Movimiento hacia abajo
        transform.Translate(Vector3.up * speed * Time.deltaTime);             

        // Calculate new rotation based on cosine wave
        Quaternion newRotation = Quaternion.Euler(0f, 0f, Mathf.Cos(Time.time * rotationSpeed) * rotationAngle);

        // Apply new position and rotation to the button
        transform.rotation = originalRotation * newRotation;

        // Apply new position and rotation to the button
        transform.rotation = originalRotation * newRotation;

        // Si el bicho alcanza la parte inferior de la pantalla, vuelve arriba
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(Random.Range(20f, 1060f), 2300f, 0f);
        }
    }
}

