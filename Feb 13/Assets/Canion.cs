using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canion : MonoBehaviour{

    public GameObject original;
    public Transform referencia;


    private Coroutine corutinita;
    private IEnumerator enumeradorcito, disparo;
    

    // Start is called before the first frame update
    void Start(){

        enumeradorcito = pseudoHilo();

        corutinita = StartCoroutine(enumeradorcito);

        //Manera de obtener una referencia a un gameobject
        //original =  GameObject.Find("Bala"); //Es algo muy lento para cuando tienes muchos gameobjects
        
        //Segunda manera de obtener una referencia a un objeto

        StartCoroutine(pseudoHilo());

        //Fuchi guacala
        StartCoroutine("corutina2");
        //Se puede llamar el pseudohilo con un string -> StartCoroutine(pseudoHilo;

        disparo = Disparar();
    }

    // Update is called once per frame
    void Update(){
        //Crear un nuevo game object
        //Clonarlo - instantiate
        //Para instancias nevesitamos un objetco base que copiar

        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(disparo);
        }


        if(Input.GetKeyUp(KeyCode.Space)) {
            StopCoroutine(disparo);
        }

        if (Input.GetKeyUp(KeyCode.C)){
            StopAllCoroutines();
        }

        if(Input.GetKeyUp(KeyCode.Z)){
            //Terminar pseudohilo
            // IEnumerator, coroutine
            StopCoroutine(enumeradorcito);
        }

        if(Input.GetKeyUp(KeyCode.X)){
            //Terminar corutina2
            StopCoroutine( "corutina2" );
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * 5 * Time.deltaTime, 0, 0);
        transform.Rotate(-10 * v * Time.deltaTime, 0, 0);
    }

    //Co rutinas
    //Pseudo concurrencia
    //Regla general en las repeticiones:
    //Hacer las menos posibles por segundo mientras se private void OnServerInitialized() {
    //bien 
    
    IEnumerator pseudoHilo(){
        while(true){
            yield return new WaitForSeconds(0.5f);
            print("Hola!");
        }
        
    }

    IEnumerator Disparar(){
        while(true){
            //Instanciar bala
            Instantiate(
                original,
                referencia.position,
                referencia.rotation
            );
            yield return new WaitForSeconds(0.2f);
        }
    }


    //Segunda corutina para probar control 
    IEnumerator corutina2(){
        while(true){
            yield return new WaitForSeconds(03f);
            print("ADIOS.");
        }
    }
}
