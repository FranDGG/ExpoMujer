using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswordQR : MonoBehaviour
{

    private string inputPasswordCheck;

    public TMP_InputField inputPassword;

    public GameObject HUD_Controls;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputPasswordCheck = inputPassword.text;
    }

    public void ReadStringInput()
    {
        //Narciso (Minigame 01)
        if (inputPasswordCheck == "expomujer107") 
        {
            SceneManager.LoadScene("Minigame1");
        }

        //Margarita (Minigame 02)
        else if (inputPasswordCheck == "expomujer245")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Florencio (Minigame 03)
        else if (inputPasswordCheck == "expomujer382")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Jacinto (Minigame 04)
        else if (inputPasswordCheck == "expomujer476")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Gladiolo (Minigame 05)
        else if (inputPasswordCheck == "expomujer599")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Azucena (Minigame 06)
        else if (inputPasswordCheck == "expomujer666")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Rosa (Minigame 07)
        else if (inputPasswordCheck == "expomujer731")
        {
            SceneManager.LoadScene("Minigame");
        }

        //Petunia (Minigame 08)
        else if (inputPasswordCheck == "expomujer804")
        {
            SceneManager.LoadScene("Minigame");
        }

        // if(inputPasswordCheck == "ScapeCityPatios2024NG")
        // {
        //     HUD_Controls.GetComponent<HUD_Controls>().DisableScreens();
        //     HUD_Controls.GetComponent<HUD_Controls>().screenGuilts.SetActive(true);
        //     HUD_Controls.GetComponent<HUD_Controls>().SwitchON_HintsWindow();
        // }

    }
    public void SaltarJuego()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
