using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteract : MonoBehaviour
{
    public GameObject objectToMakeVisible;

    public GameObject completeA;
    public GameObject completeE;
    public GameObject completeI;
    public GameObject completeO;
    public GameObject completeU;

    public GameObject interactiveCubeA;
    public GameObject interactiveCubeE;
    public GameObject interactiveCubeI;
    public GameObject interactiveCubeO;
    public GameObject interactiveCubeU;

    public float visibleDistance = 5f;


    private bool objectIsVisible = false;

    public bool AisComplete = false;
    public bool EisComplete = false;
    public bool IisComplete = false;
    public bool OisComplete = false;
    public bool UisComplete = false;

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

        // For the letter A
        if (Input.GetKey(KeyCode.J) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeA.SetActive(false);
            completeA.SetActive(true);
            AisComplete = true;

        }
        // For the letter E
        if (Input.GetKey(KeyCode.J) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeE.SetActive(false);
            completeE.SetActive(true);
            EisComplete = true;

        }
        // For the letter I
        if (Input.GetKey(KeyCode.L) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeI.SetActive(false);
            completeI.SetActive(true);
            IisComplete = true;

        }
        // For the letter O
        if (Input.GetKey(KeyCode.K) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeO.SetActive(false);
            completeO.SetActive(true);
            OisComplete = true;

        }
        // For the letter U
        if (Input.GetKey(KeyCode.J) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeU.SetActive(false);
            completeU.SetActive(true);
            UisComplete = true;

        }

        if (AisComplete && EisComplete && IisComplete && OisComplete && UisComplete)
        {
            isComplete = true;
        }
    }
}
