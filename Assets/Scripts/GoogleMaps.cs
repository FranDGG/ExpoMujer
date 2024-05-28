using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class GoogleMaps : MonoBehaviour
{
    public void AbrirEnlace(string URL)
    {
        Application.OpenURL(URL);
    }
}

