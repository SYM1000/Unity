using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    //Recuperar una referencia al componnete rigidbody
    // de este gameobject
    Rigidbody rb;

    // Start is called before the first frame update
    void Start(){

        //Puede ser null
        rb = GetComponent<Rigidbody>();


        //Podemos obtener varios rigidbody de un mismo objecto si hay 
        Rigidbody[] rbs = GetComponents<Rigidbody>();
        //3 vectores de referencia 
        //transform.up
        //transform.right
        //transform.forward

        //Version 1: new Vector3(0, 5, 10)
        rb.AddForce(transform.up * 11, ForceMode.Impulse);

        Destroy(gameObject, 3); //Se puede destruir gameobject, component o asset


    }

    // Update is called once per frame
    void Update(){

    }
}
