using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelesExpl : MonoBehaviour
{
    public GameObject GrupoBichos;
    public Button botonADestruir;


    public void ActivarBichos()
    {
        GrupoBichos.SetActive(true);
    }

    public void DestoryButton()
    {
        Destroy(botonADestruir.gameObject);
    }

}
