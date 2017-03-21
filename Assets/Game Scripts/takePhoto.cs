using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takePhoto : MonoBehaviour
{
    public string device;
    WebCamTexture webcamTexture;
    public RawImage liveView;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        device = devices[0].name;
        webcamTexture = new WebCamTexture(device, 800, 600, 12);

        liveView.texture = webcamTexture;
        liveView.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);

    void Update()
    {
        
    }

    void OnGUI()
    {
        webcamTexture.Play();
        if (GUI.Button(new Rect((Screen.width / 2) - 75, Screen.height - 75, 150, 30), "Take Photo"))
        {
            
            TakeSnapshot();
            webcamTexture.Stop();
            GameController.instance.analyzePic = true;
            GameController.instance.unPause();
        }
    } 

    /*private void Update()
    {
        if (GameController.instance.takePic)
        {
            GameController.instance.takePic = false;
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);

        TakeSnapshot();
        GameController.instance.unPause();
    }*/

    void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(GameController.instance.photoPath + GameController.instance.captureCounter.ToString() + ".png", snap.EncodeToPNG());
        GameController.instance.captureCounter++;
    }
}