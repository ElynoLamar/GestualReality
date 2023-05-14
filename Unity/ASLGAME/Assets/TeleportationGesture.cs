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
    public LayerMask wallLayer;
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
                        Debug.Log("card");
                        Debug.Log(hitObject);
                        ActivateCard(hitObject);
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
            else if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, wallLayer))
            {
                if (hitCallback != null)
                {
                    if (pinching)
                    {
                        GameObject hitObject = hit.collider.gameObject;
                        Debug.Log("wall");
                        Debug.Log(hitObject);
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
                        Debug.Log("cube");
                        Debug.Log(hitObject);
                        ActivateCube(hitObject);
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
                if (hitCallback != null)
                {
                    if (pinching)
                    {
                        GameObject hitObject = hit.collider.gameObject;

                        Debug.Log("~ground");
                        Debug.Log(hitObject);
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
    /// grabs the cube of the game object hit.
    /// </summary>
    /// <param name="hitObject">The game object hit.</param>
    private void ActivateCube(GameObject hitObject)
    {
        hitObject.GetComponent<HanddleCubeInteraction>().grabCube();
    }

    /// <summary>
    /// Flips the card of the game object hit.
    /// </summary>
    /// <param name="hitObject">The game object hit.</param>
    private void ActivateCard(GameObject hitObject)
    {
        hitObject.GetComponent<Card>().setFlipCard();
    }

    //New
    // Grab Key To Open Bathroom door
    private void ActivateBathroom(GameObject hitObject)
    {
        hitObject.GetComponent<BathroomKey>().grabKey();
    }

    // Grab U To Open Bathroom door
    private void ActivateLivingroom(GameObject hitObject)
    {
        hitObject.GetComponent<LivingroomDoor>().grabU();
    }
    // Grab Controller To Activate TV 
    private void ActivateTV(GameObject hitObject)
    {
        hitObject.GetComponent<GrabTV>().grabTV();
    }



    /// <summary>
    /// Teleports the player to the hit point.
    /// </summary>
    /// <param name="hit">The hit point.</param>
    private void TeleportPlayer(RaycastHit hit)
    {
        playerObject.transform.position = hit.point;
    }
}