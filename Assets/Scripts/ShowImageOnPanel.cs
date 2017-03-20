using UnityEngine;
using System.Collections;
using UnityEngine.Windows;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;


public class ShowImageOnPanel : MonoBehaviour {

    public RawImage image; // The object to place the image on

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Replace this block of code with how you plan to call your image display
	    if(GameController.instance.showEnd)
        {
            DisplayImage();
        }
	} 

    public void DisplayImage()
    {
            Texture2D imageTxtr = new Texture2D(2, 2);
            string fileName = "C:/Users/David/Desktop/FINALFINAL/Smilee/Assets/StreamingAssets/" + GameController.instance.captureCounter.ToString() + ".png";
            byte[] fileData = System.IO.File.ReadAllBytes(fileName);
            imageTxtr.LoadImage(fileData);
            image.texture = imageTxtr;
            image.material.mainTexture = imageTxtr;
            //image.GetComponent<Renderer>().material.mainTexture = imageTxtr;
    }
}
