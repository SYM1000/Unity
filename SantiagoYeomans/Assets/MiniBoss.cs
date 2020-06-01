using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{

    public Transform[] nodos;
    private int nodoActual;
    private int velocidad = 5;
    public GameObject balaBoss;




    // Start is called before the first frame update
    void Start(){
        nodoActual = 0;
        StartCoroutine(VerificarObjetivo());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(nodos[nodoActual]);
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
    }




    IEnumerator VerificarObjetivo(){

        while(true){

            // si la distancia entre mi personaje y su objetivo es menor que el rango permitido
            float distancia = Vector3.Distance(transform.position, nodos[nodoActual].transform.position);

            // si la distancia entre el jugador y el objetivo es menor que el rango valido llegamos
            if(distancia < 0.5f){
                velocidad = 0;
                StartCoroutine(MasacrarAlJugador());
                yield return new WaitForSeconds(1f);
                //StartCoroutine(MasacrarAlJugador());

                yield return new WaitForSeconds(1f);

                nodoActual++;
                nodoActual %= nodos.Length;
                velocidad = 5;
            }

            yield return new WaitForSeconds(0.3f);
        }

        
    }

    IEnumerator MasacrarAlJugador(){
        float timepo = 0f; 
        while(timepo <= 1f){
            Instantiate(balaBoss, transform.position,transform.rotation);
            timepo += 0.33f;
            yield return new WaitForSeconds(0.33f);
        }
        yield break;
        

    }

}
