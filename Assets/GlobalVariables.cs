using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public Text txtScore;
    public int score = 0;

    public string[] sceneIHM = {"Homepage", "Game over"};

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("score")){
            this.score = 0;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
        }
        else {
            this.score = PlayerPrefs.GetInt("score");

            txtScore = GameObject.Find("txtScore").GetComponent<Text>(); 
            txtScore.text = "Score: " + this.score;
        } 
    }

    public void AddScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("score", score);
        txtScore.text = "Score : "+ score.ToString();
    }

}