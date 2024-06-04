using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BichosBoton : MonoBehaviour
{
    private static int puntos = 0;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip sonido;
    public  GameObject splat;
    public GameObject bichoPropio;
    
    // private void OnMouseDown()
    public void SmashBug()
    { 
        // Si el jugador toca el bicho, desaparece y aparece una mancha verde
        Destroy(bichoPropio);

        controladorSonido.Instance.EjecutarSonido(sonido);

        puntos++;
        
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instanciar el splat con el ángulo aleatorio
        Instantiate(splat, transform.position, randomRotation);

        puntosMax();
    }

    private void puntosMax()
    {
        if(puntos == 28)
        {
            controladorSonido.Instance.EjecutarSonido(win);

            GameManager.BugsGame = true;
            SceneManager.LoadScene("Main_Scene");
            GetComponent<HUD_Controls>().DisableScreens();
            GetComponent<HUD_Controls>().screenStickers.SetActive(true);
        }
    }
}
