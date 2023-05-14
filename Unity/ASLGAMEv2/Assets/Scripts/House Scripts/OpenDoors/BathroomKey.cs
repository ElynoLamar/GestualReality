using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomKey : MonoBehaviour
{
    //public GameObject Cube;
    public float inyteractableDistance = 3f;

    private bool objectInteractable = false;
    private Animator doorAnimation;
    //public string letter = "E";
    //public Letterbool handSignActivate;
    //public GameObject handObject;


    private void Start()
    {
        //objectToMakeVisible.SetActive(false);
        doorAnimation = GameObject.FindWithTag("BathDoor").GetComponent<Animator>();
        doorAnimation.SetBool("DoorOpen", false);
        objectInteractable = false;


    }

    private void Update()
    {
        if (objectInteractable)
        {
            Invoke("OpenDoor", 2f);
            //manter dentro deste if, mas no final dos ifs nested
            //showHandPose();
        }
    }

    //private void showHandPose()
    //{
    //    handObject.SetActive(true);
    //    Invoke("hideHandPose", 10f);
    //}
    //private void hideHandPose()
    //{
    //    handObject.SetActive(false);
    //    objectInteractable = false;
    //}
    private void OpenDoor()
    {
        doorAnimation.SetBool("DoorOpen", true);

    }
    public void grabKey()
    {
        objectInteractable = true;

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Hand")
        {
            gameObject.SetActive(false);
            OpenDoor(); 
        }
    }
}
