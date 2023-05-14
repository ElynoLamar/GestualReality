using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public GameObject TV  = null;   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log(gameObject.name);
            if (gameObject.name == "Remote" && TV != null )
            {
                TV.SetActive(true);
            }
            gameObject.SetActive(false);
           
        }
    }
}
