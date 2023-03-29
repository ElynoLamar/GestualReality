using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaInteractable : MonoBehaviour//, MakeInteractable
{
    //[SerializeField] private GameObject containerGameObject;
    //[SerializeField] private PlayerInteract playerInteract;
    ////[SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    //private void Start()
    //{
    //    containerGameObject.SetActive(false);
    //}
    //private void Update()
    //{
    //    if (playerInteract.GetInteractableObject() != null)
    //    {
    //        Show(playerInteract.GetInteractableObject());
    //    }
    //    else
    //    {
    //        Hide();
    //    }
    //}


    //private void Show(MakeInteractable interactable)
    //{
    //    containerGameObject.SetActive(true);
    //    //interactTextMeshProUGUI.text = interactable.GetInteractText();
    //}


    //private void Hide()
    //{
    //    containerGameObject.SetActive(false);
    //}

    //public void Interact(Transform interactorTransform)
    //{

    //}


    //public Transform GetTransform()
    //{
    //    return transform;
    //}
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
