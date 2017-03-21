using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public bool gameOver = false;
    public float scorllSpeed = -10f;
    private int score = 0;
    public Text scoreText;
    public int charEmote = 0;
    public bool isPaused = false;
    public GameObject photoCanvas;
    public int captureCounter = 0;
    public bool needproc = false;
    public GameObject endCanvas;
    public bool showEnd = false;
    public int imageLim = 0;
    public GameObject textScore;
    public bool takePic = false;

	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        /*if (score % 3 == 0)
        {
            isPaused = true;
            photoCanvas.SetActive(true);
            takePic = true;

            needproc = true;
        }*/
    }

    public void SadAddScore()
    {
        score += 3;
        scoreText.text = "Score : " + score.ToString() + "  :'("; 
    }

    public void GameOver()
    {
        gameOver = true;
        endCanvas.SetActive(true);
        textScore.SetActive(false);
        //showEnd = true;
    }

    public void unPause()
    {
        photoCanvas.SetActive(false);
        isPaused = false;
    }
}
