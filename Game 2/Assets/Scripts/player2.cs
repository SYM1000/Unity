using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour{

    public int velocidad = 3;
    public GameObject canon;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){

        //Mover tanque a la izquierda
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(
                0,
                0,
                velocidad * -1 * Time.deltaTime,
                Space.World);
        }

        //Mover tanque a la derecha
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(
                0,
                0,
                velocidad * 1 * Time.deltaTime,
                Space.World);
        }

        //Mover cañon hacia arriba
        if(Input.GetKey(KeyCode.UpArrow)){
            canon.transform.Rotate(
                -20 * Time.deltaTime,
                0,
                0,
                Space.Self);
        }

        //Mover cañon hacia abajo
        if(Input.GetKey(KeyCode.DownArrow)){
           canon.transform.Rotate(
                20 * Time.deltaTime,
                0,
                0,
                Space.Self);
        }
        
    }
}
