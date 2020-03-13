using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVisualClick : MonoBehaviour {


    public bool showElements;

    public Image Clicker;
    public SpriteRenderer Circle;

    private float distance;
    private int quantCircles;

    private Knife acessKnifeScript;

	// Use this for initialization
	void Start () {

        acessKnifeScript = gameObject.GetComponent<Knife>();

	}
	
	// Update is called once per frame
	void Update () {

        Clicker.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (showElements)
        {
            Circle.enabled = true;
            Clicker.enabled = true;
        }
        else
        {
            Circle.enabled = false;
            Clicker.enabled = false;
        }

        if (acessKnifeScript.isPressed)
        {
            showElements = true;
        }
        else
        {
            showElements = false;
        }      

	}
}
