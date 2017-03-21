using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class showPhotos : MonoBehaviour {

    public RawImage image;
    public GameObject playAgainButton;

    private int photo = 0;
    private int i = 0;
    private string path;

    // Use this for initialization
    void Start () {
        path = Application.streamingAssetsPath;
        DirCount(new DirectoryInfo(path));
        DisplayImage(i);
        i++;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            if (i < photo)
            {
                DisplayImage(i);
                i++;
            }
            else
                playAgainButton.SetActive(true);
                
        }

    }

    public void DisplayImage(int i)
    {
        Texture2D imageTxtr = new Texture2D(2, 2);
        string fileName = System.IO.Path.Combine(Application.streamingAssetsPath, i + ".png");
        byte[] fileData = System.IO.File.ReadAllBytes(fileName);
        imageTxtr.LoadImage(fileData);
        image.texture = imageTxtr;
        image.material.mainTexture = imageTxtr;
    }

    public void DirCount(DirectoryInfo d)
    {
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase))
                photo++;
        }
        
    }
}
