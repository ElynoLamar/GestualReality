using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingroomDoor : MonoBehaviour
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
        doorAnimation = GameObject.FindWithTag("LivingRoom").GetComponent<Animator>();
        doorAnimation.SetBool("openDoor", false);
        objectInteractable = false;


    }

    private void Update()
    {
        if (objectInteractable)
        {
            Invoke("openDoor", 2f);
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
        doorAnimation.SetBool("openDoor", true);

    }
    public void grabU()
    {
        objectInteractable = true;

    }
}
