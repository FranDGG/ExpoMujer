using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTactil : MonoBehaviour
{
    // Escala mínima y máxima permitida
    public float escalaMinima = 0.5f;
    public float escalaMaxima = 2.0f;

    // Factor de escala
    public float factorEscala = 0.1f;

    // Variable para almacenar la escala inicial
    private Vector3 escalaInicial;

    void Start()
    {
        // Almacenar la escala inicial
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        // Verificar la entrada táctil en dispositivos móviles
        if (Input.touchCount == 2)
        {
            // Obtener los dos primeros toques
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Calcular la distancia entre los dos toques en el marco actual y el marco anterior
            Vector2 touchDeltaPosition0 = touch0.position - touch0.deltaPosition;
            Vector2 touchDeltaPosition1 = touch1.position - touch1.deltaPosition;
            float distanciaAnterior = Vector2.Distance(touchDeltaPosition0, touchDeltaPosition1);
            float distanciaActual = Vector2.Distance(touch0.position, touch1.position);

            // Calcular la diferencia entre las distancias y escalar el objeto en consecuencia
            float diferenciaDistancia = distanciaActual - distanciaAnterior;
            EscalarUI(diferenciaDistancia * factorEscala);
        }
    }

    void EscalarUI(float deltaEscala)
    {
        // Calcular la nueva escala
        Vector3 nuevaEscala = transform.localScale + Vector3.one * deltaEscala;

        // Limitar la escala dentro del rango mínimo y máximo
        nuevaEscala.x = Mathf.Clamp(nuevaEscala.x, escalaMinima * escalaInicial.x, escalaMaxima * escalaInicial.x);
        nuevaEscala.y = Mathf.Clamp(nuevaEscala.y, escalaMinima * escalaInicial.y, escalaMaxima * escalaInicial.y);

        // Aplicar la nueva escala al objeto
        transform.localScale = nuevaEscala;
    }
}
