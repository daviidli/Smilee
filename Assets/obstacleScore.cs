using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScore : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() != null)
            GameController.instance.AddScore();
    }
}
