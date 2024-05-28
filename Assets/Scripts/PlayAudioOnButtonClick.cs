using UnityEngine;
using UnityEngine.UI;

public class PlayAudioOnButtonClick : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource
    private bool reproduciendo = false; //Indica si el audio ha comenzado o finalizado

    void Start()
    {
        // Busca automáticamente el componente AudioSource si no se ha asignado en el editor
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    void Update()
    {
        // Verificar si el audio ha finalizado
        if (!audioSource.isPlaying && reproduciendo)
        {
            reproduciendo = false;
        }
    }

    // Método que se ejecuta cuando se hace clic en el botón
    public void PlayAudio()
    {
        /* // Verifica si hay un AudioSource y un AudioClip asignado
         if (audioSource != null && audioSource.clip != null)
         {
             // Reproduce el audio
             audioSource.Play();
         }
         else
         {
             Debug.LogWarning("No se ha asignado un AudioClip al AudioSource.");
         }*/
        if (!reproduciendo)
        {
            // Iniciar la reproducción
            audioSource.Play();
            reproduciendo = true;
        }
        else if (audioSource.isPlaying)
        {
            // Pausar la reproducción
            audioSource.Pause();
            reproduciendo = false;
        }
        else
        {
            // Reanudar la reproducción
            audioSource.UnPause();
            reproduciendo = true;
        }
    }
}
