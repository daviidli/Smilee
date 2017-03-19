using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour {
    public int spikePoolSize = 10;
    public GameObject spikePreFab;
    public float spawnRate = 1f;
    public float spikeMaxX = 16;
    public float spikeMinX = 6;
    public float timeSinceElapsed = 2f;

    private GameObject[] spikes;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn = 0f;
    private float currentTime = Time.time;
    private float spawnYPosition = 0f;
    private int currentSpike = 0;
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
            Debug.Log("timecheck");
            timeSinceLastSpawn = currentTime;
            Debug.Log("hi");
            float spawnXPosition = Random.Range(spikeMinX, spikeMaxX);
            spikes[currentSpike].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentSpike++;
            if (currentSpike >= spikePoolSize)
            {
                currentSpike = 0;
            }
        }
		
	}
}
