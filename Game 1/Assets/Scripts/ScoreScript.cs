using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour{

    Text score;
    public static int scoreValue = 100;

    void Start(){
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update(){
        score.text = "Score: " + scoreValue;
        
    }
}
