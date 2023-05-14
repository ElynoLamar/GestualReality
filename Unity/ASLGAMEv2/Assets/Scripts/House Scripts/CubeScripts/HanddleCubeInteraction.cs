using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanddleCubeInteraction : MonoBehaviour
{

    //public GameObject Cube;
    public float inyteractableDistance = 3f;

    private bool objectInteractable = false;
    private Animator doorAnimation;
    public string letter = "E";
    public Letterbool handSignActivate;
    public GameObject handObject;


    private void Start()
    {
        //objectToMakeVisible.SetActive(false);
        doorAnimation = GameObject.FindWithTag("BedroomDoor").GetComponent<Animator>();
        doorAnimation.SetBool("DoorOpen", false);
        objectInteractable = false;


    }


    private void showHandPose()
    {
        handObject.SetActive(true);
        Invoke("hideHandPose", 10f);
    }
    private void hideHandPose()
    {
        handObject.SetActive(false);
        objectInteractable = false;
    }
    private void OpenFirstDoor()
    {
        doorAnimation.SetBool("DoorOpen", true);

    }
    public void grabCube()
    {
        showHandPose();

        if (letter == "E")
        {
            handSignActivate.activateLetter();
            Invoke("OpenFirstDoor", 2f);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            grabCube();
        }
    }
}
