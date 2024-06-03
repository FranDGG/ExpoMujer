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
            SceneManager.LoadScene("Minigame4");
        }

        //Florencio (Minigame 03)
        else if (inputPasswordCheck == "expomujer382")
        {
            SceneManager.LoadScene("Minigame7");
        }

        //Jacinto (Minigame 04)
        else if (inputPasswordCheck == "expomujer476")
        {
            SceneManager.LoadScene("Minigame6");
        }

        //Gladiolo (Minigame 05)
        else if (inputPasswordCheck == "expomujer599")
        {
            SceneManager.LoadScene("Minigame3");
        }

        //Azucena (Minigame 06)
        else if (inputPasswordCheck == "expomujer666")
        {
            SceneManager.LoadScene("Minigame5");
        }

        //Rosa (Minigame 07)
        else if (inputPasswordCheck == "expomujer731")
        {
            SceneManager.LoadScene("Minigame11");
        }

        //Petunia (Minigame 08)
        else if (inputPasswordCheck == "expomujer804")
        {
            SceneManager.LoadScene("Minigame2");
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
