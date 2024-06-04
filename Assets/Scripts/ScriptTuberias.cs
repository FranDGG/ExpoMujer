using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTuberias : MonoBehaviour
{

    //angulos posibles de las rotaciones
    float[] rotations = {0,90,180,270};

    //lista de posiciones correctas
    public float [] correctRotation;
    
    //Checkeo para ver si la tubería está en su lugar
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    private GameObject PipesManager;

    private void Awake()
    {
        //Encuentra el game Manager
        PipesManager = GameObject.FindGameObjectWithTag("PipesManager");
    }

    private void Start()
    {
                
            //Genera una rotación aleatoria para cada tubería el inicar según los ángulos marcados
            PossibleRots = correctRotation.Length;

            //int rand = Random.Range(0, rotations.Length);

            //transform.eulerAngles = new Vector3 (0,0,rotations[rand]);
        
            //Si las posiciones son más de 1: 
            if(PossibleRots > 1)
            {
                        
                //Checkea si el vector de rotación es igual a la lista de posiciones correctas 
                if(transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] )
                {
                            
                    //Aparece en la consola y se marca la casilla como colocada correctamente
                    isPlaced = true;
                    PipesManager.GetComponent<PipesManager>().correctMove();
                }
            }
            else
            {
                        
                //Si las posiciones posibles solo son 1 se hace el mismo procedimiento
                if(transform.eulerAngles.z == correctRotation[0] )
                {
                    isPlaced = true;
                    PipesManager.GetComponent<PipesManager>().correctMove();
                }
            }
    }

    private void OnMouseDown()
    {
                
        //Rota la tubería
        transform.Rotate(new Vector3(0,0,90));

        //Checks cuando se mueve una tubería (similar to update)
        if(PossibleRots > 1)
        {

            if(transform.eulerAngles.z == correctRotation [0] || transform.eulerAngles.z == correctRotation [1] && isPlaced == false)
            {
                isPlaced = true;
                PipesManager.GetComponent<PipesManager>().correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                PipesManager.GetComponent<PipesManager>().wrongMove();
            }
        }
        else
        {
            if(transform.eulerAngles.z == correctRotation [0] && isPlaced == false)
            {
                isPlaced = true;
                PipesManager.GetComponent<PipesManager>().correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                PipesManager.GetComponent<PipesManager>().wrongMove();
            }
        }
    }
}
