using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float velocidad = 5;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    
        transform.Translate(
            velocidad * h * Time.deltaTime,
            0,
            velocidad * v * Time.deltaTime,
            Space.World
        );

        
    }

    void OnCollisionEnter(Collision c){
        if(c.transform.name == "Premio"){
            ScoreScript.scoreValue += 1000;
            PremioScript.valor = false;

        }else if(c.transform.name != "Pared" && c.transform.name != "Pared1" ){

            if(ScoreScript.scoreValue <= 0){
                UnityEditor.EditorApplication.isPlaying = false; //Cerrar el juego si está en el editor
                Application.Quit(); //Cerrar el juego si está en modo Build
            }else{
                ScoreScript.scoreValue -= 100;
            }
            

        }else{

        }

        
    }
}
