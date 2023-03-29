using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteract : MonoBehaviour
{
    public GameObject objectToMakeVisible;
    public float visibleDistance = 5f;

    private bool objectIsVisible = false;



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
}
