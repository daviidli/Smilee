﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour {
    public GameObject obstacle;
    public Queue<GameObject> obstacleQueue;
    
    private List<float> xList;
    private float xOutOfScreen = -10f;
    private float xMin = 22f;
    private float xMed = 32f;
    private float xMax = 42f;
    private float limitBetween = 5f;
    private float yPos = 0f;
    private float currentTime = 0f;
    private float timeSinceCurrentTime = 0f;

    void Start () {
        xList = new List<float>();
        obstacleQueue = new Queue<GameObject>();
        xList.Add(0);
        xList.Add(0);
        //addObstacles(2);
    }

	void Update () {
        currentTime = Time.time;
        checkOutOfBounds();
        if ((currentTime - 4f) > timeSinceCurrentTime && !GameController.instance.isPaused)
        {
            addObstacles(2);
            timeSinceCurrentTime = currentTime;
        }

        if (GameController.instance.gameOver)
        {
            while (obstacleQueue.Count > 0)
            {
                obstacleQueue.Dequeue();
                Debug.Log("end");
            }
        }
    }

    private void addObstacles(int i)
    {
        for (int j = 0; j < i; j++)
        {
            if (j % 2 == 0)
            {
                float xPos = Random.Range(xMin + limitBetween, xMed);
                xList[j] = xPos;
            } else
            {
                float xPos = Random.Range(xMed + limitBetween, xMax);
                xList[j] = xPos;
            }
        }

        for (int j = 0; j < i; j++)
        {
            obstacleQueue.Enqueue((GameObject)Instantiate(obstacle, new Vector2(xList[j], yPos), Quaternion.identity));
        }
    }

    private void checkOutOfBounds()
    {
        if (obstacleQueue.Count == 0)
            return;
        while (obstacleQueue.Peek().transform.position.x <= xOutOfScreen)
        {
            Destroy(obstacleQueue.Peek());
            obstacleQueue.Dequeue();
        }
    }
}
