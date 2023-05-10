using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteract : MonoBehaviour
{
    public GameObject objectToMakeVisible;

    public GameObject completeO;
    public GameObject completeI;
    public GameObject completeE;

    public GameObject interactiveCubeO;
    public GameObject interactiveCubeI;
    public GameObject interactiveCubeE;

    public float visibleDistance = 5f;



    private bool objectIsVisible = false;

    public bool OisComplete = false;
    public bool IisComplete = false;
    public bool EisComplete = false;

    public bool isComplete = false;


    private void Start()
    {

        objectToMakeVisible.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,
            Camera.main.transform.position);

        if (!objectIsVisible && distanceToPlayer <= visibleDistance)
        {
            objectToMakeVisible.SetActive(true);

            objectIsVisible = true;
        }
        else if (objectIsVisible && distanceToPlayer > visibleDistance)
        {
            objectToMakeVisible.SetActive(false);

            objectIsVisible = false;
        }
        // For the letter O
        if (Input.GetKey(KeyCode.K) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeO.SetActive(false);
            completeO.SetActive(true);
            OisComplete = true;

        }
        // For the letter I
        if (Input.GetKey(KeyCode.L) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeI.SetActive(false);
            completeI.SetActive(true);
            IisComplete = true;

        }
        // For the letter E
        if (Input.GetKey(KeyCode.J) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeE.SetActive(false);
            completeE.SetActive(true);
            EisComplete = true;

        }
        if (OisComplete && IisComplete && EisComplete)
        {
            isComplete = true;
        }
    }
    public void setCompleted(string letter)
    {
      if(letter == "O")
        {
            OisComplete = true;
        }
        if (letter == "E")
        {
           EisComplete = true;
        }
        if (letter == "I")
        {
            IisComplete = true;
        }
        if (OisComplete && IisComplete && EisComplete)
        {
            isComplete = true;
        }

    }
}
