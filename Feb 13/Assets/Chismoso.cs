using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chismoso : MonoBehaviour{

    public Transform target;
  

    // Update is called once per frame
    void Update(){

        //Voltear a ver algo
        transform.LookAt(target);

        transform.Translate(
            transform.forward * 1 * Time.deltaTime,
            Space.World
            );
        
    }
}
