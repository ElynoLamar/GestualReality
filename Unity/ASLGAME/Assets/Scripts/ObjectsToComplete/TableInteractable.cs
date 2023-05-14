using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteractable : MonoBehaviour//, MakeInteractable
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

        //if (EisComplete && AisComplete)
        //{
        //    isComplete = true;
        //    doorAnimation.SetBool("openDoor", false);

        //}
    }

    public void setCompleted(string letter)
    {
        Debug.Log("letter");
        Debug.Log(letter);
        if (letter == "A")
        {
            completeA.SetActive(true);
            interactiveCubeA.SetActive(false);
            AisComplete = true;
        }
        if (letter == "E")
        {
            completeE.SetActive(true);
            interactiveCubeE.SetActive(false);
            EisComplete = true;
        }
        if (AisComplete && EisComplete)
        {
            isComplete = true;
        }

    }

}
