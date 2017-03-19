using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    public static GameController instance;
    private int score = 0;
    public float scorllSpeed = -10f;
    public Text scoreText;
    public int charEmote = 0;

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
        //if (gameOver)
        //    return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SadAddScore()
    {
        score += 3;
        scoreText.text = "Score : " + score.ToString() + "  :'("; 
    }

    public void GameOver()
    {
        gameOver = true;
        SceneManager.LoadScene("Main");
    }
}
