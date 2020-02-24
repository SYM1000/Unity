using System.Collections; //Importacion de .NET standar. API: estandar de librerias
using System.Collections.Generic; //Importacion de .NET standar
using UnityEngine;

public class Personaje : MonoBehaviour //Los dos puntos son como el extends o implemets
                                        //MonoBehaviour es parte de las librarias de unity
                                        //Todos los scripts que haga tienen que tener MonoBehaviour
{

    //Atributos publicos
    // Parte del engine o primitivos
    // Pueden ser modificados desde el editor

    public float velocidad = 3;

   
    //Primer Momento  
    //Sucede en el momento de la creacion del componente
    //Una sola vez  
    void Awake(){ 

        //print("AWAKE");

    }

    //Sucede una sola vez
    //Sucede después de TODOS los awakes
    // Diferencia: Strt depende de que el objeto esté habilitado (awake no)
    // Start is called before the first frame update
    void Start()
    {
        print("START");
    }

    // FPS -> Frames per second: depende que tan pesada es nuestra logica y de los graficos
    // Update corre una vez por frame
    // 30 fps -> minimo para considerar una aplicación tiempo real (limite inferior)
    // minimo de 60 fps (algo bueno) 60 veces hace el ciclio de logica y graficos
    // Update is called once per frame
    //Frecuencia con que corre es irregular
    // lo más magro posible. Debe tener lo minomo indispensbale:
    // -> Entrada del usuario
    // -> Movimiento
    void Update()
    {
        // Print no bloquea ejecución
        //Va haber veces que unity deshecha print. Print es más lento que el update

        //print("UPDATE");

        // Obtener input
        // polling y eventos -> Para juegos lo mejor es polling por que ya va adecuado al frame rate del juego
        //Aqui es puro polling 


        //ENTRADA DEL DISPOSITIVO
        // hay 2 manera de obtener entrada especifamente en unity
        // 1 - Pregutnando direcatmente al dispostiivo
        // 2 - Por medio de ejes

        if(Input.GetKeyDown(KeyCode.Space)){ //en C# los metodos van en mayuscula
            print("KEY DOWN");

        }

        if(Input.GetKey(KeyCode.Space)){ 
            print("KEY");

        }

        if(Input.GetKeyUp(KeyCode.Space)){ 
            print("KEY UP");

        }

        if(Input.GetMouseButtonUp(0)){  //Boton izquierod del mouse es 0 y el derecho es 1
            print(Input.mousePosition);

        }


        // ejes - abstraccion de la entrada de jugador
        // siempre está represetnado por un float
        // Rango [-1, - 1]
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       // print(h);
        // Todo input va a estar en la clase de INPUT

        //Podemos poner velocidad por frame pero el tamaño del frame es irregular
        //Modificacion: velocidad por segundo
        transform.Translate(
            velocidad * h * Time.deltaTime,
            velocidad * v * Time.deltaTime, 
            0,
            Space.World);  //Referencia al transform del mismo game object
            //Hacer que rote usando los ejes del mundo 
    }


    //3 estado diferentes de una colision(antes, durante y despues)
    //Deteccion de colisiones
    // 1 - Los involucrados todo tiene collider
    // 2 -  uno(el que se mueve) tiene el rigidbody


    //Si no congelamos hay una retroalimentación física
    void OnCollisionEnter(Collision c){
        print("Enter" + c.transform.name);
        print("Para mas info" + c.contacts[0].point);

    }

    void OnCollisionStay(Collision c){
        //print("Stay");
    }

    void OnCollisionExit(Collision c){
        print("Exit");
    }
    void OnTriggerEnter(Collider c){
        print("trigger enter" + c.transform.name);
    }
    void OnTriggerStay(Collider c){
        print("trigger stay");
    }
    void OnTriggerExit(Collider c){
        print("trigger Exit");
    }




    
    //En un frame
    //despues de correr TODOS los updates 
    //El moto corre TODOS los lateUpdates
    //La moryoría de la veces nunca lo usamos
    void LateUpdate(){
        //print("Late Update");
        
    }

    //Framerate fijo 
    // Configurable desde el editor
    //Si necesito bloquealo a algun framerate especifico
    // Sucede en los cuadros que coinciden con los ajustes que pusimos en ajustes de unity
    void FixedUpdate(){
           //print("Fixed update");
    }
}