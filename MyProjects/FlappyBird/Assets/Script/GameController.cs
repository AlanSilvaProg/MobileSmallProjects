using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] flaps;
    private int randomFlappy;

	// Use this for initialization
	void Start () {

        randomFlappy = Random.Range(0, 4);

        print(randomFlappy);

        if(randomFlappy >=0 && randomFlappy <= 1){
            flaps[0].SetActive(true);
            flaps[1].SetActive(false);
            flaps[2].SetActive(false);
        }
        else if (randomFlappy > 1 && randomFlappy  <= 2)
        {
            flaps[0].SetActive(false);
            flaps[1].SetActive(true);
            flaps[2].SetActive(false);
        }else if(randomFlappy >2){
            flaps[0].SetActive(false);
            flaps[1].SetActive(false);
            flaps[2].SetActive(true);
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
