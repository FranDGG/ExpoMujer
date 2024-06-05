using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quizz_Controls : MonoBehaviour
{

    //Variables que guardan los textos de las preguntas y los botones
    [SerializeField] GameObject[] QuestionText, ButtonText, Button2Text;

    //Variable que guarda los botones 1 y 2
    [SerializeField] GameObject Button01, Button02;
    
    //Variable que guarda el número de la pregunta
    private int QuestionNum;

    //Variable que guarda los puntos del Quiz
    private int QuizPoints;

    //Sonido
    [SerializeField] AudioClip wrong2;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip correct;
    AudioSource audioSource;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        QuizPoints = 0;
        QuestionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Question_Change(int AnswerNum)
    {

        switch (QuestionNum)
        {
            case 0:
            case 1:
            case 3:  
            case 6:
            case 8: 
            case 9:

                if (AnswerNum == 1)
                {
                    QuizPoints++;
                    Debug.Log("CORRECT!" + " " + "/" + " " + "POINTS" + " " + QuizPoints);
                    audioSource.PlayOneShot(correct);
                }

                else
                {
                    Debug.Log("WRONG!" + " " + "/" + " " + "POINTS" + " " + QuizPoints);
                    audioSource.PlayOneShot(wrong2);
                }

            break;

            case 2:
            case 4: 
            case 5:
            case 7:

                if (AnswerNum == 1)
                {
                    Debug.Log("WRONG!" + " " + "/" + " " + "POINTS" + " " + QuizPoints);
                    audioSource.PlayOneShot(wrong2);
                }
                
                else
                {
                    QuizPoints++;
                    Debug.Log("CORRECT!" + " " + "/" + " " + "POINTS" + " " + QuizPoints);
                    audioSource.PlayOneShot(correct);
                }
                
            break;
        }
        
        QuestionText[QuestionNum].SetActive(false);
        ButtonText[QuestionNum].SetActive(false);
        Button2Text[QuestionNum].SetActive(false);
        QuestionNum++;
        QuestionText[QuestionNum].SetActive(true);

        if (QuestionNum < 10)
        {
            ButtonText[QuestionNum].SetActive(true);
            Button2Text[QuestionNum].SetActive(true);
            
            Debug.Log(QuestionText[QuestionNum]);
            
        }

        if (QuestionNum >= 10)
        {

            Button01.SetActive(false);
            Button02.SetActive(false);
            
            if(QuizPoints < 6)
            {
                audioSource.PlayOneShot(wrong2);
                QuestionText[11].SetActive(true);
                Debug.Log("Insuficient Points!");
                
                Invoke ("Restart", 3);
            }
            else
            {
                QuestionText[12].SetActive(true);
                audioSource.PlayOneShot(win);

                GameManager.QuizzGame = true;
                GameManager.ReturnToMainBool = true;
                SceneManager.LoadScene("Screen_Main");
            }

        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Minigame5");
    }

}
