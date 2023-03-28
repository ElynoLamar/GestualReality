using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedInteract : MonoBehaviour, MakeInteractable
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    //[SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Start()
    {
        containerGameObject.SetActive(false);
    }
    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }


    private void Show(MakeInteractable interactable)
    {
        containerGameObject.SetActive(true);
        //interactTextMeshProUGUI.text = interactable.GetInteractText();
    }


    private void Hide()
    {
        containerGameObject.SetActive(false);
    }

    public void Interact(Transform interactorTransform)
    {
       
    }


    public Transform GetTransform()
    {
        return transform;
    }
}
