using UnityEngine;
using OculusSampleFramework;
// hand = GetComponentInChildren<OVRHand>();
public class TeleportGesture : MonoBehaviour
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
        if (hand.IsDataValid && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.9f)
        {
            OVRBone bone = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip]; // tip joint of index finger
            Vector3 indexFingerTipPosition = bone.Transform.position;
            Vector3 indexFingerTipNormal = bone.Transform.forward;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, indexFingerTipPosition);

            RaycastHit hit;
            if (Physics.Raycast(indexFingerTipPosition, indexFingerTipNormal, out hit, Mathf.Infinity, groundLayer))
            {
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(1, indexFingerTipPosition + indexFingerTipNormal * 0.1f);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}