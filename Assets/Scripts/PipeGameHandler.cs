using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class PipeGameHandler : MonoBehaviour
{

    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;
    
    [SerializeField]
    int correctedPipes = 0;

    [SerializeField] AudioClip bubbles;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip correct;
    AudioSource audioSource;

    public GameObject puzzlecompleto;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for(int i = 0; i < Pipes.Length ; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            audioSource.PlayOneShot(win);
            GameManager.PipeGame = true;
            GameManager.ReturnToMainBool = true;
        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;
    }
}

