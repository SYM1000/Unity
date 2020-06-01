using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{

    public float velocidad;
    public GameObject cubito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(
            velocidad * h * Time.deltaTime,
            0,
            velocidad * v * Time.deltaTime,
            Space.World);




        if (Input.GetKeyDown("space")){
            GetComponent<Rigidbody>().velocity = Vector3.up * velocidad;
        }

        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Atacar());




        
    }







    IEnumerator Atacar(){
        Vector3 myVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        Instantiate(
                cubito,
                myVector,
                transform.rotation
            );
        yield break;
    }
}
