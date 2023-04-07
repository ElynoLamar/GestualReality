using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.VisualScripting.Antlr3.Runtime;
using System.IO;
using System;
using UnityEngine.XR;

public class CameraScreeshots : MonoBehaviour
{
    public char targetLetter;
    public string endpointUrl = "localhost:5000/";
    public new Camera camera;
    public Camera mainCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeScreenshot(targetLetter);
        }
    }

    void takeScreenshot(char letter)
    {
        Debug.Log("ATTEMPTING SCREENSHOT" + letter);
        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string path = "dataset/screenshots/" + letter + '_'+ timestamp + ".png";
        StartCoroutine(SaveScreenshot(path, () =>
        {
            string imagePath = path;
            Debug.Log("SUCCESSFUL SS" + letter);
            StartCoroutine(PostRequest(imagePath));
        }));
    }
    private IEnumerator SaveScreenshot(string path, System.Action onComplete)
    {
        // Wait for the end of the frame to ensure that the previous frame's graphics are fully rendered
        yield return new WaitForEndOfFrame(); // n mexer 
     
        // Create a new RenderTexture with the same dimensions as the screen
        mainCamera.enabled = false;
        // Enable the camera to take a screenshot with 
        camera.enabled = true;
        ScreenCapture.CaptureScreenshot(path); //player camera only???
        //int width = Screen.width;
        //int height = Screen.height;
        //Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        //tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        //tex.Apply();
        //byte[] bytes = tex.EncodeToPNG();
        //// Do whatever with screenshot
        //File.WriteAllBytes(path, bytes);

        mainCamera.enabled = true;
        camera.enabled = false;

        Debug.Log("Screenshot saved to " + path);
    // Wait for 1 second
    yield return new WaitForSeconds(1f); // n mexer

        onComplete.Invoke(); // n mexer
    }
    IEnumerator PostRequest(string image)
    {
        WWWForm form = new WWWForm();

        // Read the image file as a byte array
        byte[] imageBytes = File.ReadAllBytes(image);

        // Add the image file as a binary data field in the form data
        form.AddBinaryData("image", imageBytes, image, "image/png");

        // Create a UnityWebRequest object with the form data and send it
        UnityWebRequest request = UnityWebRequest.Post(endpointUrl, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request successful!");
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }


    //GET EXAMPLE
    //void takeScreenshot(char letter, int index)
    //{
    //    StartCoroutine(GetRequest(endpointUrl));
    //}
    //IEnumerator GetRequest(string uri)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Get(uri))
    //    {
    //        yield return request.SendWebRequest();

    //        if (request.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Request successful!");
    //            Debug.Log(request.downloadHandler.text);
    //        }
    //        else
    //        {
    //            Debug.Log("Error: " + request.error);
    //        }
    //    }
    //}
}
