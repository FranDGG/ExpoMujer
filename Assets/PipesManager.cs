using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PipesManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    public GameObject puzzlecompleto, Slot;

    [SerializeField]
    int totalPipes = 0;
    
    [SerializeField]
    int correctedPipes = 0;


    [SerializeField] AudioClip bubbles;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip correct;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Slot = GameObject.FindGameObjectWithTag("Slot");

       
        // Ocultar la interfaz de usuario del juego Topos
        //gameUI.SetActive(false);

        // Iniciar el juego automáticamente topos
        //StartGame();
    }

     void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for(int i = 0; i < Pipes.Length ; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;
        audioSource.PlayOneShot(correct);
        Debug.Log("GREAT!");

        if(correctedPipes == totalPipes)    
        {
            audioSource.PlayOneShot(bubbles);
            PipesHolder.SetActive(false);
            puzzlecompleto.SetActive(true);
            //GameManager.PlayerPoints = GameManager.PlayerPoints + 10;
            audioSource.PlayOneShot(win);
            GameManager.PipeGame = true;
            Invoke("Delay", 1.4f);
        }
    }

    public void Delay()
    {
        GameManager.ReturnToMainBool = true;
        SceneManager.LoadScene("Main_Scene");
    }

   public void wrongMove()
    {
        correctedPipes -= 1;
    } 
}
