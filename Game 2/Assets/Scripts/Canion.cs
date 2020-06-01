using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canion : MonoBehaviour{

    public Transform ReferenciaDeTiro;
    public GameObject bala;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if(jugador.name == "Player 1"){
            if(Input.GetKeyDown(KeyCode.Space)){
           //Disparar - Jugador 1
             Instantiate(
                bala,
                ReferenciaDeTiro.position,
                ReferenciaDeTiro.rotation);
                }
        }else{
            if(Input.GetMouseButtonDown(0)){
            //Disparar - Jugador 2
             Instantiate(
                bala,
                ReferenciaDeTiro.position,
                ReferenciaDeTiro.rotation);
                }
        }
        
        
    }
}
