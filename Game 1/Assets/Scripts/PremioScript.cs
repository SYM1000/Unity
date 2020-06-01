using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremioScript : MonoBehaviour{
    public static bool valor = true;

    // Update is called once per frame
    void Update(){
        gameObject.SetActive(valor);
    }
}
