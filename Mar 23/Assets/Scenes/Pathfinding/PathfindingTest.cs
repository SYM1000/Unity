using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
{
public Nodo inicio, fin;


    // Start is called before the first frame update
    void Start()
    {
        //Anterior
        //List<Nodo> ruta = PathFinding.Ancho(inicio, fin);

        //for(int i = 0; i< ruta.Count; i++){

            //Debug.Log(ruta[i].transform.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Breathwise
        if(Input.GetKeyUp(KeyCode.B)){
            List<Nodo> ruta = PathFinding.Ancho(inicio , fin);

            foreach (Nodo acutal in ruta){
                print(acutal.transform.name);
            }

            // Cambiar ruta de objeto
            Personaje.Instancia.ResetRuta(ruta.ToArray());

        }

        //Deapthwise
        if(Input.GetKeyUp(KeyCode.D)){
            List<Nodo> ruta = PathFinding.Profundo(inicio, fin);

            foreach (Nodo acutal in ruta){
                print(acutal.transform.name);
            }

            Personaje.Instancia.ResetRuta(ruta.ToArray);
        }

        //A star
        if(Input.GetKeyUp(KeyCode.D)){
            List<Nodo> ruta = PathFinding.AEstrella(inicio, fin);

            foreach (Nodo acutal in ruta){
                print(acutal.transform.name);
            }

            Personaje.Instancia.ResetRuta(ruta.ToArray);
        }
    }
}
