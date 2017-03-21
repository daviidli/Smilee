using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject textScore;
    public GameObject photoCanvas;
    public Text scoreText;

    public bool gameOver = false;
    public bool isPaused = false;
    public float scorllSpeed = -10f;

    public int charEmote = 0;
    public int captureCounter = 0;
    public bool takePic = false;
    public string photoPath;

    private int score = 0;

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

        photoPath = Application.streamingAssetsPath;
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
        textScore.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void unPause()
    {
        photoCanvas.SetActive(false);
        isPaused = false;
    }
}
