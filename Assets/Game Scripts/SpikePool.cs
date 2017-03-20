using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour {
    public int spikePoolSize = 10;
    public GameObject spikePreFab;
    public float spawnRate = 1f;
    public float spikeMaxX = 16;
    public float spikeMinX = 6;
    public float timeSinceElapsed = 5f;
    public float minDist = 5f;

    private GameObject[] spikes;
    private Vector2 objectPoolPosition = new Vector2(15f,50f);
    private float timeSinceLastSpawn = 0f;
    private float currentTime = 0f;
    private float spawnYPosition = 0f;
    private int currentSpike = 0;
    private float spawnXPosition = 0f;
    
    // Use this for initialization
    void Start () {
        spikes = new GameObject[spikePoolSize];
        for(int i = 0; i < spikePoolSize; i++)
        {
            spikes[i] = (GameObject)Instantiate(spikePreFab, objectPoolPosition, Quaternion.identity);
        }
        timeSinceLastSpawn = currentTime;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.time;    
        if(GameController.instance.gameOver == false && (currentTime - timeSinceElapsed) > timeSinceLastSpawn)
        {
            timeSinceLastSpawn = currentTime;
            float prevSpike;
            if (currentSpike == 0)
            {
                prevSpike = spikes[5].transform.position.x;
            }
            else
            {
                prevSpike = spikes[currentSpike - 1].transform.position.x;
            }
            
            do
            {
                    spawnXPosition = Random.Range(spikeMinX, spikeMaxX);
                    Debug.Log("Forever");
            } while (((spawnXPosition - prevSpike) < 5f)) ;

            spikes[currentSpike].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentSpike++;

            if (currentSpike >= spikePoolSize)
            {
                currentSpike = 0;
            }
        }
		
	}
}
