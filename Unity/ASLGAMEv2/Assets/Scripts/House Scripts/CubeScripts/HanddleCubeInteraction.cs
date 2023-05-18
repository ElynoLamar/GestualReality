using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanddleCubeInteraction : MonoBehaviour
{

    //public GameObject Cube;
    public float inyteractableDistance = 3f;

    private bool objectInteractable = false;
    private Animator doorAnimation;
    private Animator LivingRoomdoorAnimation;
    public string letter = "E";
    public Letterbool handSignActivate;
    public GameObject handObject;


    private void Start()
    {
        //objectToMakeVisible.SetActive(false);
        doorAnimation = GameObject.FindWithTag("BedroomDoor").GetComponent<Animator>();
        doorAnimation.SetBool("DoorOpen", false);
        LivingRoomdoorAnimation = GameObject.FindWithTag("LivingRoom").GetComponent<Animator>();
        LivingRoomdoorAnimation.SetBool("DoorOpen", false);
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
    private void OpenLastDoor()
    {
        LivingRoomdoorAnimation.SetBool("openDoor", true);

    }
    public void grabCube()
    {
        Debug.Log("grabcybe");
        Debug.Log(letter);
        showHandPose();
        handSignActivate.activateLetter();

        if (letter == "E")
        {
            Invoke("OpenFirstDoor", 2f);

        }
        if (letter == "U")
        {
            Invoke("OpenLastDoor", 2f);

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
