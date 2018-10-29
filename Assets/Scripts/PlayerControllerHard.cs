﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerHard : MonoBehaviour
{

    public bool ground;
    public float jumpForce;
    public Vector3 respawnPosition;
    public Rigidbody2D rb2d;
    public int cherries;
    public Text cherriesText;

    private Animator anim;
    private bool jump;
    private int dodges;
    private bool activate;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cherries = 0;
        cherriesText.text = "0";
        activate = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
            jump = true;


    }

    void FixedUpdate()
    {

        anim.SetBool("grounded", ground);

        float hor = Input.GetAxis("Horizontal");

        anim.SetBool("isRunning", hor != 0);

        if (hor > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb2d.velocity = new Vector3(hor * 10f, rb2d.velocity.y, 0);
        }
        else if (hor < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb2d.velocity = new Vector3(hor * 10f, rb2d.velocity.y, 0);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

        anim.SetBool("isCrouch", Input.GetKey(KeyCode.DownArrow));

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.4f);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.7f, 0.8f);
        }

        if (cherries == 6)
            SceneManager.LoadScene("MainMenu");

        if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene("MainMenu");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Thorn" || collision.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("HardMode");
        }
        else if (collision.gameObject.tag == "Cherry")
        {
            cherries++;
            cherriesText.text = "" + cherries;
        }
    }
}
