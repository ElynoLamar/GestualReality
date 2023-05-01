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
    public string targetLetter;
    public string endpointUrl = "localhost:5000/";
    public new Camera camera;
    public Camera mainCamera;
    public GameObject targetBox;

    //
    public Camera orthoCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           takeScreenshot();
        }
    }

    public void takeScreenshot()
    {
        string letter = targetLetter;
        Debug.Log("ATTEMPTING SCREENSHOT" + letter);
        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string path = "dataset/screenshots/v5/" + letter + '/' + letter + '_' + timestamp + ".png";
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
        yield return new WaitForEndOfFrame();

        // Create a new RenderTexture with the same dimensions as the screen
        mainCamera.enabled = false;
        orthoCamera.enabled = true;
        orthoCamera.enabled = true; // Enable the new camera
        RenderTexture renderTexture = new RenderTexture(512, 512, 24);
        orthoCamera.targetTexture = renderTexture; // Use the new camera's RenderTexture

        // Render the new camera's view into the RenderTexture
        orthoCamera.Render();

        // Set the RenderTexture as the active RenderTexture
        RenderTexture.active = renderTexture;

        // Create a new Texture2D and read the RenderTexture's contents into it
        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        // Encode the Texture2D as a PNG and save it to the specified path
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        // Clean up
        orthoCamera.targetTexture = null;
        RenderTexture.active = null;
        orthoCamera.enabled = false;
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
        Debug.Log(request.downloadHandler.text);
        if (request.downloadHandler.text == targetLetter)
        {
            Debug.Log("entramos no fi");
            targetBox.GetComponent<BedInteract>().setCompleted();
        }
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request successful!");
            Debug.Log(request.downloadHandler.text);
          
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }

       /** string json = "{\"name\":\"John Smith\",\"age\":30,\"email\":\"john.smith@example.com\"}";
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        // create the UnityWebRequest object
        UnityWebRequest request = UnityWebRequest.Post(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // send the request and wait for a response
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("Request sent successfully!");
            Debug.Log(request.downloadHandler.text);
        }*/
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




    // collider com a mão, e tirar screenshots a cada x segs
    // comparar a repsosta  c/ targetLetter, se for igual particulas fixes se nao, particulas q falhaste

}
