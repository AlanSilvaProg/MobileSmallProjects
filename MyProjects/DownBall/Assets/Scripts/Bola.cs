using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    public Rigidbody bolaRB;

    public Vector3 destino;

    private bool descendo = true;

    public float forca;

    public float velo;

    // Start is called before the first frame update
    void Start()
    {
        bolaRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(descendo)
        {
            bolaRB.velocity = new Vector3 (0, velo*Time.deltaTime, 0);
        }
        else
        {
            bolaRB.position = Vector3.Lerp(transform.position, destino, forca*Time.deltaTime);
            if(Vector3.Distance(transform.position, destino) <= 0.5f)
            {
                descendo = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {

        

        bolaRB.velocity = Vector3.zero;
       // bolaRB.AddForce(0, forca, 0);
        destino = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        descendo = false;
        if(other.collider.tag == "Dead")
        {
            print("Faliceu");
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }

}
