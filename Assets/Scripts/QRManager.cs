using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using TMPro;
using UnityEngine.SceneManagement;

public class QRManager : MonoBehaviour
{

    public RawImage cameraFeedImage;
    public Text scannedDataText;

    private WebCamTexture webcamTexture;
    private BarcodeReader barcodeReader;
    
    string QrCode = string.Empty;

    public string SceneName;
    
    public TMP_Text message;
    public TMP_Text buttonText;
    public GameObject scanner, HUD_Controls;
    public GameObject scanButton;

    void Start()
    {
        var renderer = scanner.GetComponent<RawImage>();
        webcamTexture = new WebCamTexture();
        renderer.texture = webcamTexture;
        //renderer.material.mainTexture = webcamTexture;
        scanner.SetActive(true);
        // StartCoroutine(GetQRCode());
        buttonText.text = "Abrir cámara";
    }

    public IEnumerator GetQRCode()
    {
        IBarcodeReader barCodeReader = new BarcodeReader();
        webcamTexture.Play();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        break;
                    }
                }
            }

            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        webcamTexture.Stop();

        if (QrCode == "NewGaming2024")
        {
            //Esto no sirve, lleva a un callejón sin salida
            Finalizar();
        }

        else if (QrCode == "expomujer107")
        {
            SceneManager.LoadScene("Minigame1");
        }

        else if (QrCode == "expomujer245")
        {
            SceneManager.LoadScene("Minigame4");
        }

        else if (QrCode == "expomujer382")
        {
            SceneManager.LoadScene("Minigame7");
        }
        
        else if (QrCode == "expomujer476")
        {
            SceneManager.LoadScene("Minigame6");
        }

        else if (QrCode == "expomujer599")
        {
            SceneManager.LoadScene("Minigame3");
        }

        else if (QrCode == "expomujer666")
        {
            SceneManager.LoadScene("Minigame5");
        }

        else if (QrCode == "expomujer731")
        {
            SceneManager.LoadScene("Minigame11");
        }

        else if (QrCode == "expomujer804")
        {
            SceneManager.LoadScene("Minigame2");
        }

        // else if (QrCode == "ScapeCityPatios_2024_NG")
        // {
        //     HUD_Controls.GetComponent<HUD_Controls>().screenQRReader.SetActive(false);
        //     HUD_Controls.GetComponent<HUD_Controls>().screenGuilts.SetActive(true);
        //     HUD_Controls.GetComponent<HUD_Controls>().SwitchON_HintsWindow();

        // }

        else
        {
            QrCode = string.Empty;
            scanButton.SetActive(true);
            message.text = "El código escaneado no es correcto, vuelve a intentarlo";
            buttonText.text = "Volver a escanear";
        }
    }
    public void OpenScanner()
    {
        scanner.SetActive(true);
        scanButton.SetActive(false);
        message.text = "Apunta con tu cámara al código QR para escanearlo automáticamente";
        StartCoroutine(GetQRCode());
    }
    public void Finalizar()
    {
        scanner.SetActive(false);
        message.text = "¡Código escaneado! Haz clic aquí para volver al mapa";
    }
}
