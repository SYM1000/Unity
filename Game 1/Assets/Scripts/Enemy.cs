using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public float velocidad = 1;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(
            velocidad * Time.deltaTime,
            0,
            0,
            Space.World);
        
    }

    void OnCollisionEnter(Collision c){
        if(c.transform.name == "Pared" || c.transform.name == "Pared1"){
            velocidad = velocidad * -1;
        }

    }
    
}
