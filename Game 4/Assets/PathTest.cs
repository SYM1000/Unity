using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{


    public Nodo inicio, fin;
    public Personaje MiPersonaje;
    public int NodoCercano;

    private void Start() {

        RutaIncio();
        
    }


    // Update is called once per frame
    void Update(){

        if(Input.GetMouseButtonDown(0)){

            int cerca = 0;
            float min =-1f;

            for (int i = 0; i < MiPersonaje.TodosLosNodos.Length; i++){
                float distancia = Vector3.Distance(MiPersonaje.transform.position, MiPersonaje.TodosLosNodos[i].transform.position);

                if(min == -1 || distancia < min ){
                    min = distancia;
                    cerca = i;
                    
                    
                }
            }
            print("el cercano es:" + cerca);
            NodoCercano = cerca;

            List<Nodo> ruta =  Path.Profundo(MiPersonaje.TodosLosNodos[MiPersonaje.NodoActual], MiPersonaje.TodosLosNodos[NodoCercano]);
            MiPersonaje.ResetRuta(ruta.ToArray()); //Decirle al personaje que su nueva ruta va a ser del nodo en el que se encuntra hasta el nodo mas cercano navegando por el grafo
            StartCoroutine(ChecarReinicio());
            
            
        }


        
    }

    public void RutaIncio(){

        List<Nodo> ruta = Path.Profundo(inicio, fin);

            foreach (Nodo actual in ruta) {
                //print(actual.transform.name);
            }

            //Personaje.Instancia.ResetRuta(ruta.ToArray());
            print("Ruta del incio");
            MiPersonaje.ResetRuta(ruta.ToArray());

    }

    IEnumerator ChecarReinicio(){

        float distancia;
        while(true){
            distancia = Vector3.Distance(MiPersonaje.transform.position, MiPersonaje.TodosLosNodos[NodoCercano].transform.position);

            if(distancia <= 1f){
                print("Se llegó al nodo " +  NodoCercano);
                
                RutaIncio();
                yield break;
            }

            yield return new WaitForSeconds(0.3f);
        }  
    }
}
