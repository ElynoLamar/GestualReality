using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteract : MonoBehaviour
{
    public GameObject objectToMakeVisible;

    public GameObject completeA;
    public GameObject completeE;
    public GameObject completeI;
    public GameObject completeO;
    public GameObject completeU;

    public GameObject interactiveCubeA;
    public GameObject interactiveCubeE;
    public GameObject interactiveCubeI;
    public GameObject interactiveCubeO;
    public GameObject interactiveCubeU;

    public float visibleDistance = 5f;


    private bool objectIsVisible = false;

    public bool AisComplete = false;
    public bool EisComplete = false;
    public bool IisComplete = false;
    public bool OisComplete = false;
    public bool UisComplete = false;

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

        if (AisComplete && EisComplete && IisComplete && OisComplete && UisComplete)
        {
            isComplete = true;
        }
    }

    public void setCompleted(string Letter)
    {
        if (Letter == "A")
        {
            AisComplete = true;
            completeA.SetActive(true);
            interactiveCubeA.SetActive(false);
        }
        if (Letter == "E")
        {
            EisComplete = true;
            completeE.SetActive(true);
            interactiveCubeE.SetActive(false);
        }
        if (Letter == "I")
        {
            IisComplete = true;
            completeI.SetActive(true);
            interactiveCubeI.SetActive(false);
        }
        if (Letter == "O")
        {
            OisComplete = true;
            completeO.SetActive(true);
            interactiveCubeO.SetActive(false);
        }
        if (Letter == "U")
        {
            UisComplete = true;
            completeU.SetActive(true);
            interactiveCubeU.SetActive(false);
        }
        if (AisComplete && EisComplete && IisComplete && OisComplete && UisComplete)
        {
            isComplete = true;
            GameTimer gameTimer = GetComponentInParent<GameTimer>();
            gameTimer.endGame();
        }
    }
}
