using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    Rigidbody rb;
    public GameObject objetivo;
    bool seguir = false;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        Rigidbody[] rbs = GetComponents<Rigidbody>();

        //rb.AddForce(transform.forward * 11, ForceMode.Impulse);
        //rb.AddForce((objetivo.trasform.position - transform.position) ,ForceMode.Impulse); 
        //rb.AddForce (GameObject.Find("Personaje").transform.position.x, GameObject.Find("Personaje").transform.position.y, GameObject.Find("Personaje").transform.position.z);
        seguir = true;
        Destroy(gameObject, 3);

    }

    // Update is called once per frame
    void Update()
    {
    if(seguir == true){
        rb.AddForce((objetivo.transform.position - transform.position).normalized * 30,ForceMode.Impulse);
        seguir = false;
    }
        
    }
}
