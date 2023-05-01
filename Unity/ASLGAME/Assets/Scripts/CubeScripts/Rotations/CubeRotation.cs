using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [Header("HandRotation")]
    public float bounceSpeed = 8;
    public float bounceAmplitude = 0.05f;
    public float rotationSpeed = 90;
    public GameObject handObject;

    private float startHeight;
    private float timeOffset;
    //private HandRotation handRotation;


    void Start()
    {
        startHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
        //handRotation = GetComponentInChildren<HandRotation>();
        handObject.SetActive(false);
    }

    public void Cube()
    {
        //animate
        float finalheight = startHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
        var position = transform.localPosition;
        position.y = finalheight;
        transform.localPosition = position;

        //spin
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    public void CubeR()
    {

        // NOT USED ANYMORE
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("cube not rotating");

            handObject.SetActive(true);


        }
        else
        {
            Cube();
            handObject.SetActive(false);

        }
    }

    void Update()
    {
        CubeR();

    }
}
