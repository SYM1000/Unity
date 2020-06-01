using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agente;

    //PAra que funcione el raycast con un objeto: 1. que no esté en la layer "ignore raycast" y que el objeto tenga un colider


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray rayito = camera.ScreenPointToRay(Input.mousePosition); //Matrices y vectores aplicandose
            RaycastHit datos;
            if(Physics.Raycast(rayito, out datos)){
                print("PEGÓ EN: " + datos.point);
                print("PEGÓ CON: " + datos.transform.name);
                agente.destination = datos.point;
                
            } else{
                print("NO PEGÓ");
            }
        }
        
    }
}
