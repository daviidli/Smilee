using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameController.instance.charEmote == 2)
        {
            GameController.instance.charEmote = 0;
        }
        else
        {
            GameController.instance.GameOver();
        }
    }
}
