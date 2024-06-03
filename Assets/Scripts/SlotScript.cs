using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SlotScript : MonoBehaviour, IDropHandler
{

    public int id;

    public int SlotChecker;

    //Sonido
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip correct;
    AudioSource audioSource;

    
    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("Contador", 0);
        SlotChecker = 0;
    }

    void Update()
    {
                  
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                
                //Comprueba cuantos Slot estan ocupados

                //Ajusta el Item al Slot

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Dropped!");

                //Sonido
                if (SlotChecker < 12 )
                {
                    audioSource.PlayOneShot(correct);
                }

                eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.blocksRaycasts = false;
                SlotChecker = PlayerPrefs.GetInt("Contador");
                SlotChecker++;
                PlayerPrefs.SetInt("Contador", SlotChecker);

                if (SceneManager.GetActiveScene().name == "Minigame1")
                {
                    if (SlotChecker == 8)
                    {
                        Debug.Log("Player Points: " + GameManager.PlayerPoints);
                        Debug.Log("All Checked!");
                        audioSource.PlayOneShot(win);

                        GameManager.DressUpGame = true;
                        GameManager.ReturnToMainBool = true;
                        SceneManager.LoadScene("Screen_Main");
                    }

                    else
                    {
                        Debug.Log("Checkers Remaining: " + (8 - SlotChecker));
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Minigame6" || SceneManager.GetActiveScene().name == "Minigame8")
                {
                    if (SlotChecker == 12)
                    {
                        if (SceneManager.GetActiveScene().name == "Minigame6")
                        {
                            GameManager.PuzzleGame = true;
                        }

                        else if (SceneManager.GetActiveScene().name == "Minigame8")
                        {
                            GameManager.FlowersGame = true;
                        }

                        Debug.Log("Has finalizado el juego");
                        GameManager.ReturnToMainBool = true;
                        SceneManager.LoadScene("Screen_Main");
                    }

                    else
                    {
                        Debug.Log("Checkers Remaining: " + (12 - SlotChecker));
                    }
                }
            }

            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.blocksRaycasts = true;
                
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragAndDrop>().startPosition;
                Debug.Log("BackToStartPos");
            }
        }
    }
}
