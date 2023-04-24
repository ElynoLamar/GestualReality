using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    public CameraScreeshots CameraScreeshots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Collided hands ");
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = new Color(0,0,0,0.5f);
            //InvokeRepeating("screenshot", 2f, 4f);

        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Collided hands ");
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = new Color(0, 1, 0, 0.5f);
            CancelInvoke("screenshot");

        }
    }

    void screenshot()
    {
        CameraScreeshots.takeScreenshot();
    }
}
