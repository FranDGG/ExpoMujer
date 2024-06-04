using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUD_Controls : MonoBehaviour
{

//VARIABLES  GLOBALES

    private GameObject[] PUP_Window;

    public GameObject[] Sticker, Info_Sticker;

    public GameObject screenTitle, screenIntro, screenStickersLocation, screenStickers, screenQRReader, ButtonQR01, screenFinal;
    void Start()
    {
        PUP_Window = GameObject.FindGameObjectsWithTag("PUP_Window");
        
        foreach (GameObject obj in PUP_Window)
        {
            obj.SetActive(false);
        }

        if (GameManager.DressUpGame || GameManager.BugsGame || GameManager.PipeGame || GameManager.RiddleGame || GameManager.QuizzGame || GameManager.PuzzleGame || GameManager.TrashGame || GameManager.MoleGame)
        {
            DisableScreens();
            screenStickers.SetActive(true);
        }

        if (GameManager.DressUpGame && GameManager.BugsGame && GameManager.PipeGame && GameManager.RiddleGame && GameManager.QuizzGame && GameManager.PuzzleGame && GameManager.TrashGame && GameManager.MoleGame)
        {
            DisableScreens();
            screenFinal.SetActive(true);
        }

        if (GameManager.DressUpGame)
        {
            Sticker[0].SetActive(false);
        }

        if (GameManager.BugsGame)
        {
            Sticker[1].SetActive(false);
        }

        if (GameManager.PipeGame)
        {
            Sticker[2].SetActive(false);
        }

        if (GameManager.RiddleGame)
        {
            Sticker[3].SetActive(false);
        }

        if (GameManager.QuizzGame)
        {
            Sticker[4].SetActive(false);
        }

        if (GameManager.PuzzleGame)
        {
            Sticker[5].SetActive(false);
        }

        if (GameManager.TrashGame)
        {
            Sticker[6].SetActive(false);
        }

        if (GameManager.MoleGame)
        {
            Sticker[7].SetActive(false);
        }
    }

    void Update()
    {

    }

//CAMBIOS DE PANTALLA.

    public void SwitchScreens(int screen)
    {

        DisableScreens();
        SwitchOFF_PUPWindow();

        //Activar canvas
        if (screen == 1) {screenTitle.SetActive(true);}
        if (screen == 2) {screenIntro.SetActive(true);}
        if (screen == 3) {screenStickers.SetActive(true);}

        if (screen > 3 && screen <= 11) {screenStickersLocation.SetActive(true);}
        if (screen == 4) {Info_Sticker[0].SetActive(true);}
        if (screen == 5) {Info_Sticker[1].SetActive(true);}
        if (screen == 6) {Info_Sticker[2].SetActive(true);}
        if (screen == 7) {Info_Sticker[3].SetActive(true);}
        if (screen == 8) {Info_Sticker[4].SetActive(true);}
        if (screen == 9) {Info_Sticker[5].SetActive(true);}
        if (screen == 10) {Info_Sticker[6].SetActive(true);}
        if (screen == 11) {Info_Sticker[7].SetActive(true);}
        if (screen == 12) {screenFinal.SetActive(true);}

        if (screen == 15)
        {
            screenQRReader.SetActive(true);
            screenStickersLocation.SetActive(false);
            screenQRReader.GetComponent<QRManager>().StartCoroutine(screenQRReader.GetComponent<QRManager>().GetQRCode());
        }

    }

    public void GoMinigames(int MiniGames)
    {
        if (MiniGames == 1) {PlayerPrefs.SetInt("Mini01", 1);}
        if (MiniGames == 2) {PlayerPrefs.SetInt("Mini02", 1);}
        if (MiniGames == 3) {PlayerPrefs.SetInt("Mini03", 1);}
        if (MiniGames == 4) {PlayerPrefs.SetInt("Mini04", 1);}
        if (MiniGames == 5) {PlayerPrefs.SetInt("Mini05", 1);}
        if (MiniGames == 6) {PlayerPrefs.SetInt("Mini06", 1);}
        if (MiniGames == 7) {PlayerPrefs.SetInt("Mini07", 1);}
        if (MiniGames == 8) {PlayerPrefs.SetInt("Mini08", 1);}

        SceneManager.LoadScene("Minigame" + MiniGames);
    }

    //Desactivar canvas
    public void DisableScreens()
    {
        screenTitle.SetActive(false);
        screenIntro.SetActive(false);
        screenStickers.SetActive(false);
        screenStickersLocation.SetActive(false);
        screenQRReader.SetActive(false);
        screenFinal.SetActive(false);

        Info_Sticker[0].SetActive(false);
        Info_Sticker[1].SetActive(false);
        Info_Sticker[2].SetActive(false);
        Info_Sticker[3].SetActive(false);
        Info_Sticker[4].SetActive(false);
        Info_Sticker[5].SetActive(false);
        Info_Sticker[6].SetActive(false);
        Info_Sticker[7].SetActive(false);
    }

//VENTANA EMERGENTE

    public void CorrectAnswer()
    {
        GameManager.CorrectAnswer = true;
    }

    public void SwitchON_PUPWindow()
    {
        foreach (GameObject obj in PUP_Window)
        {
            obj.SetActive(true);
        }
    }

    public void SwitchOFF_PUPWindow()
    {
        foreach (GameObject obj in PUP_Window)
        {
            obj.SetActive(false);
        }
    }
    public void ReiniciarEstado()
    { PlayerPrefs.DeleteAll(); }

//BOTON DE SALIDA DE LA APLICACIÓN

    public void Exit_Button()
    {
        Application.Quit();
        Debug.Log("Exit Succesful");
    }
}
