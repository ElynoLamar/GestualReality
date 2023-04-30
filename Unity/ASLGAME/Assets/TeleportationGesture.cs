using UnityEngine;
using OculusSampleFramework;
using System;
using System.Collections;
using UnityEditor.PackageManager;
// hand = GetComponentInChildren<OVRHand>();
public class TeleportationGesture : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public OVRHand hand;
    public OVRSkeleton skeleton;
    public LayerMask groundLayer;
    public LayerMask cubeLayer;
    public LayerMask cardLayer;
    public GameObject playerObject;
    public Card cardFlipper; 
    private bool pinching = false;

    
    void Start()
    {
        lineRenderer.enabled = false;
    }

    void Update()
    {
        // Check if the hand is doing a pinch gesture.
        HandlePinch((RaycastHit hit) =>
        {
            Debug.Log("Raycast hit the floor.");
            TeleportPlayer(hit);
        });
    }

    /// <summary>
    /// Handles the pinch gesture for teleportation.
    /// </summary>
    /// <returns><c>true</c> if the user is using the pinch and the raycast has hit the floor.</returns>
    private bool HandlePinch(Action<RaycastHit> hitCallback = null)
    {
        // Grab index finger position and direction.
        OVRBone bone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip];
        Vector3 indexFingerTipPosition = bone.Transform.position;
        Vector3 indexFingerTipNormal = bone.Transform.forward;
        RaycastHit hit;
        if (hand.IsDataValid && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.9f)
        {
            lineRenderer.enabled = true;
            pinching = true;
        }
        else
        {
            if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, cardLayer))
            {

                if (hitCallback != null)
                {
                    if (pinching)
                    {
                        GameObject hitObject = hit.collider.gameObject;
                        hitObject.GetComponent<Card>().setFlipCard();
                        pinching = false;
                        lineRenderer.enabled = false;
                    }
                }
                else
                {
                    pinching = false;
                    lineRenderer.enabled = false;
                }

                // Do something with the hit object

                return false;
            }
            else if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, cubeLayer))
            {
                if (hitCallback != null)
                {
                    if (pinching)
                    {
                        GameObject hitObject = hit.collider.gameObject;
                        hitObject.GetComponent<HanddleCubeInteraction>().grabCube();
                        Debug.Log("TESTEEEEE");

                        pinching = false;
                        lineRenderer.enabled = false;
                    }
                }
                else
                {
                    pinching = false;
                    lineRenderer.enabled = false;
                }

                // Do something with the hit object

                return false;

            }
            else if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, groundLayer))
            {
                Debug.Log("hit ground");
                if (hitCallback != null)
                {
                    Debug.Log("hit ground callback");
                    if (pinching)
                    {
                        hitCallback(hit);
                    }
                }
                pinching = false;
                lineRenderer.enabled = false;
                return true;
            }
        
           
            return false;

        }

        return false;
    }

    /// <summary>
    /// Teleports the player to the hit point.
    /// </summary>
    /// <param name="hit">The hit point.</param>
    private void TeleportPlayer(RaycastHit hit)
    {
        Debug.Log("teleportPlayer");
        playerObject.transform.position = hit.point;
    }
}