using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour {
    //public int spikePoolSize = 10;
    //public GameObject spikePreFab;
    //public float spawnRate = 1f;
    //public float spikeMaxX = 16;
    //public float spikeMinX = 6;
    //public float timeSinceElapsed = 5f;
    //public float minDist = 5f;

    //private GameObject[] spikes;
    //private Vector2 objectPoolPosition = new Vector2(15f,50f);
    //private float timeSinceLastSpawn = 0f;
    //private float currentTime = 0f;
    //private float spawnYPosition = 0f;
    //private int currentSpike = 0;
    //private float spawnXPosition = 0f;

    public GameObject obstacle;
    public Queue<GameObject> obstacleQueue;
    public GameObject groundMarker;

    //private int obstacleStartAmount = 8;
    private List<float> xList;
    //private Vector2 startPosition = new Vector2(-10f, 0f);
    private float xOutOfScreen = -20f;
    private float xMin = 22f;
    private float xMed = 32f;
    private float xMax = 42f;
    private float limitBetween = 5f;
    private float yPos = 0f;
    private float time = 0;


    // Use this for initialization
    void Start () {
        //spikes = new GameObject[spikePoolSize];
        //for(int i = 0; i < spikePoolSize; i++)
        //{
        //    spikes[i] = (GameObject)Instantiate(spikePreFab, objectPoolPosition, Quaternion.identity);
        //}
        //timeSinceLastSpawn = currentTime;

        xList = new List<float>();
        obstacleQueue = new Queue<GameObject>();
        addObstacles(2);
    }
	
	// Update is called once per frame
	void Update () {
        //currentTime = Time.time;    
        //if(GameController.instance.gameOver == false && (currentTime - timeSinceElapsed) > timeSinceLastSpawn)
        //{
        //    timeSinceLastSpawn = currentTime;
        //    float prevSpike;
        //    if (currentSpike == 0)
        //    {
        //        prevSpike = spikes[5].transform.position.x;
        //    }
        //    else
        //    {
        //        prevSpike = spikes[currentSpike - 1].transform.position.x;
        //    }

        //    do
        //    {
        //            spawnXPosition = Random.Range(spikeMinX, spikeMaxX);
        //            Debug.Log("Forever");
        //    } while (((spawnXPosition - prevSpike) < 5f)) ;

        //    spikes[currentSpike].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        //    currentSpike++;

        //    if (currentSpike >= spikePoolSize)
        //    {
        //        currentSpike = 0;
        //    }
        //}

        time++;
        checkOutOfBounds();
        if (time > 300f)
        {
            addObstacles(2);
            Debug.Log("add");
            time = 0;
        }
        
    }

    private void addObstacles(int i)
    {
        float a = xMin;
        for (int j = 0; j < i; j++)
        {
            if (j % 2 == 0)
            {
                float xPos = Random.Range(xMin, xMed);
                xList.Add(xPos);
            } else
            {
                float xPos = Random.Range(xMed, xMax);
                xList.Add(xPos);
            }
        }

        //float prev = 0;
        //for (int j = 0; j < xList.Count; j++)
        //{
        //    if (xList[j] - prev < limitBetween)
        //        xList[j] += limitBetween;
        //    prev = xList[j];
        //}

        Debug.Log("xlist count: " + xList.Count);
        for (int j = 0; j < i; j++)
        {
            obstacleQueue.Enqueue((GameObject)Instantiate(obstacle, new Vector2(xList[j], yPos), Quaternion.identity));
            Debug.Log(obstacleQueue.Count);
        }
    }

    private void checkOutOfBounds()
    {
        if (obstacleQueue.Count == 0)
            return;
        while (obstacleQueue.Peek().transform.position.x <= xOutOfScreen)
        {
            Debug.Log("removing one");
            Destroy(obstacleQueue.Peek());
            obstacleQueue.Dequeue();
        }
    }
}
