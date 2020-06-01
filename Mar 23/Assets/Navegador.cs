using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navegador : MonoBehaviour{

    private NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Posible blasfemia
        //Evaluar seriamente utilizar una corrutina
        //Verificar si el oobjeto ve algo
        RaycastHit data;
        if(Physics.Raycast(transform.position, transform.forward, out data)){
            print("VEO ALGO: " + data.transform.name);
        }

    }

    private void OnDrawGizmos(){
        OnDrawGizmos.color = Color.green;
        OnDrawGizmos.DrawLine(transform.position, transform.position + transform.forward * 100);
    }

    //onmouse - Métodos que, ayudados de raycast, detectan interaccion con el mouse 
    //Onmousedown- diste click en objeto
    //ONmousedrag - ya había click con el objeto y moviste el mouse
    //ONmouseenter - cuando el puntero apunta al objeto(solo funciona 1 frame)
    //onmouseexit - cuando el puntero deja de apuntar al objeto (solo 1 frame)
    //Onmouseover - mientras el puntero siga apuntando
    //onmouseup - soltamos click en objeto
    //onmouseupasbutton - dimos click y soltamos sobre objeto 
    //TODOS usan raycast
    // condiciones - hay collider, objeto no está en capa de ignorar raycast

    private void OnMouseEnter() {
        print("EL MOUSE ME APUNTA");
    }

    private void OnMouseExit() {
        print("EL MOUSE NO ME APUNTA");
    }

}
