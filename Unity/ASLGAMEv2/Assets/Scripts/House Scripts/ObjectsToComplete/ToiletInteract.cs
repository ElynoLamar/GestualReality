using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteract : MonoBehaviour
{
    public GameObject objectToMakeVisible;

    public GameObject completeO;
    public GameObject completeI;
    public GameObject completeE;

    public GameObject interactiveCubeO;
    public GameObject interactiveCubeI;
    public GameObject interactiveCubeE;

    public float visibleDistance = 5f;



    private bool objectIsVisible = false;

    public bool OisComplete = false;
    public bool IisComplete = false;
    public bool EisComplete = false;

    public bool isComplete = false;


    private void Start()
    {

        objectToMakeVisible.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,
            Camera.main.transform.position);

        if (!objectIsVisible && distanceToPlayer <= visibleDistance)
        {
            objectToMakeVisible.SetActive(true);

            objectIsVisible = true;
        }
        else if (objectIsVisible && distanceToPlayer > visibleDistance)
        {
            objectToMakeVisible.SetActive(false);

            objectIsVisible = false;
        }
    }
    public void setCompleted(string letter)
    {
        Debug.Log(letter);
        Debug.Log(""+OisComplete + " "+ EisComplete + " " + isComplete);
        if (letter == "O")
        {
            completeO.SetActive(true);
            interactiveCubeO.SetActive(false);
            OisComplete = true;
        }
        if (letter == "E")
        {
            completeE.SetActive(true);
            interactiveCubeE.SetActive(false);
            EisComplete = true;
        }
        if (letter == "I")
        {
            completeI.SetActive(true);
            interactiveCubeI.SetActive(false);
            IisComplete = true;
        }
        if (OisComplete && IisComplete && EisComplete)
        {
            isComplete = true;
        }

    }
}
