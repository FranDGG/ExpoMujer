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
        if (inputAnswer == "el arcángel san rafael" || inputAnswer == "el arcangel san rafael" || inputAnswer == "arcangel san rafael" || inputAnswer == "arcángel san rafael" || inputAnswer == "san rafael")
        {
            GameManager.RiddleGame = true;

            Debug.Log("CORRECT! IT WAS " + inputAnswer);

            GameManager.ReturnToMainBool = true;
            SceneManager.LoadScene("Main_Scene");
        }

        else
        {
            Debug.Log("Oh, No!... The Correct Answer it was 'El Arcangel San Rafael'");
        }
    }
    public void SaltarJuego()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
