using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public BottleController FirstBottle;
    public BottleController SecondBottle;
    

    //WIN LOGIC
    public int filledBottleCount = 0;

    [SerializeField] AudioClip win;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            


            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            
            // RAYCAST DESDE EL GAMECONTROLLER
             Vector3 mouseScreen = Input.mousePosition;
             Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreen.x, mouseScreen.y,1000000.0f));
            
            
            
            
            
            
            
            //RAYCAST DESDE EL GAMECONTROLLER
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, 1000000);
            //Debug.Log(mousePos + "." + transform.position);
            //Debug.DrawLine(transform.position, mousePos, Color.cyan);

            
            if(hit.collider!= null)
            {

                //Debug.Log("Rayo golpeó a: " + hit.collider.gameObject.name);

                if(hit.collider.GetComponent<BottleController>()!=null)
                {
                    if(FirstBottle == null)
                    {
                        FirstBottle = hit.collider.GetComponent<BottleController>();
                    }
                    else
                    { 
                        if(FirstBottle == hit.collider.GetComponent<BottleController>())
                        {
                            FirstBottle = null;
                        }
                        else
                        {
                            SecondBottle = hit.collider.GetComponent<BottleController>();
                            FirstBottle.bottleControllerRef = SecondBottle;

                            FirstBottle.UpdateTopColorValues();
                            SecondBottle.UpdateTopColorValues();

                            if(SecondBottle.FillBottleCheck(FirstBottle.topColor)== true)
                            {
                                FirstBottle.StartColorTransfer();
                                FirstBottle = null;
                                SecondBottle = null;
                            }
                            else
                            {
                                FirstBottle = null;
                                SecondBottle = null;
                            }

                        }
                    }
                }
                
            }

        }
        //WIN LOGIC
        if(filledBottleCount == 4)
        {
             audioSource.PlayOneShot(win);

            GameManager.PlayerPoints = GameManager.PlayerPoints + 10;
            
            GameManager.MoleGame = true;

            GameManager.ReturnToMainBool = true;
            SceneManager.LoadScene("Screen_Main");
        }
        
    }
    
}
