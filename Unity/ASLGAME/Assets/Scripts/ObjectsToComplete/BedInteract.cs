using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedInteract : MonoBehaviour//, MakeInteractable
{

    public GameObject objectToMakeVisible;
    public GameObject completeE;
    public GameObject interactiveCube;
    public float visibleDistance = 5f;

    private bool objectIsVisible = false;
    public bool isComplete = false;

    private void Start()
    {
       
        objectToMakeVisible.SetActive(false);
        completeE.SetActive(false);
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
        if (Input.GetKey(KeyCode.K) && objectIsVisible) // check if the "K" key is pressed AND the object is visible
        {
            interactiveCube.SetActive(false);
            completeE.SetActive(true);
            isComplete = true;
            
        }
    }

    public void setCompleted()
    {
        Debug.Log("entramos no set");

        if (objectIsVisible)
        {
            Debug.Log("no if 2");

            interactiveCube.SetActive(false);
            completeE.SetActive(true);
            isComplete = true;
            Debug.Log("done");

        }

    }
   
    

}
