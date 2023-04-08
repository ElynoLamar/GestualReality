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

    //
    public Camera orthoCamera;
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
        // Old Way
        //    // Wait for the end of the frame to ensure that the previous frame's graphics are fully rendered
        //    yield return new WaitForEndOfFrame(); // n mexer 

        //    // Create a new RenderTexture with the same dimensions as the screen
        //    mainCamera.enabled = false;
        //    // Enable the camera to take a screenshot with 
        //    camera.enabled = true;
        //    ScreenCapture.CaptureScreenshot(path); //player camera only???
        //    //int width = Screen.width;
        //    //int height = Screen.height;
        //    //Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        //    //tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        //    //tex.Apply();
        //    //byte[] bytes = tex.EncodeToPNG();
        //    //// Do whatever with screenshot
        //    //File.WriteAllBytes(path, bytes);

        //    mainCamera.enabled = true;
        //    camera.enabled = false;

        //    Debug.Log("Screenshot saved to " + path);
        //// Wait for 1 second
        //yield return new WaitForSeconds(1f); // n mexer

        //    onComplete.Invoke(); // n mexer


        // New Try
        
        // Wait for the end of the frame to ensure that the previous frame's graphics are fully rendered
        yield return new WaitForEndOfFrame();

        // Create a new RenderTexture with the same dimensions as the screen
        mainCamera.enabled = false;
        orthoCamera.enabled = true;
        //
        int pixelWidth = orthoCamera.pixelWidth * 2;
        int pixelHeight = orthoCamera.pixelHeight * 2;

        //RenderTexture renderTexture = new RenderTexture(pixelWidth, pixelHeight, 24);
        //camera.targetTexture = renderTexture;
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera.targetTexture = renderTexture;

        // Render the camera's view into the RenderTexture
        camera.Render();

        // Set the RenderTexture as the active RenderTexture
        RenderTexture.active = renderTexture;

        // Create a new Texture2D and read the RenderTexture's contents into it
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        ////
        //Texture2D screenshot = new Texture2D(pixelWidth, pixelHeight, TextureFormat.RGB24, false);
        //screenshot.ReadPixels(new Rect(0, 0, pixelWidth, pixelHeight), 0, 0);
        //screenshot.Apply();

        // Encode the Texture2D as a PNG and save it to the specified path
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        // Clean up
        camera.targetTexture = null;
        RenderTexture.active = null;
        orthoCamera.enabled = false;
        mainCamera.enabled = true;

        Debug.Log("Screenshot saved to " + path);

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        onComplete.Invoke();
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
