using UnityEngine;
using OculusSampleFramework;
using System;
// hand = GetComponentInChildren<OVRHand>();
public class TeleportationGesture : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public OVRHand hand;
    public OVRSkeleton skeleton;
    public LayerMask groundLayer;

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
        });
    }

    /// <summary>
    /// Handles the pinch gesture for teleportation.
    /// </summary>
    /// <returns><c>true</c> if the user is using the pinch and the raycast has hit the floor.</returns>
    private bool HandlePinch(Action<RaycastHit> hitCallback = null)
    {
        if (hand.IsDataValid && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.9f)
        {
            RaycastHit hit;

            // Grab index finger position and direction.
            OVRBone bone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip];
            Vector3 indexFingerTipPosition = bone.Transform.position;
            Vector3 indexFingerTipNormal = bone.Transform.forward;


            lineRenderer.enabled = true;

            // Check if the pinch gesture raycast hit the floor.
            if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, groundLayer))
            {
                lineRenderer.enabled = true;

                if (hitCallback != null)
                    hitCallback(hit);

                return true;
            }
        }

        lineRenderer.enabled = false;
        return false;
    }
}