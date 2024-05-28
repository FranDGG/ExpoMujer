using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonBicho : MonoBehaviour
{
    public float speed = 2f;
    public float rotationAngle = 15f; // Angle of rotation
    public float rotationSpeed = 1f; // Speed of rotation

    private Quaternion originalRotation;

    public bool shouldMove = false;

    void Start()
    {
        originalRotation = transform.rotation;
        
    }
    private void Update()
    {

        if (shouldMove)
        {

            // Movimiento hacia abajo
            transform.Translate(Vector3.up * speed * Time.deltaTime);     

            // Calculate new rotation based on cosine wave
            Quaternion newRotation = Quaternion.Euler(0f, 0f, Mathf.Cos(Time.time * rotationSpeed) * rotationAngle);

            // Apply new position and rotation to the button
            transform.rotation = originalRotation * newRotation;

            // Apply new position and rotation to the button
            transform.rotation = originalRotation * newRotation;

            if (transform.position.y < -10f)
            {
                float screenWidth = Screen.width;
                float screenHeight = Screen.height;

                // Calcular un rango para las coordenadas x y y basado en la resolución de la pantalla
                float minX = screenWidth * 0.02f; // 2% del ancho de la pantalla
                float maxX = screenWidth * 0.98f; // 98% del ancho de la pantalla
                float minY = screenHeight * 1.10f; // 110% del alto de la pantalla
                float maxY = screenHeight * 1.15f; // 110% del alto de la pantalla

                // Generar coordenadas de posición aleatorias dentro del rango calculado
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);

                transform.position = new Vector3(randomX, randomY, 0f);
            }

        }  
    }

    

    // Método para activar o desactivar el movimiento
    public void SetShouldMove(bool move)
    {
        shouldMove = move;
    }

}
