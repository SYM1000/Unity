using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public AudioClip[] clips;
    public AudioSource player;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A)){
            player.clip = clips[0];
            player.Play();
        }

        if(Input.GetKeyUp(KeyCode.B)){
            player.clip = clips[1];
            player.Play();
        }

        if(Input.GetKeyUp(KeyCode.C)){
            player.clip = clips[2];
            player.Play();
        }

        if(Input.GetKeyUp(KeyCode.A)){
            
            player.Stop();
        }
    }
}
