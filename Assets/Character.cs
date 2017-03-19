using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private float JumpHeight = 300f;
    private int doubleJump = 1;
    private bool touchingGround = false;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
        {   if (GameController.instance.charEmote == 0) { //Neutal
                JumpHeight = 300f;
                if (Input.GetMouseButtonDown(0) && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                }
            }else if (GameController.instance.charEmote == 1) { //Happy
                JumpHeight = 300f;
                if (Input.GetMouseButtonDown(0) && (doubleJump > 0))
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    Debug.Log("cow");
                    doubleJump--;
                }
            } else if (GameController.instance.charEmote == 2) { //Angry
                JumpHeight = 300f;
                if (Input.GetMouseButtonDown(0) && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                }
            } else if (GameController.instance.charEmote == 3) { //Sad 
                JumpHeight = 250f;
                if (Input.GetMouseButtonDown(0) && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                }
            }
            

        } else {
            GameController.instance.gameOver = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchingGround = true;
        if (GameController.instance.charEmote == 1) {
            doubleJump = 2;
        } else {
            doubleJump = 1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        touchingGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingGround = false;
    }
}
