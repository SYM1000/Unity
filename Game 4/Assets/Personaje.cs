using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour{

    public int NodoActual {
        protected set {
            nodoActual = value;
        }
        get {
            return nodoActual;
        }
    }

    public static Personaje Instancia {
        private set;
        get;
    }

    public Nodo[] ruta;
    public float velocidad = 5;
    public float rangoValido;
    
    public int nodoActual;

    public int NodoInicio;
    public Nodo[] TodosLosNodos;



    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
        NodoActual = NodoInicio;
        StartCoroutine(VerificarObjetivo());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ruta[nodoActual].transform);
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);

        
    }


    IEnumerator VerificarObjetivo(){ 

        while(true){

            // si la distancia entre mi personaje y su objetivo es menor que el rango permitido
            float distancia = Vector3.Distance(transform.position, ruta[nodoActual].transform.position);

            // si la distancia entre el jugador y el objetivo es menor que el rango valido llegamos
            if(distancia < rangoValido){
                nodoActual++;
                nodoActual %= ruta.Length;
            }

            yield return new WaitForSeconds(0.3f);
        }

        
    }


    public void ResetRuta(Nodo[] nuevaRuta) {
        ruta = nuevaRuta;
        nodoActual = NodoInicio;
    }







}
