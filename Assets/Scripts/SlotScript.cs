using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SlotScript : MonoBehaviour, IDropHandler
{

    public int id;

    public int SlotChecker;

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

                eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.blocksRaycasts = false;
                SlotChecker = PlayerPrefs.GetInt("Contador");
                SlotChecker++;
                PlayerPrefs.SetInt("Contador", SlotChecker);

                if (SceneManager.GetActiveScene().name == "Minigame1")
                {
                    if (SlotChecker == 8)
                    {
                        Debug.Log("All Checked!");

                        GameManager.DressUpGame = true;
                        GameManager.ReturnToMainBool = true;
                        SceneManager.LoadScene("Screen_Main");
                    }

                    else
                    {
                        Debug.Log("Checkers Remaining: " + (8 - SlotChecker));
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Minigame6")
                {
                    if (SlotChecker == 16)
                    {
                        GameManager.PuzzleGame = true;

                        Debug.Log("Has finalizado el juego");
                        GameManager.ReturnToMainBool = true;
                        SceneManager.LoadScene("Screen_Main");
                    }

                    else
                    {
                        Debug.Log("Checkers Remaining: " + (16 - SlotChecker));
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Minigame7")
                {
                    if (SlotChecker == 9)
                    {
                        GameManager.TrashGame = true;

                        Debug.Log("Has finalizado el juego");
                        GameManager.ReturnToMainBool = true;
                        SceneManager.LoadScene("Screen_Main");
                    }

                    else
                    {
                        Debug.Log("Checkers Remaining: " + (9 - SlotChecker));
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
