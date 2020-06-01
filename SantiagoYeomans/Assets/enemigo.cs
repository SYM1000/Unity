using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{

    public Transform[] nodos;
    private int nodoActual;
    private int velocidad = 5;
    public GameObject bala;
    // Start is called before the first frame update
    void Start(){
        nodoActual = 0;
        StartCoroutine(VerificarObjetivo());
        //StartCoroutine(patrullar());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(nodos[nodoActual]);
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
    }



    IEnumerator patrullar(){
        while(true){
            transform.LookAt(nodos[nodoActual]);
            transform.Translate(transform.forward * 20 * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(0.1f);
        }
        

    }

    IEnumerator VerificarObjetivo(){

        while(true){

            // si la distancia entre mi personaje y su objetivo es menor que el rango permitido
            float distancia = Vector3.Distance(transform.position, nodos[nodoActual].transform.position);

            // si la distancia entre el jugador y el objetivo es menor que el rango valido llegamos
            if(distancia < 0.5f){
                velocidad = 0;
                yield return new WaitForSeconds(2f);
                Instantiate(bala, transform.position,transform.rotation);

                nodoActual++;
                nodoActual %= nodos.Length;
                velocidad = 5;
            }

            yield return new WaitForSeconds(0.3f);
        }

        
    }
}
