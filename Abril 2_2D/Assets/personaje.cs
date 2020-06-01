using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float velocidad = h * 5 * Time.deltaTime;

        transform.Translate(velocidad, 0, 0);
        Debug.Log(velocidad);
        animator.SetFloat("Velocidad", velocidad);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Colision");
    }
}
