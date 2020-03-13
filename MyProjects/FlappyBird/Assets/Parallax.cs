using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;
    public Transform[] floors;
    public Transform[] pipes;
    public float backgroundSpeed;
    public float floorSpeed;
    public float pipeSpeed;

   

    private const float backgroundWidth =0.96f;
    private const float floorWidth = 1.12f;
    private const float pipeWidth = 1f;

    Flappy flappy;

	// Use this for initialization
	void Start () {

        flappy = FindObjectOfType<Flappy>();
        flappy.onDeath += StopParallax;

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].position = new Vector3(pipes[i].position.x, Random.Range(-0.1f, 0.30f), pipes[i].position.z);
        }

	}
	
	// Update is called once per frame
	void Update () {

        MoveBackground(backgrounds, backgroundSpeed, backgroundWidth, false);
        MoveBackground(floors, floorSpeed, floorWidth, false);
        MoveBackground(pipes, pipeSpeed, pipeWidth, true);

	}

    void StopParallax() {

        backgroundSpeed = 0;
        floorSpeed = 0;
        pipeSpeed = 0;

    }

    void MoveBackground(Transform[] objects, float moveSpeed, float width, bool isRandomHeight) {

        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 bgPosition = objects[i].position;

            if (bgPosition.x <= width * -2)
            {
                objects[i].position = new Vector3(bgPosition.x + width * 4, bgPosition.y, bgPosition.z);

                if (isRandomHeight) {
                    objects[i].position = new Vector3(objects[i].position.x, Random.Range(-0.1f, 0.30f), objects[i].position.z);
                }
            }
            objects[i].Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

    }

  

}
