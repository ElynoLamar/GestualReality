using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaInteractable : MonoBehaviour//, MakeInteractable
{


    public GameObject objectToMakeVisible;
    public GameObject completeO;
    public GameObject completeA;
    public GameObject interactiveCubeO;
    public GameObject interactiveCubeA;
    public float visibleDistance = 5f;



    private bool objectIsVisible = false;
    public bool OisComplete = false;
    public bool AisComplete = false;
    public bool isComplete = false;


    private void Start()
    {
       
        objectToMakeVisible.SetActive(false);
        completeO.SetActive(false);
        completeA.SetActive(false);
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
        // For the letter A
        if (Input.GetKey(KeyCode.L) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeA.SetActive(false);
            completeA.SetActive(true);
            AisComplete = true;

        }
        if (OisComplete && AisComplete)
        {
            isComplete = true;
        }
    }
}
