using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using UnityEngine.Windows;


public class ImageToEmotionAPI : MonoBehaviour {

    string EMOTIONKEY = "81a595a3061647b69236cbbedc873411"; 

    string emotionURL = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";

    public string fileName { get; private set; }
    string responseData;

    void Start () {
	    fileName = Path.Combine(GameController.instance.photoPath, GameController.instance.captureCounter.ToString() + ".png");
    }

    public void analyzePhoto()
    {
        StartCoroutine(GetEmotionFromImages());
    }

    IEnumerator GetEmotionFromImages()
    {
        byte[] bytes = System.IO.File.ReadAllBytes(fileName);

        var headers = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", EMOTIONKEY },
            { "Content-Type", "application/octet-stream" }
        };

        WWW www = new WWW(emotionURL, bytes, headers);

        yield return www;
        responseData = www.text;
        Debug.Log(responseData);
        GetComponent<ParseEmotionResponse>().ParseJSONData(responseData);
    }
}
