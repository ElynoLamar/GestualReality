using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReplace : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject replacementObject;
    public float delay = 5f;

    //private void Start()
    //{
    //    Invoke(nameof(SwitchObjects), delay);
    //}
    public void Activate()
    {
        Invoke(nameof(SwitchObjects), delay);
    }


    private void SwitchObjects()
    {
        originalObject.SetActive(false);
        replacementObject.SetActive(true);
    }
}
