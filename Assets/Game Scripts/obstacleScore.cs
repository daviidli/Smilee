using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScore : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() != null)
            if (GameController.instance.charEmote == 3)
            {
                GameController.instance.SadAddScore();
            } else
            {
                GameController.instance.AddScore();
            }
    }
}
