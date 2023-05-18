using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    
    private Animator LVdoorAnimation;
    public GameObject LivingRoomUI;

    public string tagToFind = "Matched";
    //public bool openDoor = false;

    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
        LVdoorAnimation = GameObject.FindWithTag("LivingRoom").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            this.gameObject.SetActive(false);
            gameManager.SetShowCube();

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Matched");
            if (objectsWithTag.Length == 6)
            {
                LivingRoomUI.SetActive(false);
                LVdoorAnimation.SetBool("openDoor", true);

                //
                GameObject exitObject = GameObject.FindGameObjectWithTag("Exit");
                Debug.Log(exitObject);
                // Check if the GameObject was found
                if (exitObject != null)
                {
                    // Find the child game object with the name "ExitUI"
                    GameObject exitUI = exitObject.transform.Find("Exit UI").gameObject;
                    Debug.Log(exitUI);
                    // Activate the child game object
                    exitUI.SetActive(true);
                }
                //openDoor = true;
                // Debug.Log(openDoor);

            }
        }
        else if (Input.GetKey(KeyCode.L))
        {
            gameManager.UnFlippedSelectedCards();
        }
    }
    public void SetCompleted()
    {
        gameManager.SetShowCube();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Matched");
        if (objectsWithTag.Length == 6)
        {
            LivingRoomUI.SetActive(false);
            LVdoorAnimation.SetBool("openDoor", true);

            //
            GameObject exitObject = GameObject.FindGameObjectWithTag("Exit");
            // Check if the GameObject was found
            if (exitObject != null)
            {
                // Find the child game object with the name "ExitUI"
                GameObject exitUI = exitObject.transform.Find("Exit UI").gameObject;
                // Activate the child game object
                exitUI.SetActive(true);
            }
            //openDoor = true;
            // Debug.Log(openDoor);

        }
        gameObject.SetActive(false);

    }
    public void SetIncompleted()
    {
        gameManager.UnFlippedSelectedCards();
    }
}

