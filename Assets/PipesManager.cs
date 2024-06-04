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

    private void Awake()
    {

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
        Debug.Log("GREAT!");

        if(correctedPipes == totalPipes)    
        {
            puzzlecompleto.SetActive(true);
            GameManager.PipeGame = true;
            Invoke("Delay", 1.4f);
        }
    }

    public void Delay()
    {
        GameManager.ReturnToMainBool = true;
        SceneManager.LoadScene("Screen_Main");
    }

   public void wrongMove()
    {
        correctedPipes -= 1;
    } 
}
