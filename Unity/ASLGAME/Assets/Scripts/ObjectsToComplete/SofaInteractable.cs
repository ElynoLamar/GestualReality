using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaInteractable : MonoBehaviour//, MakeInteractable
{


    public GameObject objectToMakeVisible;
    public GameObject completeA;
    public GameObject completeE;
    public GameObject interactiveCubeA;
    public GameObject interactiveCubeE;
    public float visibleDistance = 5f;



    private bool objectIsVisible = false;
    public bool EisComplete = false;
    public bool AisComplete = false;
    public bool isComplete = false;

    private Animator doorAnimation;


    private void Start()
    {
       
        objectToMakeVisible.SetActive(false);
        completeA.SetActive(false);
        completeE.SetActive(false);

        doorAnimation = GameObject.FindWithTag("LivingRoom").GetComponent<Animator>();
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
        if (Input.GetKey(KeyCode.K) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeA.SetActive(false);
            completeA.SetActive(true);
            EisComplete = true;

        }
        // For the letter E
        if (Input.GetKey(KeyCode.L) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCubeE.SetActive(false);
            completeE.SetActive(true);
            AisComplete = true;

        }
        if (EisComplete && AisComplete)
        {
            isComplete = true;
            doorAnimation.SetBool("openDoor", false);

        }
    }

}
