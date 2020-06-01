using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int direccion;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * direccion * 7, ForceMode.Impulse);

        Destroy(gameObject, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
