using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour {

    public float flipForce;
    public float rotationForce;
    public Text scoreText;

    [HideInInspector]
    public Vector3 inicialPoint;
    [HideInInspector]
    public Vector3 endPoint;

    private float inputFire;
    private float timeFlying;

    [HideInInspector]
    public bool isPressed;
    private bool isFlying;

    private Rigidbody myRB;

    private Vector3 inicialTouch;
    private Vector3 endTouch;

    private int score = 0;
    private int highScore = 0;

    private bool teste;


	// Use this for initialization
	void Start ()
    {

        myRB = GetComponent<Rigidbody>();
        highScore = PlayerPrefs.GetInt("Record");

        scoreText.text = "Score: 0" + "\n" + "HighScore: " + highScore;

	}
	
	// Update is called once per frame
	void Update () {


#if UNITY_ANDROID && !UNITY_EDITOR

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isPressed = true;
                inicialTouch = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                inicialTouch = new Vector3(0, inicialTouch.y, inicialTouch.x);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouch = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                endTouch = new Vector3(0, endTouch.y, endTouch.x);
                isPressed = false;
                if ((endTouch.y - inicialTouch.y) > 0)
                {
                    FlipKnife();
                }
            }

        }

#endif


#if UNITY_EDITOR
                       if (isFlying) 
        {
            timeFlying += Time.deltaTime;
        }


        inputFire = Input.GetAxisRaw("Fire1");

        if (isPressed && inputFire == 0)
        {
            endPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            endPoint = new Vector3(0, endPoint.y, endPoint.x);
            isPressed = false;
            if ((endPoint.y - inicialPoint.y) > 0.3f)
            {
                FlipKnife();
            }
        }

        if (!isPressed && inputFire != 0) {
            isPressed = true;
            inicialPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            inicialPoint = new Vector3(0, inicialPoint.y, inicialPoint.x);
        }
		
#endif

	}

    void attScore()
    {
        scoreText.text = "Score: " + score.ToString() + "\n" + "HighScore: " + highScore;
    }

    void OnTriggerEnter(Collider col) 
    {
        if (timeFlying > 0.2f)
        {
            timeFlying = 0;
            isFlying = false;
            myRB.isKinematic = true;
        }

        if (col.tag != "Wood")
        {
            if (score > highScore) 
            {
                PlayerPrefs.SetInt("Record", score);
            }
            SceneManager.LoadScene(0);
        }
        else 
        {
            attScore();
            score += 1;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (timeFlying > 0.5f)
        {
            if (score > highScore)
            {
                PlayerPrefs.SetInt("Record", score);
            }
            SceneManager.LoadScene(0);
        }
    }

    void FlipKnife() {
        if (isFlying)
        {
            return;
        }
        isFlying = true;
        myRB.isKinematic = false;
        myRB.AddForce((endPoint - inicialPoint) * flipForce, ForceMode.Impulse);
        myRB.AddTorque(new Vector3(rotationForce, 0, 0), ForceMode.Impulse);
    }


}
