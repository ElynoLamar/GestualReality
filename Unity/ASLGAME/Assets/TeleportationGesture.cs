using UnityEngine;
using OculusSampleFramework;
using System;
using System.Collections;
// hand = GetComponentInChildren<OVRHand>();
public class TeleportationGesture : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public OVRHand hand;
    public OVRSkeleton skeleton;
    public LayerMask groundLayer;
    public GameObject playerObject;
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
            // Check if the pinch gesture raycast hit the floor.
            if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, groundLayer))
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