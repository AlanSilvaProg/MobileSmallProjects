using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Flappy : MonoBehaviour {

    public Rigidbody2D myRB;
    public Animator myAnim;
    public Vector2 force;

    bool isDead;
    public Action onDeath;

    private int pontos = 0;

    public Text contadorPontos;

	// Use this for initialization
	void Start () {

        contadorPontos.text = ("Pontos: " + pontos);

	    
	}
	
	// Update is called once per frame
	void Update () {

        contadorPontos.text = ("Pontos: " + pontos);

        if (transform.position.y >= 1.3f) {
            transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            if (!isDead)
            {
                Flap();
            }
            else if (myRB.velocity.magnitude <= 0.1f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
		
	}

   

    void Flap() {

        if (myRB.IsSleeping())
        {
            myRB.sleepMode = RigidbodySleepMode2D.NeverSleep;
        }
        myRB.velocity = Vector2.zero;
        myRB.AddForce(force);
        myAnim.Play("Flappy");
        myAnim.Play("FlappyRed");
        myAnim.Play("FlappyYellow");
    }

    void Death() {

        if (onDeath != null) {
            onDeath();
        }

        isDead = true;

    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "DeathZone") {
            Death();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Point")
        {
            pontos += 1;
        }
    }

}
