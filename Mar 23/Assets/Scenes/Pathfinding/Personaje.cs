using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour{

    //Propiedades
    //Una manera mas elegante de lidiar con los getters y setters

    
    public int NodoActual {
        protected set{ //No todos pueden escribir
            nodoActual = value;
         }
        get{ //Todos pueden leer pro es que publico(es el mimso que el metodo)
            return nodoActual;
        }
    }
    

    //Esto es una propiedad
    public static Personaje Instancia {
        private set;
        get;
    }

    public Nodo[] vecinos;
    public float velocidad = 5;
    public float rangoValido = 0.01f;

    private int  NodoActual;

    // Start is called before the first frame update
    void Start(){

        Instancia = this; //Esto funciona mejor para objetos que se tiene una vez en la escena o si se tienen varios, podemos usar un arreglo
        NodoActual = 0;
        StartCoroutine(VerificarDestino());
        
    }

    // Update is called once per frame
    void Update(){

        transform.LookAt(ruta[NodoActual].transform);
        transform.Translate(transform.forward * Time.deltaTime * velocidad, Space.World ); //El vector forward siempre ve hacia adelante     
    }

    //Cuaando se ve moviendo la caja hay que ir verificando la distancia la caja contra el obejtivo
    //Tener un rango si estamos usando puntos floatestes por que puede ser que nos exedamos y nunca lleguemos al punto
    //Tener un rango considerando la distancia con el objeto, po rque aveces no se da la presicion de estar en ese mismo punto



    IEnumerator VerificarDestino(){
        //Intencion: Verificar que tan serca esta de su destiono acual para ver si cambiamos rumbo
        while(true){

            float distancia = Vector3.Distance(transform.position, ruta[NodoActual].transform.position); //calcular la distancia entre dos puntos

            if(distancia < rangoValido){
                NodoActual ++;
                NodoActual %= ruta.Length; //Si se excedioo se va arregresar al nodo 0
            }

            yield return new WaitForSeconds(0.3f);
        }

    }

    public void ResetRuta(Nodo[] nuevaRuta){
        vecinos = nuevaRuta;
        nodoActual = 0;
    }


}
