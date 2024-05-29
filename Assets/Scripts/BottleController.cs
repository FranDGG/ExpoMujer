using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    public Color[] bottleColors;
    public SpriteRenderer bottleMaskSR;

    public AnimationCurve ScaleAndRotationMultiplierCurve;
    public AnimationCurve FillAmountCurve; 

    public AnimationCurve RotationSpeedMultiplier;

    public float[] fillAmounts;
    public float[] rotationValues;

    private int rotationIndex = 0;

    [Range(0,4)]
    public int numberOfColorsInBottle = 4;

    public Color topColor;
    public int numberOfTopColorLayers = 1;


    public BottleController bottleControllerRef;
    public bool justThisBottle = false;
    private int numberOfColorsToTransfer = 0;


    public Transform leftRotationPoint;
    public Transform rightRotationPoint;
    private Transform chosenRotationPoint;

    private float directionMultiplier = 1.0f;

    Vector3 originalPosition;
    Vector3 startPosition;
    Vector3 endPosition;

    public GameObject GameController;

    public LineRenderer lineRenderer;

    //WIN LOGIC
    private bool isCounted = false;

    [SerializeField] AudioClip liquid;
    [SerializeField] AudioClip win;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bottleMaskSR.material.SetFloat("_FillAmount",fillAmounts[numberOfColorsInBottle]);


        originalPosition = transform.position;

        UpdateColorsOnShader();

        UpdateTopColorValues();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P) && justThisBottle == true)
        {
            UpdateTopColorValues();

            if(bottleControllerRef.FillBottleCheck(topColor))
            {

                ChoseRotationPointAndDirection();

                numberOfColorsToTransfer = Mathf.Min(numberOfTopColorLayers, 4 -bottleControllerRef.numberOfColorsInBottle);

                for(int i=0; i < numberOfColorsToTransfer; i++)
                {
                    bottleControllerRef.bottleColors[bottleControllerRef.numberOfColorsInBottle + i] = topColor;
                }
                bottleControllerRef.UpdateColorsOnShader();
            }

            CalculateRotationIndex(4 - bottleControllerRef.numberOfColorsInBottle); 
            StartCoroutine(RotateBottle());
        }

        //WIN LOGIC
        UpdateTopColorValues();
    }

    public void StartColorTransfer()
    {
        
        audioSource.PlayOneShot(liquid);

        ChoseRotationPointAndDirection();

        numberOfColorsToTransfer = Mathf.Min(numberOfTopColorLayers, 4 -bottleControllerRef.numberOfColorsInBottle);

        for(int i=0; i < numberOfColorsToTransfer; i++)
        {
            bottleControllerRef.bottleColors[bottleControllerRef.numberOfColorsInBottle + i] = topColor;
        }
        bottleControllerRef.UpdateColorsOnShader();
        

        CalculateRotationIndex(4 - bottleControllerRef.numberOfColorsInBottle); 
        
        transform.GetComponent<SpriteRenderer>().sortingOrder += 2;
        bottleMaskSR.sortingOrder += 2;
        
        StartCoroutine(MoveBottle());
    }

    IEnumerator MoveBottle()
    {
        startPosition = transform.position;
        if(chosenRotationPoint == leftRotationPoint)
        {
            endPosition = bottleControllerRef.rightRotationPoint.position;
        }
        else
        {
            endPosition = bottleControllerRef.leftRotationPoint.position;
        }

        float t = 0;

        while(t<=1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            t += Time.deltaTime * 2;

            yield return new WaitForEndOfFrame();
        }

        transform.position = endPosition;

        StartCoroutine(RotateBottle());
    }

    IEnumerator MoveBottleBack()
    {
        startPosition = transform.position;
        endPosition = originalPosition;

        float t = 0;

        while(t<=1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            t += Time.deltaTime * 2;

            yield return new WaitForEndOfFrame();
        }

        transform.position = endPosition;

        transform.GetComponent<SpriteRenderer>().sortingOrder -= 2;
        bottleMaskSR.sortingOrder -= 2;
    }

    void UpdateColorsOnShader()
    {
        bottleMaskSR.material.SetColor("_Color01",bottleColors[0]);
        bottleMaskSR.material.SetColor("_Color02",bottleColors[1]);
        bottleMaskSR.material.SetColor("_Color03",bottleColors[2]);
        bottleMaskSR.material.SetColor("_Color04",bottleColors[3]);
    }

    public float timeToRotate = 1.0f;

    IEnumerator RotateBottle()
    {

        float t = 0;
        float lerpValue;
        float angleValue;

        float lastAngleValue = 0;

        while(t<timeToRotate)
        {
            lerpValue=t/timeToRotate;
            angleValue = Mathf.Lerp(0.0f, directionMultiplier * rotationValues[rotationIndex], lerpValue);

            
            //transform.eulerAngles = new Vector3(0,0,angleValue);
            
            transform.RotateAround(chosenRotationPoint.position, Vector3.forward, lastAngleValue - angleValue);
            
            bottleMaskSR.material.SetFloat("_SARM", ScaleAndRotationMultiplierCurve.Evaluate(angleValue));
            
            if(fillAmounts[numberOfColorsInBottle]>FillAmountCurve.Evaluate(angleValue)+0.005f)
            {

                if (lineRenderer.enabled == false)
                {
                    lineRenderer.startColor = topColor;
                    lineRenderer.endColor = topColor;

                    lineRenderer.SetPosition(0,chosenRotationPoint.position);
                    lineRenderer.SetPosition(1,chosenRotationPoint.position - Vector3.up * 1.45f);

                    lineRenderer.enabled = true;
                }
                bottleMaskSR.material.SetFloat("_FillAmount", FillAmountCurve.Evaluate(angleValue));

                bottleControllerRef.FillUp(FillAmountCurve.Evaluate(lastAngleValue) - FillAmountCurve.Evaluate(angleValue));
            }

            t += Time.deltaTime*RotationSpeedMultiplier.Evaluate(angleValue);
            lastAngleValue = angleValue; 
            yield return new WaitForEndOfFrame();
        }
        angleValue = directionMultiplier * rotationValues[rotationIndex];
        //transform.eulerAngles = new Vector3(0,0,angleValue);
        bottleMaskSR.material.SetFloat("_SARM", ScaleAndRotationMultiplierCurve.Evaluate(angleValue));
        bottleMaskSR.material.SetFloat("_FillAmount", FillAmountCurve.Evaluate(angleValue));

        numberOfColorsInBottle -= numberOfColorsToTransfer;
        bottleControllerRef.numberOfColorsInBottle += numberOfColorsToTransfer;

        lineRenderer.enabled = false; 
        StartCoroutine(RotateBottleBack());
    }

    IEnumerator RotateBottleBack()
    {
        float t = 0;
        float lerpValue;
        float angleValue;

        float lastAngleValue = directionMultiplier * rotationValues[rotationIndex];

        while(t<timeToRotate)
        {
            lerpValue=t/timeToRotate;
            angleValue = Mathf.Lerp(directionMultiplier * rotationValues[rotationIndex],0.0f,lerpValue);

            //transform.eulerAngles = new Vector3(0,0,angleValue);

            transform.RotateAround(chosenRotationPoint.position,Vector3.forward, lastAngleValue - angleValue);

            bottleMaskSR.material.SetFloat("_SARM", ScaleAndRotationMultiplierCurve.Evaluate(angleValue));

            lastAngleValue = angleValue;


            t += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        
        UpdateTopColorValues();
        angleValue = 0;
        transform.eulerAngles = new Vector3(0,0,angleValue);
        bottleMaskSR.material.SetFloat("_SARM", ScaleAndRotationMultiplierCurve.Evaluate(angleValue));
        
        StartCoroutine(MoveBottleBack());


    }

    public void UpdateTopColorValues()
    {
        if(numberOfColorsInBottle!=0)
        {
            numberOfTopColorLayers = 1;

            topColor = bottleColors[numberOfColorsInBottle - 1];

            if(numberOfColorsInBottle ==4)
            {
                if(bottleColors[3].Equals(bottleColors[2]))
                {
                    numberOfTopColorLayers = 2;
                    if(bottleColors[2].Equals(bottleColors[1]))
                    {
                        numberOfTopColorLayers = 3;
                        

                        if(bottleColors[1].Equals(bottleColors[0]))
                        {
                            numberOfTopColorLayers = 4;

                            //WIN LOGIC//                            
                            
                            
                            if(!isCounted)
                            {
                                GameController.GetComponent<GameController>().filledBottleCount++;
                                isCounted = true;
                            }

                            Collider2D collider = GetComponent<Collider2D>();
                            if(collider != null)
                            {
                                collider.enabled = false;
                            }
                        }
                    }
                }
            }

            else if(numberOfColorsInBottle ==3)
            {
                if(bottleColors[2].Equals(bottleColors[1]))
                {
                    numberOfTopColorLayers = 2;
                    if(bottleColors[1].Equals(bottleColors[0]))
                    {
                        numberOfTopColorLayers = 3;
                    }
                }
            }

            else if(numberOfColorsInBottle ==2)
            {
                if(bottleColors[1].Equals(bottleColors[0]))
                {
                    numberOfTopColorLayers = 2;
                }
            }

            rotationIndex = 3 - (numberOfColorsInBottle - numberOfTopColorLayers);  
        }
    }

    public bool FillBottleCheck(Color colorToCheck)
    {
        if(numberOfColorsInBottle == 0)
        {
            return  true;
        }
        else
        {
            if(numberOfColorsInBottle == 4)
            {
                return false;              
            }
            else
            {
                if(topColor.Equals(colorToCheck))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    private void CalculateRotationIndex(int numberOfEmptySpacesInSecondBottle)
    {
        rotationIndex = 3 - (numberOfColorsInBottle - Mathf.Min(numberOfEmptySpacesInSecondBottle, numberOfTopColorLayers));
    }

    private void FillUp(float fillAmountToAdd)
    {
        bottleMaskSR.material.SetFloat("_FillAmount" , bottleMaskSR.material.GetFloat("_FillAmount") + fillAmountToAdd);
    }

    private void ChoseRotationPointAndDirection()
    {
        if(transform.position.x>bottleControllerRef.transform.position.x)
        {
            chosenRotationPoint = leftRotationPoint;
            directionMultiplier = -1.0f;
        }
        else
        {
            chosenRotationPoint = rightRotationPoint;
            directionMultiplier = 1.0f;
        }       
    }
}