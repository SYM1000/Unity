﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladrillo : MonoBehaviour
{

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)){
            rb.AddExplosionForce(
                    1000,
                    new Vector3(0,0,0),
                    -3); //Magnitud, posicion de la explosion ,determinar el radio de la explosion, 
        }
    }
}
