using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour{

    public float velocidad;
    private Animator anim;

    public GameObject Bala;
    public Transform ReferenciaDeTiro;
    private bool caminar;

    // Start is called before the first frame update
    void Start()
    {
        caminar = true;
        anim = GetComponent<Animator>();
        Rigidbody rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update(){
        if(caminar == true){
            //Entrada de Inputs
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //Apuntar con el mouse
            Apuntar();

            //Animacion del jugador
            if(h != 0 || v != 0 ){
                anim.SetTrigger("Caminar");
                anim.ResetTrigger("Idle");
            }else{
                anim.SetTrigger("Idle");
                anim.ResetTrigger("Caminar");
            }

            //Mover al jugador
            transform.Translate(
                velocidad * h * Time.deltaTime,
                0,
                velocidad * v * Time.deltaTime,
                Space.World);

            //Disparar al hacer click
            if (Input.GetMouseButtonDown(0)){
                Instantiate(Bala,ReferenciaDeTiro.position, ReferenciaDeTiro.rotation);

            }
        }
            
    }

    void OnCollisionEnter(Collision c){
        //print(c.transform.name);
        if(c.transform.name == "BalaEnemigo(Clone)"){
            caminar = false;
            print("Jugador golpeado");
            //Reproducir animacion de golpe
            anim.ResetTrigger("Idle");
            anim.ResetTrigger("Caminar");
            anim.SetTrigger("Golpe");
            StartCoroutine(esperar());

        }
 
    }


    void Apuntar() {
         Vector3 v3T = Input.mousePosition;
         v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
         v3T = Camera.main.ScreenToWorldPoint(v3T);
         v3T -= transform.position;
         v3T = v3T * 10000.0f + transform.position;
         transform.LookAt(v3T);
     }

     IEnumerator esperar(){
        yield return new WaitForSeconds(1);
        caminar = true;
        yield break;
     }
}
