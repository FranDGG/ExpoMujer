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

    public GameObject[] Sticker;

    public GameObject screenTitle, screenIntro, screenStickersLocation, screenStickers, screenQRReader, ButtonQR01, screenFinal;
    

    void Start()
    {
        PUP_Window = GameObject.FindGameObjectsWithTag("PUP_Window");
        
        foreach (GameObject obj in PUP_Window)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.DressUpGame)
        {
            DisableScreens();
            screenStickers.SetActive(true);
            
        }
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
        if (screen == 4) {Sticker[0].SetActive(true);}
        if (screen == 5) {Sticker[1].SetActive(true);}
        if (screen == 6) {Sticker[2].SetActive(true);}
        if (screen == 7) {Sticker[3].SetActive(true);}
        if (screen == 8) {Sticker[4].SetActive(true);}
        if (screen == 9) {Sticker[5].SetActive(true);}
        if (screen == 10) {Sticker[6].SetActive(true);}
        if (screen == 11) {Sticker[7].SetActive(true);}

        if (screen == 15)
        {
            screenQRReader.SetActive(true);
            screenStickersLocation.SetActive(false);
            screenQRReader.GetComponent<QRManager>().StartCoroutine(screenQRReader.GetComponent<QRManager>().GetQRCode());
        }

    }

    public void GoMinigames(int MiniGames)
    {
        if (MiniGames == 1) { PlayerPrefs.SetInt("Mini01", 1);}
        if (MiniGames == 2) { PlayerPrefs.SetInt("Mini02", 1);}
        if (MiniGames == 3) { PlayerPrefs.SetInt("Mini03", 1);}
        if (MiniGames == 4) { PlayerPrefs.SetInt("Mini04", 1);}
        if (MiniGames == 5) { PlayerPrefs.SetInt("Mini05", 1);}
        if (MiniGames == 6) { PlayerPrefs.SetInt("Mini06", 1);}
        if (MiniGames == 7) { PlayerPrefs.SetInt("Mini07", 1);}
        if (MiniGames == 8) { PlayerPrefs.SetInt("Mini08", 1);}

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

        Sticker[0].SetActive(false);
        Sticker[1].SetActive(false);
        Sticker[2].SetActive(false);
        Sticker[3].SetActive(false);
        Sticker[4].SetActive(false);
        Sticker[5].SetActive(false);
        Sticker[6].SetActive(false);
        Sticker[7].SetActive(false);
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
