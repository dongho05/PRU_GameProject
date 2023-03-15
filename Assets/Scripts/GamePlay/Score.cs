using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private int ScoreNum=0;

    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Update()
    {
        
        ScoreText.text = "Score: " + ScoreNum;
    }

    
}
