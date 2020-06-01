using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour{

    public int velocidad = 3;
    public GameObject canon;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        
        float v = Input.GetAxis("Vertical");

        //Mover tanque a la izquierda
        if(Input.GetKey("a")){
            //float h = Input.GetAxis("Horizontal"); //Para suavizar el movimiento
            transform.Translate(
                0,
                0,
                velocidad * -1 * Time.deltaTime,
                Space.World);
        }

        //Mover tanque a la derecha
        if(Input.GetKey("d")){
            //float h = Input.GetAxis("Horizontal"); //Para suavizar el movimiento
            transform.Translate(
                0,
                0,
                velocidad * 1 * Time.deltaTime,
                Space.World);
        }

        //Mover cañon hacia arriba
        if(Input.GetKey("w")){
            canon.transform.Rotate(
                -20 * Time.deltaTime,
                0,
                0,
                Space.Self);
        }

        //Mover cañon hacia abajo
        if(Input.GetKey("s")){
           canon.transform.Rotate(
                20 * Time.deltaTime,
                0,
                0,
                Space.Self);
        }
        
        
    }
}
