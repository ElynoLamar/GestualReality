using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanddleCubeInteraction : MonoBehaviour
{

    //public GameObject Cube;
    public float inyteractableDistance = 1f;

    private bool objectInteractable = false;
    public Animator doorAnimation;


    private void Start()
    {

        //objectToMakeVisible.SetActive(false);
        doorAnimation = GetComponent<Animator>();

    }

    private void Update()
    {
        Debug.Log(objectInteractable);
        float distanceToPlayer = Vector3.Distance(transform.position,
            Camera.main.transform.position);
        
        if (!objectInteractable && distanceToPlayer <= inyteractableDistance)
        {
            //objectToMakeVisible.SetActive(true);

            objectInteractable = true;
            if (Input.GetKey(KeyCode.O))
            {
                doorAnimation.SetBool("DoorOpen", true);
            }
            
        }
        else if (objectInteractable && distanceToPlayer > inyteractableDistance)
        {
            //objectToMakeVisible.SetActive(false);

            objectInteractable = false;
        }

        
    }
}
