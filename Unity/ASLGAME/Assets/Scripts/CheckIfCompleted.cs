using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCompleted : MonoBehaviour
{
    //public GameObject childObject;
    //public BedInteract childScript;
    public ObjectReplace objectReplace;


    //private void Start()
    //{
    //    childScript = childObject.GetComponent<BedInteract>();
    //}

    //private void Update()
    //{
    //    if (childScript.isComplete)
    //    {
    //        objectReplace.Activate();
    //    }
    //}
    private BedInteract childScript;

    private void Update()
    {
        // Check if the child script exists
        if (childScript == null)
        {
            // Get the child script component
            childScript = GetComponentInChildren<BedInteract>();
        }

        // Check if the child script component has the boolean variable set to true
        if (childScript != null && childScript.isComplete == true)
        {
            // Call a function in the parent script
            MyFunction();
        }
    }

    private void MyFunction()
    {
        objectReplace.Activate();
    }
}
