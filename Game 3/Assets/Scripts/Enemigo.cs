using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Nodo[] ruta;
    public int nodoInicio;
    private int nodoActual;
    public float velocidad;
    private float rangoValido;

    public GameObject BalaEnemigo;
    public Transform manoDerecha;
    private Animator anim;
    private bool caminar;

    // Start is called before the first frame update
    void Start(){
        this.rangoValido = 1f;
        this.nodoActual = nodoInicio;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Caminar");
        StartCoroutine(verificarDestino());
        StartCoroutine(Disparar());
        caminar = true;

        
    }

    // Update is called once per frame
    void Update(){
        
        
        if(caminar == true){
            transform.LookAt(ruta[nodoActual].transform);
            transform.Translate(transform.forward * Time.deltaTime * velocidad, Space.World);
        }else{
            StopAllCoroutines();
            //print("Se detuvieron todas las coroutinas del enemigo");
        }
        
        
    }

    void OnCollisionEnter(Collision c) {
        //print(transform.name + "Colisionó con" + c.transform.name);

        if(c.transform.name == "Bala(Clone)"){
            caminar = false;
            StopAllCoroutines();
            //StopCoroutine(Disparar());
            //StopCoroutine(verificarDestino());
            Debug.Log(transform.name + " se murió");
            anim.ResetTrigger("Atacar");
            anim.ResetTrigger("Caminar");
            anim.SetTrigger("Morir");
            Destroy(gameObject, 2);

        }

     
        
    }

    IEnumerator verificarDestino(){

        while(true){
            float distancia = Vector3.Distance(transform.position, ruta[nodoActual].transform.position);

            if(distancia < rangoValido){
                
                nodoActual ++;
                nodoActual %= ruta.Length;
            }

            yield return new WaitForSeconds(0.3f);
        }

    }


    IEnumerator Disparar(){
        int tiempo = Random.Range(1, 5); //Tiempo entre cada disparo
        bool a = false;
        while(true){ 
            anim.ResetTrigger("Atacar");
            anim.SetTrigger("Caminar");
            yield return new WaitForSeconds(tiempo);
            a = true;
                while(a == true){

                int objetivo = Random.Range(0,7);
                transform.LookAt(ruta[objetivo].transform);

                anim.ResetTrigger("Caminar");
                anim.SetTrigger("Atacar");
                yield return new WaitForSeconds(0.7f);
                Instantiate(BalaEnemigo,manoDerecha.position, manoDerecha.rotation);
                //print("piu");
                a =false;
                
        }
        }
    }


}
