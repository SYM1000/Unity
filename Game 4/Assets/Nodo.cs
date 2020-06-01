using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
 
    public Nodo[] vecinos;
    public List<Nodo> historial;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(255,128,0);
        for (int i = 0; i < vecinos.Length; i++){
            if(vecinos[i] != null){
                Gizmos.DrawLine(transform.position, vecinos[i].transform.position);
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 1);
            
        }
    }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1);
        }
        
    
}
