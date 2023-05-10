using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Hand")
        {
            gameObject.SetActive(false);
        }
    }
}
