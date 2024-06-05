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
        //Shirt (Dress Up Game)
        if (inputPasswordCheck == "expomujer107") 
        {
            SceneManager.LoadScene("Minigame1");
        }

        //Flowers (Bugs Game)
        else if (inputPasswordCheck == "expomujer245")
        {
            SceneManager.LoadScene("Minigame2");
        }

        //Lego (LightBulb Game)
        else if (inputPasswordCheck == "expomujer382")
        {
            SceneManager.LoadScene("Minigame3");
        }

        //DNA (Marie Curie Riddle)
        else if (inputPasswordCheck == "expomujer476")
        {
            SceneManager.LoadScene("Minigame4");
        }

        //MagnifyingGlass (Quizz Game)
        else if (inputPasswordCheck == "expomujer550")
        {
            SceneManager.LoadScene("Minigame5");
        }

        //MakeUp (Puzzle Game)
        else if (inputPasswordCheck == "expomujer606")
        {
            SceneManager.LoadScene("Minigame6");
        }

        //Sandwitch (Trash Game)
        else if (inputPasswordCheck == "expomujer731")
        {
            SceneManager.LoadScene("Minigame7");
        }

        //Newgaming (Mole Game)
        else if (inputPasswordCheck == "expomujer804")
        {
            SceneManager.LoadScene("Minigame8");
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
