using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonChangeBichos : MonoBehaviour
{

    private static int puntos = 0;

    public Button DeactivateButton;

    public Sprite[] buttonSprites;
 
    public Image targetButton;

    public buttonBicho buttonBichoScript;


    

    
    [SerializeField] AudioClip sonido;
    [SerializeField] AudioClip win;       



    public void ButtonPressed()
    {   
        Debug.Log("Antonio NOOOOO");
        DeactivateButton.interactable = false;
        controladorSonido.Instance.EjecutarSonido(sonido);
        puntos++;
        puntosMax();

        
    }


    public void ChangeSprite()
    {
        if (targetButton.sprite == buttonSprites[0])
        {
            targetButton.sprite = buttonSprites[1];
            //return;

            buttonBichoScript.SetShouldMove(false);

            StartCoroutine(FadeOutAndDestroy(DeactivateButton.gameObject));
        }
    }

    private IEnumerator FadeOutAndDestroy(GameObject buttonObject)
    {
        // Get the button's image component
        Image buttonImage = buttonObject.GetComponent<Image>();

        // Time taken for the fade-out effect
        float fadeDuration = 2f;

        // Initial alpha value
        float startAlpha = buttonImage.color.a;

        // Time elapsed
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value using a linear interpolation
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);

            // Set the new color with the updated alpha value
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, newAlpha);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final alpha value is 0
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0f);

        // Once the fade-out is complete, destroy the button game object
        Destroy(buttonObject);
    }

    private void puntosMax()
    {
        if(puntos == 21)
        {
            controladorSonido.Instance.EjecutarSonido(win);
            GameManager.BugsGame = true;

            GameManager.ReturnToMainBool = true;
            SceneManager.LoadScene("Screen_Main");
        }
    }
    
}