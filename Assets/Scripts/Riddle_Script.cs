using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Riddle_Script : MonoBehaviour
{

    private string inputAnswer;

    public TMP_InputField inputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputAnswer = inputText.text.ToLower();
    }

    public void ReadStringInput()
    {
        if (inputAnswer == "marie curie" || inputAnswer == "mariecurie" || inputAnswer == "mari curie" || inputAnswer == "marie" || inputAnswer == "curie")
        {
            GameManager.RiddleGame = true;

            Debug.Log("CORRECT! IT WAS " + inputAnswer);

            GameManager.ReturnToMainBool = true;
            SceneManager.LoadScene("Screen_Main");
        }

        else
        {
            Debug.Log("Oh, No!... The Correct Answer it was 'Marie Curie'");
        }
    }
    public void SaltarJuego()
    {
        SceneManager.LoadScene("Screen_Main");
    }
}
