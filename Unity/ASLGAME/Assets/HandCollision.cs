using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    public CameraScreeshots CameraScreeshots;
    private bool takeScreenshot = false;




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Collided hands ");
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = new Color(0, 0, 0, 0.5f);
            if (!takeScreenshot)
            {
                takeScreenshot = true;
                InvokeRepeating("screenshot", 2f, 6f);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Collided hands ");
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = new Color(0, 1, 0, 0.5f);
            if (takeScreenshot)
            {
                CancelInvoke("screenshot");

                takeScreenshot = false;
            }
        }
    }

    void screenshot()
    {
        if (takeScreenshot)
        {
            CameraScreeshots.takeScreenshot();
        }
    }
}
