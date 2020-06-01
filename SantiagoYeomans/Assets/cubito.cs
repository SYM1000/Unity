using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubito : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update(){


        
    }


    void OnCollisionEnter(Collision c){

        if(c.transform.name == "BalaBoss(Clone)"){
            Destroy(c.gameObject);

        }

    }
}
