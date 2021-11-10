using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    Text scoreText;
    void Start()
    {
        scoreText = transform.Find("score").GetComponent<Text>();
        scoreText.text = "0";
    }
    void Update()
    {
        
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "" + score;
    }

}
