using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanddleCubeInteraction : MonoBehaviour
{

    //public GameObject Cube;
    public float inyteractableDistance = 3f;

    private bool objectInteractable = false;
    private Animator doorAnimation;


    private void Start()
    {

        //objectToMakeVisible.SetActive(false);
        doorAnimation = GameObject.FindWithTag("BedroomDoor").GetComponent<Animator>();

    }

    private void Update()
    {
        //Debug.Log(objectInteractable);
        float distanceToPlayer = Vector3.Distance(transform.position,
            Camera.main.transform.position);
        
        if (!objectInteractable && distanceToPlayer <= inyteractableDistance)
        {
            //objectToMakeVisible.SetActive(true);

            objectInteractable = true;

            
        }
        else if (objectInteractable && distanceToPlayer > inyteractableDistance)
        {
            //objectToMakeVisible.SetActive(false);

            objectInteractable = false;
        }
        if (objectInteractable)
        {
            doorAnimation.SetBool("DoorOpen", true);
        }


    }
    public void grabCube() {
        objectInteractable = true;
    }
}
