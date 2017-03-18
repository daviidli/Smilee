using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private float JumpHeight = 300f;
    private bool doubleJump = false;
    private bool touchingGround = false;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0) && (touchingGround || doubleJump))
            {
                rb2d.velocity = (new Vector2(0, 0));
                rb2d.AddForce(new Vector2(0, JumpHeight));
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchingGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingGround = false;
    }
}
