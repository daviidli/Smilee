using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.instance.GameOver();
    }
}
