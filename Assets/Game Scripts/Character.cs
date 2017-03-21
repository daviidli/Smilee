using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float JumpHeight = 5000f;
    private int doubleJump = 1;
    private bool touchingGround = false;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.instance.isPaused)
        {
            return;
        }

        switch (GameController.instance.charEmote)
        {
            case 0:
                anim.SetTrigger("Neutral");
                break;
            case 1:
                anim.SetTrigger("Happy");
                break;
            case 2:
                anim.SetTrigger("Angry");
                break;
            case 3:
                anim.SetTrigger("Sad");
                break;
        }

        if (!GameController.instance.gameOver)
        {   if (GameController.instance.charEmote == 0) { //Neutal
                JumpHeight = 300f;
                if (Input.GetKeyDown("space") && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    anim.SetTrigger("Jump");
                }
            }else if (GameController.instance.charEmote == 1) { //Happy
                JumpHeight = 300f;
                if (Input.GetKeyDown("space") && (doubleJump > 0) && !GameController.instance.isPaused)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    anim.SetTrigger("Jump");
                    doubleJump--;
                }
            } else if (GameController.instance.charEmote == 2) { //Angry
                JumpHeight = 300f;
                if (Input.GetKeyDown("space") && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    anim.SetTrigger("Jump");
                }
            } else if (GameController.instance.charEmote == 3) { //Sad 
                JumpHeight = 250f;
                if (Input.GetKeyDown("space") && touchingGround)
                {
                    rb2d.velocity = (new Vector2(0, 0));
                    rb2d.AddForce(new Vector2(0, JumpHeight));
                    anim.SetTrigger("Jump");
                }
            }
        } else {
            anim.SetTrigger("Dead");
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
