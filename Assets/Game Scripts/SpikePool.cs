using System.Collections;
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
    //private float limitBetween = 5f;
    private float yPos = 0f;
    private float time = 0;

    void Start () {
        xList = new List<float>();
        obstacleQueue = new Queue<GameObject>();
        xList.Add(0);
        xList.Add(0);
        addObstacles(2);
    }

	void Update () {
        time++;
        checkOutOfBounds();
        if (time > 300f)
        {
            addObstacles(2);
            time = 0;
        }
        
    }

    private void addObstacles(int i)
    {
        for (int j = 0; j < i; j++)
        {
            if (j % 2 == 0)
            {
                float xPos = Random.Range(xMin, xMed);
                xList[j] = xPos;
            } else
            {
                float xPos = Random.Range(xMed, xMax);
                xList[j] = xPos;
            }
        }

        for (int j = 0; j < i; j++)
        {
            Debug.Log(xList[j]);
            obstacleQueue.Enqueue((GameObject)Instantiate(obstacle, new Vector2(xList[j], yPos), Quaternion.identity));
        }
    }

    private void checkOutOfBounds()
    {
        while (obstacleQueue.Peek().transform.position.x <= xOutOfScreen)
        {
            Destroy(obstacleQueue.Peek());
            obstacleQueue.Dequeue();
        }
    }
}
